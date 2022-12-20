using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Bonus.Repository;
using NetworkMarketingCore.Contracts.Models.Bonus.Request;
using NetworkMarketingCore.Contracts.Models.Bonus.Response;
using NetworkMarketingCore.Contracts.Models.Distributor.Request;
using NetworkMarketingCore.Contracts.Models.Distributor.Response;
using NetworkMarketingCore.Contracts.Models.Sale.Request;
using NetworkMarketingCore.Contracts.Models.Sale.Response;
using NetworkMarketingCore.Implementations.Helper;

namespace NetworkMarketingCore.Implementations.Services
{
    public class BonusService : IBonusService
    {

        private readonly ISaleService _saleService;
        private readonly IDbConnection _connection;
        private readonly IDistributorService _distributorService;
        private readonly IBonusRepository _repository;

        public BonusService(ISaleService saleService, IDistributorService distributorService,
                                IBonusRepository repository, IDbConnection connection)
        {;
            _saleService = saleService;
            _distributorService = distributorService;
            _repository = repository;
            _connection = connection;
        }

        public async Task<List<CalculateBonusResponseModel>> CalculateBonus(CalculateBonusRequestModel request, IDbTransaction transaction = null)
        {
            var distributorList = await _distributorService.GetDistributors();

            var bonusList = new List<AddBonusRepositoryModel>();

            foreach (var distributor in distributorList)
            {

                var firstTierSales = await GetSalesOfDistributor(request, distributor.Id);
                var secondTierSales = await GetSecondTierSales(distributor, request);
                var thirdTierSales = await GetThirdTierSales(distributor, request);


                double bonusAmount = 0;

                bonusAmount += firstTierSales.Sum(x => x.Total) * 0.10;
                bonusAmount += secondTierSales.Sum(x => x.Total) * 0.05;
                bonusAmount += thirdTierSales.Sum(x => x.Total) * 0.01;

                var newBonus = new AddBonusRepositoryModel()
                {
                    DistributorId = distributor.Id,
                    BonusAmount = bonusAmount,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate
                };

                bonusList.Add(newBonus);
            }


            return await AddNewBonuses(request, bonusList);
        }

        private async Task<List<CalculateBonusResponseModel>> AddNewBonuses(CalculateBonusRequestModel request, List<AddBonusRepositoryModel> bonusList)
        {
            var res = new List<CalculateBonusResponseModel>();

            await DbConnectionWrapper.RunAsTransaction(async (connection, transaction) =>
            {
                foreach (var bonus in bonusList)
                {
                    await _repository.AddBonus(bonus, connection, transaction);
                    res.Add(new()
                    {
                        DistributorId = bonus.DistributorId,
                        BonusAmount = bonus.BonusAmount
                    });
                }

                await _saleService.UpdateSaleInclusion(new()
                {
                    StartDate = request.StartDate,
                    EndDate = request.EndDate
                }, transaction);

            }, _connection);

            return res;
        }

        private async Task<List<GetSaleResponseModel>> GetSecondTierSales(GetDistributorResponseModel distributor,
            CalculateBonusRequestModel request)
        {

            var secondTierSales = new List<GetSaleResponseModel>();

            var referredDistributorRequest = new GetReferredDistributorsRequestModel()
            {
                ReferralId = distributor.Id
            };

            var secondTierDistributors = await _distributorService.GetReferredDistributors(referredDistributorRequest);


            foreach (var referredId in secondTierDistributors.ReferredDistributorIds)
            {
                (await GetSalesOfDistributor(request, referredId)).ForEach(x => secondTierSales.Add(x));

            }

            return secondTierSales;
        }

        private async Task<List<GetSaleResponseModel>> GetThirdTierSales(GetDistributorResponseModel distributor,
            CalculateBonusRequestModel request)
        {


            var referredDistributorRequest = new GetReferredDistributorsRequestModel()
            {
                ReferralId = distributor.Id
            };

            var secondTierDistributors = await _distributorService.GetReferredDistributors(referredDistributorRequest);

            var thirdTierDistributors = new List<int>();

            foreach (var referredId in secondTierDistributors.ReferredDistributorIds)
            {
                var req = new GetReferredDistributorsRequestModel()
                {
                    ReferralId = referredId
                };

                (await _distributorService.GetReferredDistributors(req))
                    .ReferredDistributorIds.ForEach(x => thirdTierDistributors.Add(x));
            }

            var thirdTierSales = new List<GetSaleResponseModel>();

            foreach (var thirdTierId in thirdTierDistributors)
            {
                (await GetSalesOfDistributor(request, thirdTierId)).ForEach(x => thirdTierSales.Add(x));
            }

            return thirdTierSales;
        }


        private async Task<List<GetSaleResponseModel>> GetSalesOfDistributor(CalculateBonusRequestModel request, int id)
        {
            var getSalesRequest = new GetSalesToCalculateBonusRequestModel()
            {
                DistributorId = id,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            var ownSales = await _saleService.GetSalesForBonuses(getSalesRequest);

            return ownSales;
        }


        public async Task<List<SearchBonusResponseModel>> SearchBonus(SearchBonusRequestModel request)
        {
            return await _repository.SearchBonus(request, _connection);
        }
    }
}
