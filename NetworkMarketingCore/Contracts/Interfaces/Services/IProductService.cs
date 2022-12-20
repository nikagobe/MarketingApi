using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Product.Request;
using NetworkMarketingCore.Contracts.Models.Product.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Services
{
    public interface IProductService
    {
        public Task<int> AddProduct(AddProductRequestModel request, IDbTransaction transaction = null);
        public Task<List<GetProductResponseModel>> GetProducts();
        public Task<GetProductResponseModel> GetProduct(GetProductRequestModel request);
    }
}
