using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Sale.Repository;
using NetworkMarketingCore.Contracts.Models.Sale.Request;
using NetworkMarketingCore.Contracts.Models.Sale.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Repositories
{
    public interface ISaleRepository
    {
        public Task<int> AddSale(AddSaleRepositoryModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task<List<GetSaleResponseModel>> GetSales(IDbConnection connection);
        public Task<GetSaleResponseModel> GetSale(GetSaleWithIdRequestModel request, IDbConnection connection);
        public Task<List<GetSaleResponseModel>> SearchSales(SearchSaleRequestModel request, IDbConnection connection);
        public Task<List<GetSaleResponseModel>> GetSalesForBonuses(GetSalesToCalculateBonusRequestModel request, IDbConnection connection);
        public Task UpdateSaleInclusion(UpdateSaleInclusionRequestModel request, IDbConnection connection, IDbTransaction transaction = null);

    }
}
