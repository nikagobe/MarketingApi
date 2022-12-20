using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Models.Bonus.Repository;
using NetworkMarketingCore.Contracts.Models.Bonus.Request;
using NetworkMarketingCore.Contracts.Models.Bonus.Response;

namespace NetworkMarketingCore.Implementations.Repositories
{
    public class BonusRepository : IBonusRepository
    {
        public async Task AddBonus(AddBonusRepositoryModel request, IDbConnection connection, IDbTransaction tran = null)
        {
            await connection.ExecuteAsync(
                @"INSERT INTO bonus(     distributor_id
                                               ,start_date
                                               ,end_date
                                               ,bonus_amount)
                                       VALUES(  @DistributorId
                                               ,@StartDate
                                               ,@EndDate
                                               ,@BonusAmount)", request, transaction: tran);
        }

        public async Task<List<SearchBonusResponseModel>> SearchBonus(SearchBonusRequestModel request, IDbConnection connection)
        {
            var res = await connection.QueryAsync<SearchBonusResponseModel>(@"SELECT sum(bonus_amount) AS bonus_amount, first_name, last_name
                                                                            FROM bonus
                                                                            join distributors d ON distributor_id = d.id
                                                                            GROUP BY distributor_id,first_name, last_name
                                                                            HAVING (@FirstName IS NULL or first_name = @FirstName) AND
                                                                                  (@LastName IS NULL or last_name = @LastName) AND
                                                                                  (@MinAmount IS NULL or sum(bonus_amount) >= @MinAmount) AND
                                                                                  (@MaxAmount IS NULL or sum(bonus_amount) <= @MaxAmount)", request);
            return res.ToList();
        }
    }
}
