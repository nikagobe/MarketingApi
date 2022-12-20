using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Address.Request;
using NetworkMarketingCore.Contracts.Models.Address.Response;
using NetworkMarketingCore.Contracts.Models.Document.Request;

namespace NetworkMarketingCore.Contracts.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        public Task<int> AddAddress(AddAddressRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task UpdateAddress(UpdateAddressRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task DeleteAddress(DeleteAddressRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task<GetAddressResponseModel> GetAddress(GetAddressRequestModel request, IDbConnection connection);
    }
}
