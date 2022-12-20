using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Models.Address.Request;
using NetworkMarketingCore.Contracts.Models.Address.Response;

namespace NetworkMarketingCore.Implementations.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public async Task<int> AddAddress(AddAddressRequestModel request, IDbConnection connection, IDbTransaction tran = null)
        {
            return await connection.ExecuteScalarAsync<int>(
                @"INSERT INTO address( type_id
                                               ,address)
                                       OUTPUT Inserted.ID
                                       VALUES(  @TypeId
                                               ,@Address)", 
                request, transaction: tran);
        }

        public async Task UpdateAddress(UpdateAddressRequestModel request, IDbConnection connection, IDbTransaction tran = null)
        {
            await connection.ExecuteAsync(
                @"UPDATE address
                             SET type_id = @TypeId,
                                 address = @Address
                             WHERE id = @Id",
                request, transaction: tran);
        }

        public async Task DeleteAddress(DeleteAddressRequestModel request, IDbConnection connection, IDbTransaction transaction = null)
        {
            await connection.ExecuteScalarAsync(@"DELETE FROM Address WHERE id = @Id", request,
                transaction: transaction);
        }

        public async Task<GetAddressResponseModel> GetAddress(GetAddressRequestModel request, IDbConnection connection)
        {
            return await connection.QuerySingleOrDefaultAsync<GetAddressResponseModel>(@"SELECT a.id, a.address, at.type FROM address a
                                                                                              JOIN address_type at on a.type_id = at.id
                                                                                              WHERE a.id = @Id",
                request);
        }
    }
}
