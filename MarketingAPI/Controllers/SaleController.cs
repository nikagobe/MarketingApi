using Microsoft.AspNetCore.Mvc;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Sale.Request;
using NetworkMarketingCore.Contracts.Models.Sale.Response;

namespace MarketingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpPost]
        public async Task<int> Post(AddSaleRequestModel request)
        {
            return await _saleService.AddSale(request);
        }

        [HttpGet]
        public async Task<List<GetSaleResponseModel>> Get()
        {
            return await _saleService.GetSales();
        }

        [HttpGet("{id}")]
        public async Task<GetSaleResponseModel> GetSingle(int id)
        {

            return await _saleService.GetSale(new() { Id = id });
        }

        [HttpGet("/Search")]
        public async Task<List<GetSaleResponseModel>> Search([FromQuery] SearchSaleRequestModel request)
        {

            return await _saleService.SearchSales(request);
        }
    }
}
