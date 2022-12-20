using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Sale.Repository;
using NetworkMarketingCore.Contracts.Models.Sale.Request;
using NetworkMarketingCore.Contracts.Models.Sale.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Services
{
    public interface ISaleService
    {
        public Task<int> AddSale(AddSaleRequestModel request, IDbTransaction transaction = null);
        public Task<List<GetSaleResponseModel>> GetSales();
        public Task<GetSaleResponseModel> GetSale(GetSaleWithIdRequestModel request);
        public Task<List<GetSaleResponseModel>> SearchSales(SearchSaleRequestModel request);
        public Task UpdateSaleInclusion(UpdateSaleInclusionRequestModel request, IDbTransaction transaction = null);
        public Task<List<GetSaleResponseModel>> GetSalesForBonuses(GetSalesToCalculateBonusRequestModel request);


    }
}
