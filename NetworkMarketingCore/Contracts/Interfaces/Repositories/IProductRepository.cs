using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Product.Request;
using NetworkMarketingCore.Contracts.Models.Product.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Repositories
{
    public interface IProductRepository
    {
        public Task<int> AddProduct(AddProductRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task<List<GetProductResponseModel>> GetProducts(IDbConnection connection);
        public Task<GetProductResponseModel?> GetProduct(GetProductRequestModel request, IDbConnection connection);
    }
}
