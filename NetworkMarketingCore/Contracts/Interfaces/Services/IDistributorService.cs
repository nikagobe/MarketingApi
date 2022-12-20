using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Distributor.Repository;
using NetworkMarketingCore.Contracts.Models.Distributor.Request;
using NetworkMarketingCore.Contracts.Models.Distributor.Response;
using NetworkMarketingCore.Contracts.Models.Document.Request;

namespace NetworkMarketingCore.Contracts.Interfaces.Services
{
    public interface IDistributorService
    {
        public Task<List<GetDistributorResponseModel>> GetDistributors();
        public Task<GetDistributorResponseModel> GetDistributor(GetDistributorRequestModel request);
        public Task<int> AddDistributor(AddDistributorRequestModel request, IDbTransaction transaction = null);
        public Task<GetReferredDistributorsResponseModel> GetReferredDistributors(GetReferredDistributorsRequestModel request);
        public Task UpdateDistributor(UpdateDistributorRequestModel request, IDbTransaction transaction = null);
        public Task DeleteDistributor(DeleteDistributorRequestModel request, IDbTransaction transaction = null);

    }
}
