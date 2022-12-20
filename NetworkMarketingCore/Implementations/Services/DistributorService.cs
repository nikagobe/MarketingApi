using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Distributor.Repository;
using NetworkMarketingCore.Contracts.Models.Distributor.Request;
using NetworkMarketingCore.Contracts.Models.Distributor.Response;
using NetworkMarketingCore.Implementations.Helper;

namespace NetworkMarketingCore.Implementations.Services
{
    public class DistributorService : IDistributorService
    {
        private readonly IDbConnection _connection;
        private readonly IDistributorRepository _repository;
        private readonly IDocumentService _documentService;
        private readonly IAddressService _addressService;
        private readonly ICommunicationService _communicationService;


        public DistributorService(IDistributorRepository repository, IDocumentService documentService,
            IAddressService addressService, ICommunicationService communicationService, IDbConnection connection)
        {
            _connection = connection;
            _repository = repository;
            _documentService = documentService;
            _addressService = addressService;
            _communicationService = communicationService;
        }


        public async Task<List<GetDistributorResponseModel>> GetDistributors()
        {
            var distributorRepList =  await _repository.GetDistributors(_connection);

            var result = new List<GetDistributorResponseModel>();

            foreach (var distributor in distributorRepList)
            {
                var newDist = await FillDistributor(distributor);
                result.Add(newDist);
            }

            return result;
        }

        public async Task<GetDistributorResponseModel> GetDistributor(GetDistributorRequestModel request)
        {
            var distributorRep = await _repository.GetDistributor(request, _connection);
            if (distributorRep == null) throw new ArgumentException("Invalid Id");

            return await FillDistributor(distributorRep);
        }


        private async Task<GetDistributorResponseModel> FillDistributor(GetDistributorRepositoryModel distributor)
        {
            var document = await _documentService.GetDocument(new() { Id = distributor.DocumentId });
            var address = await _addressService.GetAddress(new() { Id = distributor.AddressId });
            var communication = await _communicationService.GetCommunication(new() { Id = distributor.ContactInfoId });

            var newDist = new GetDistributorResponseModel(distributor)
            {
                Address = address,
                Communication = communication,
                Document = document
            };

            return newDist;
        }


        public async Task<int> AddDistributor(AddDistributorRequestModel request, IDbTransaction? tran = null)
        {

            var referralLevel = 0;
                
            if (request.ReferralId != null)
            {
                var referral = await GetDistributor(new() { Id = (int)request.ReferralId });


                if (referral == null)
                {
                    throw new ArgumentException("Distributor With That Referral Id Does Not Exist");
                }


                if (referral.ReferralLevel == 4)
                {
                    throw new ArgumentException("Distributor With That Referral Id Cant Refer People");
                }


                var referredList = await GetReferredDistributors(new(){ReferralId = (int)request.ReferralId});

                if (referredList.ReferredDistributorIds.Count >= 3)
                {
                    throw new ArgumentException("Distributor With That Referral Id Cant Refer Any More People");
                }

                
                referralLevel = referral.ReferralLevel + 1;
            }


            return await DbConnectionWrapper.RunAsTransaction(async (connection, transaction) =>
            {
                var documentId = await _documentService.AddDocument(request.Document, transaction);
                var addressId = await _addressService.AddAddress(request.Address, transaction);
                var communicationId = await _communicationService.AddCommunication(request.Communication, transaction);

                var newDistributor = new AddDistributorRepositoryModel(request)
                {
                    DocumentId = documentId,
                    AddressId = addressId,
                    CommunicationId = communicationId,
                    ReferralLevel = referralLevel
                };

                return await _repository.AddDistributor(newDistributor, connection, transaction);

            }, _connection);
        }

        public async Task<GetReferredDistributorsResponseModel> GetReferredDistributors(GetReferredDistributorsRequestModel request)
        {
            var list = await _repository.GetReferredDistributors(request, _connection);
            return new() { ReferredDistributorIds = list };
        }

        public async Task UpdateDistributor(UpdateDistributorRequestModel request, IDbTransaction tran = null)
        {
            await DbConnectionWrapper.RunAsTransaction(async (connection, transaction) =>
            {
                await _documentService.UpdateDocument(request.Document, transaction);
                await _addressService.UpdateAddress(request.Address, transaction);
                await _communicationService.UpdateCommunication(request.Communication, transaction);

                await _repository.UpdateDistributor(request, connection, transaction);
            }, _connection);
        }

        public async Task DeleteDistributor(DeleteDistributorRequestModel request, IDbTransaction tran = null)
        {
            var distributor = await GetDistributor(new () {Id = request.Id});
            await DbConnectionWrapper.RunAsTransaction(async (connection, transaction) =>
            {
                await _documentService.DeleteDocument(new () {Id = distributor.Document.Id}, transaction);
                await _addressService.DeleteAddress(new(){Id = distributor.Address.Id}, transaction);
                await _communicationService.DeleteCommunication(new() {Id = distributor.Communication.Id}, transaction);

                await _repository.DeleteDistributor(new() {Id = request.Id}, connection, transaction);
            }, _connection);
        }
    }
}