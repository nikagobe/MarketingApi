using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Bonus.Repository;
using NetworkMarketingCore.Contracts.Models.Bonus.Request;
using NetworkMarketingCore.Contracts.Models.Bonus.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Repositories
{
    public interface IBonusRepository
    {
        public Task AddBonus(AddBonusRepositoryModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task<List<SearchBonusResponseModel>> SearchBonus(SearchBonusRequestModel request, IDbConnection connection);
    }
}
