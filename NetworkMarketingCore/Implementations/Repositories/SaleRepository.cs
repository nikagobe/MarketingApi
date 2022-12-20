using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Models.Sale.Repository;
using NetworkMarketingCore.Contracts.Models.Sale.Request;
using NetworkMarketingCore.Contracts.Models.Sale.Response;

namespace NetworkMarketingCore.Implementations.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public async Task<int> AddSale(AddSaleRepositoryModel request, IDbConnection connection, IDbTransaction tran = null)
        {
            return await connection.ExecuteScalarAsync<int>(
                @"INSERT INTO sales(        sale_code
                                               ,distributor_id
                                               ,product_id
                                               ,quantity
                                               ,sale_date
                                               ,total)
                                                OUTPUT Inserted.ID
                                       VALUES(  @SaleCode
                                               ,@DistributorId
                                               ,@ProductId
                                               ,@Quantity
                                               ,@SaleDate
                                               ,@Total)", request, transaction: tran);
        }

        public async Task<List<GetSaleResponseModel>> GetSales(IDbConnection connection)
        {
            var res = await connection.QueryAsync<GetSaleResponseModel>(@"SELECT * FROM sales");
            return res.ToList();
        }

        public async Task<GetSaleResponseModel> GetSale(GetSaleWithIdRequestModel request, IDbConnection connection)
        {
            return await connection.QuerySingleOrDefaultAsync<GetSaleResponseModel>(@"SELECT * FROM sales
                                                                                              WHERE id = @Id",
                request);
        }

        public async Task<List<GetSaleResponseModel>> SearchSales(SearchSaleRequestModel request, IDbConnection connection)
        {
            var res =
                await connection.QueryAsync<GetSaleResponseModel>(@"SELECT * FROM sales
                                                                        WHERE  (@StartDate IS NULL or sale_date >= @StartDate) AND
                                                                               (@EndDate IS NULL or sale_date <= @EndDate) AND
                                                                               (@DistributorId IS NULL or distributor_id = @DistributorId) AND
                                                                               (@ProductId IS NULL or product_id = @ProductId) ", request);
            return res.ToList();
        }

        public async Task<List<GetSaleResponseModel>> GetSalesForBonuses(GetSalesToCalculateBonusRequestModel request, IDbConnection connection)
        {
            var res =
                await connection.QueryAsync<GetSaleResponseModel>(@"SELECT * FROM sales
                                                                        WHERE  sale_date >= @StartDate AND
                                                                               sale_date <= @EndDate AND
                                                                               included_in_bonus = 0 AND
                                                                               distributor_id = @DistributorId", request);
            return res.ToList();
        }

        public async Task UpdateSaleInclusion(UpdateSaleInclusionRequestModel request, IDbConnection connection,
            IDbTransaction tran = null)
        {
            await connection.ExecuteAsync(
                @"UPDATE sales   
                            SET included_in_bonus = 1
                        WHERE  sale_date >= @StartDate AND
                               sale_date <= @EndDate",
                request, transaction: tran);
        }
    }
}
