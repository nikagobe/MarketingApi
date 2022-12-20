using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Address.Request;
using NetworkMarketingCore.Contracts.Models.Address.Response;

namespace NetworkMarketingCore.Implementations.Services
{
    public class AddressService : IAddressService
    {

        private readonly IDbConnection _connection;
        private readonly IAddressRepository _repository;
        public AddressService(IDbConnection connection, IAddressRepository repository)
        {
            _connection = connection;
            _repository = repository;
        }
        public async Task<int> AddAddress(AddAddressRequestModel request, IDbTransaction? tran = null)
        {
            return await _repository.AddAddress(request, _connection, tran);

        }

        public async Task UpdateAddress(UpdateAddressRequestModel request, IDbTransaction transaction = null)
        {
            await _repository.UpdateAddress(request, _connection, transaction);
        }

        public async Task DeleteAddress(DeleteAddressRequestModel request, IDbTransaction transaction = null)
        {
            await _repository.DeleteAddress(request, _connection, transaction);
        }

        public async Task<GetAddressResponseModel> GetAddress(GetAddressRequestModel request)
        {
            return await _repository.GetAddress(request, _connection);
        }
    }
}
