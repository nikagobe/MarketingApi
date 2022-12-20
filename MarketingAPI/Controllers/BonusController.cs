using Microsoft.AspNetCore.Mvc;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Bonus.Request;
using NetworkMarketingCore.Contracts.Models.Bonus.Response;

namespace MarketingAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BonusController : Controller
    {

        private readonly IBonusService _bonusService;

        public BonusController(IBonusService bonusService)
        {
            _bonusService = bonusService;
        }

        [HttpPost("Calculate")]
        public async Task<List<CalculateBonusResponseModel>> CalculateBonuses(CalculateBonusRequestModel request)
        {
            return await _bonusService.CalculateBonus(request);
        }

        [HttpGet("Search")]
        public async Task<List<SearchBonusResponseModel>> SearchBonus([FromQuery] SearchBonusRequestModel request)
        {
            return await _bonusService.SearchBonus(request);
        }

    }
}
