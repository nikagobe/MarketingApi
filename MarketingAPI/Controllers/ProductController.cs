using Microsoft.AspNetCore.Mvc;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Product.Request;
using NetworkMarketingCore.Contracts.Models.Product.Response;

namespace MarketingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<List<GetProductResponseModel>> Get()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("{id}")]
        public async Task<GetProductResponseModel> GetSingle(int id)
        {

            return await _productService.GetProduct(new() { ProductId = id });
        }


        [HttpPost]
        public async Task<int> Post(AddProductRequestModel request)
        {
            return await _productService.AddProduct(request);
        }

    }
}
