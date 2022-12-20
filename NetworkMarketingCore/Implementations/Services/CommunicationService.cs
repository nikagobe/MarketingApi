using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Communication.Request;
using NetworkMarketingCore.Contracts.Models.Communication.Response;

namespace NetworkMarketingCore.Implementations.Services
{
    public class CommunicationService : ICommunicationService
    {

        private readonly IDbConnection _connection;
        private readonly ICommunicationRepository _repository;
        public CommunicationService(IDbConnection connection, ICommunicationRepository repository)
        {
            _connection = connection;
            _repository = repository;
        }
        public async Task<int> AddCommunication(AddCommunicationRequestModel request, IDbTransaction? tran = null)
        {
            return await _repository.AddCommunication(request, _connection, transaction: tran);
        }

        public async Task UpdateCommunication(UpdateCommunicationRequestModel request, IDbTransaction transaction = null)
        {
            await _repository.UpdateCommunication(request, _connection, transaction);
        }

        public async Task DeleteCommunication(DeleteCommunicationRequestModel request, IDbTransaction transaction = null)
        {
            await _repository.DeleteCommunication(request, _connection, transaction);
        }

        public async Task<GetCommunicationResponseModel> GetCommunication(GetCommunicationRequestModel request)
        {
            return await _repository.GetCommunication(request, _connection);
        }
    }
}
