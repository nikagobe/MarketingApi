using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Sale.Repository;
using NetworkMarketingCore.Contracts.Models.Sale.Request;
using NetworkMarketingCore.Contracts.Models.Sale.Response;

namespace NetworkMarketingCore.Implementations.Services
{
    public class SaleService : ISaleService
    {

        private readonly ISaleRepository _repository;
        private readonly IDistributorService _distributorService;
        private readonly IProductService _productService;
        private readonly IDbConnection _connection;
        public SaleService(IDbConnection connection, ISaleRepository repository, IDistributorService distributorService, IProductService productService)
        {
            _connection = connection;
            _repository = repository;
            _distributorService = distributorService;
            _productService = productService;
        }


        public async Task<int> AddSale(AddSaleRequestModel request, IDbTransaction transaction = null)
        {
            var distributor = await _distributorService.GetDistributor(new() { Id = request.DistributorId });

            var product = await _productService.GetProduct(new() { ProductId = request.ProductId });

            var total = product.Price * request.Quantity;

            var repositoryModel = new AddSaleRepositoryModel(request)
            {
                Total = total,
                SaleCode = Guid.NewGuid()
            };

            return await _repository.AddSale(repositoryModel, _connection);
        }

        public async Task<List<GetSaleResponseModel>> GetSales()
        {
            return await _repository.GetSales(_connection);

        }

        public async Task<GetSaleResponseModel> GetSale(GetSaleWithIdRequestModel request)
        {
            var res = await _repository.GetSale(request, _connection);
            if (res == null) throw new ArgumentException("Sale With This Id Does Not Exist");

            return res;
        }

        public async Task<List<GetSaleResponseModel>> SearchSales(SearchSaleRequestModel request)
        {
            return await _repository.SearchSales(request, _connection);
        }

        public async Task UpdateSaleInclusion(UpdateSaleInclusionRequestModel request, IDbTransaction transaction = null)
        {
            await _repository.UpdateSaleInclusion(request, _connection, transaction);
        }

        public async Task<List<GetSaleResponseModel>> GetSalesForBonuses(GetSalesToCalculateBonusRequestModel request)
        {
            return await _repository.GetSalesForBonuses(request, _connection);
        }
    }
}
