using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Models.Product.Request;
using NetworkMarketingCore.Contracts.Models.Product.Response;

namespace NetworkMarketingCore.Implementations.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<int> AddProduct(AddProductRequestModel request, IDbConnection connection, IDbTransaction tran = null)
        {
            return await connection.ExecuteScalarAsync<int>(
                @"INSERT INTO products(     code
                                               ,name
                                               ,price)
                                                OUTPUT Inserted.ID
                                       VALUES(  @Code
                                               ,@Name
                                               ,@Price)", request, transaction: tran);
        }

        public async Task<List<GetProductResponseModel>> GetProducts(IDbConnection connection)
        {
            var res = await connection.QueryAsync<GetProductResponseModel>(@"SELECT * FROM products");
            return res.ToList();
        }

        public async Task<GetProductResponseModel> GetProduct(GetProductRequestModel request, IDbConnection connection)
        {
            return await connection.QuerySingleOrDefaultAsync<GetProductResponseModel>(@"SELECT * FROM products
                                                                                              WHERE id = @ProductId",
                request);
        }
    }
}
