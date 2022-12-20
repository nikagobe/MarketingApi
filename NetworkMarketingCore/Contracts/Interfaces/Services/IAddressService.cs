using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Address.Request;
using NetworkMarketingCore.Contracts.Models.Address.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Services
{
    public interface IAddressService
    {
        public Task<int> AddAddress(AddAddressRequestModel request, IDbTransaction transaction = null);
        public Task UpdateAddress(UpdateAddressRequestModel request, IDbTransaction transaction = null);
        public Task DeleteAddress(DeleteAddressRequestModel request, IDbTransaction transaction = null);

        public Task<GetAddressResponseModel> GetAddress(GetAddressRequestModel request);
    }
}
