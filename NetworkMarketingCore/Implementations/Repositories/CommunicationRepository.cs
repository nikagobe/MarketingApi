using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Models.Communication.Request;
using NetworkMarketingCore.Contracts.Models.Communication.Response;

namespace NetworkMarketingCore.Implementations.Repositories
{
    public class CommunicationRepository : ICommunicationRepository
    {
        public async Task<int> AddCommunication(AddCommunicationRequestModel request, IDbConnection connection, IDbTransaction tran = null)
        {
            return await connection.ExecuteScalarAsync<int>(
                @"INSERT INTO communication( type_id
                                               ,communication_info)
                                                OUTPUT Inserted.ID
                                       VALUES(  @TypeId
                                               ,@CommunicationInfo)", request, transaction: tran);
        }

        public async Task UpdateCommunication(UpdateCommunicationRequestModel request, IDbConnection connection,
            IDbTransaction tran = null)
        {
            await connection.ExecuteAsync(
                @"UPDATE communication
                             SET type_id = @TypeId,
                                 communication_info = @CommunicationInfo
                             WHERE id = @Id",
                request, transaction: tran);
        }

        public async Task DeleteCommunication(DeleteCommunicationRequestModel request, IDbConnection connection,
            IDbTransaction transaction = null)
        {
            await connection.ExecuteScalarAsync(@"DELETE FROM communication WHERE id = @Id", request,
                transaction: transaction);
        }

        public async Task<GetCommunicationResponseModel> GetCommunication(GetCommunicationRequestModel request, IDbConnection connection)
        {
            return await connection.QuerySingleOrDefaultAsync<GetCommunicationResponseModel>(@"SELECT c.id, c.communication_info, ct.type FROM communication c
                                                                                              JOIN communication_type ct on c.type_id = ct.id
                                                                                              WHERE c.id = @Id",
                request);
        }
    }
}
