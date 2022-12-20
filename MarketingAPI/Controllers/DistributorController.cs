using Microsoft.AspNetCore.Mvc;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Address.Request;
using NetworkMarketingCore.Contracts.Models.Address.Response;
using NetworkMarketingCore.Contracts.Models.Communication.Request;
using NetworkMarketingCore.Contracts.Models.Communication.Response;
using NetworkMarketingCore.Contracts.Models.Distributor.Request;
using NetworkMarketingCore.Contracts.Models.Distributor.Response;
using NetworkMarketingCore.Contracts.Models.Document.Request;
using NetworkMarketingCore.Contracts.Models.Document.Response;

namespace MarketingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistributorController : ControllerBase
    {
        private readonly IDistributorService _distributorService;

        public DistributorController(IDistributorService distributorService)
        {
            _distributorService = distributorService;
        }

        [HttpGet]
        public async Task<List<GetDistributorResponseModel>> Get()
        {
            return await _distributorService.GetDistributors();
        }

        [HttpGet("{id}")]
        public async Task<GetDistributorResponseModel> GetSingle(int id)
        {

            return await _distributorService.GetDistributor(new() { Id = id });
        }

        [HttpGet("Referred/{id}")]
        public async Task<GetReferredDistributorsResponseModel> GetReferred(int id)
        {

            return await _distributorService.GetReferredDistributors(new() { ReferralId = id });
        }


        [HttpPost]
        public async Task<int> Post(AddDistributorRequestModel request)
        {
            return await _distributorService.AddDistributor(request);
        }

        [HttpPut]
        public async Task Put(UpdateDistributorRequestModel request)
        {
            await _distributorService.UpdateDistributor(request);
        }

        [HttpDelete("{id}")]
        public async Task Put(int id)
        {
            await _distributorService.DeleteDistributor(new() { Id = id });
        }
    }
}
