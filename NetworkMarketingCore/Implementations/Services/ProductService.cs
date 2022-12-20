using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Product.Request;
using NetworkMarketingCore.Contracts.Models.Product.Response;

namespace NetworkMarketingCore.Implementations.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly IDbConnection _connection;
        public ProductService(IDbConnection connection, IProductRepository repository)
        {
            _connection = connection;
            _repository = repository;
        }


        public async Task<int> AddProduct(AddProductRequestModel request, IDbTransaction transaction = null)
        {
            return await _repository.AddProduct(request, _connection);
        }

        public async Task<List<GetProductResponseModel>> GetProducts()
        {
            return await _repository.GetProducts(_connection);
        }

        public async Task<GetProductResponseModel> GetProduct(GetProductRequestModel request)
        {
            var res = await _repository.GetProduct(request, _connection);
            if (res == null) throw new ArgumentException("Product With This Id Does Not Exist");

            return res;
        }
    }
}
