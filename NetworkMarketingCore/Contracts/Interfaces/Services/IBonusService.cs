using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Bonus.Request;
using NetworkMarketingCore.Contracts.Models.Bonus.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Services
{
    public interface IBonusService
    {
        public Task<List<CalculateBonusResponseModel>> CalculateBonus(CalculateBonusRequestModel request, IDbTransaction transaction = null);
        public Task<List<SearchBonusResponseModel>> SearchBonus(SearchBonusRequestModel request);

    }
}
