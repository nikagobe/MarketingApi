using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Distributor.Repository;
using NetworkMarketingCore.Contracts.Models.Distributor.Request;
using NetworkMarketingCore.Contracts.Models.Distributor.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Repositories
{
    public interface IDistributorRepository
    {
        public Task<List<GetDistributorRepositoryModel>> GetDistributors(IDbConnection connection);
        public Task<GetDistributorRepositoryModel> GetDistributor(GetDistributorRequestModel request,IDbConnection connection);
        public Task<int> AddDistributor(AddDistributorRepositoryModel request , IDbConnection connection, IDbTransaction? transaction = null);
        public Task<List<int>> GetReferredDistributors(GetReferredDistributorsRequestModel request , IDbConnection connection);
        public Task UpdateDistributor(UpdateDistributorRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task DeleteDistributor(DeleteDistributorRequestModel request, IDbConnection connection, IDbTransaction transaction = null);

    }
}
