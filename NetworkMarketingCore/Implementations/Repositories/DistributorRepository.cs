using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Models.Distributor.Repository;
using NetworkMarketingCore.Contracts.Models.Distributor.Request;
using NetworkMarketingCore.Contracts.Models.Distributor.Response;

namespace NetworkMarketingCore.Implementations.Repositories
{
    public class DistributorRepository : IDistributorRepository
    {
        public async Task<List<GetDistributorRepositoryModel>> GetDistributors(IDbConnection connection)
        {
            var result = await connection.QueryAsync<GetDistributorRepositoryModel>("SELECT * FROM distributors");
            return result.ToList();
        }

        public async Task<GetDistributorRepositoryModel> GetDistributor(GetDistributorRequestModel request,
            IDbConnection connection)
        {
            var result =
                await connection.QuerySingleOrDefaultAsync<GetDistributorRepositoryModel>(
                    @"SELECT * FROM distributors WHERE id = @Id", request);
            return result;
        }

        public async Task<int> AddDistributor(AddDistributorRepositoryModel request, IDbConnection connection, IDbTransaction? tran = null)
        {
            return await connection.ExecuteScalarAsync<int>(
                @"INSERT INTO distributors(first_name,
                                              last_name ,
                                              birth_date ,
                                              gender ,
                                              file_id ,
                                              document_id,
                                              contact_info_id ,
                                              address_id ,
                                              referral_id,
                                              referral_level)
                                              OUTPUT Inserted.ID
                                    VALUES (@FirstName,
                                            @LastName,
                                            @BirthDate,
                                            @Gender,
                                            @FileId,
                                            @DocumentId,
                                            @CommunicationId,
                                            @AddressId,
                                            @ReferralId,
                                            @ReferralLevel)", request, transaction: tran);
        }

        public async Task<List<int>> GetReferredDistributors(GetReferredDistributorsRequestModel request, IDbConnection connection)
        {
            var result =
                await connection.QueryAsync<int>(
                    @"SELECT id FROM distributors WHERE referral_id = @ReferralId", request);
            return result.ToList();
        }

        public async Task UpdateDistributor(UpdateDistributorRequestModel request, IDbConnection connection,
            IDbTransaction tran = null)
        {
            await connection.ExecuteAsync(
                @"UPDATE distributors   
                                      SET   first_name  =  @FirstName,
                                            last_name   =  @LastName,
                                            birth_date  =  @BirthDate,
                                            gender      =  @Gender,
                                            file_id     =  @FileId

                             WHERE id = @Id",             
                request, transaction: tran);
        }

        public async Task DeleteDistributor(DeleteDistributorRequestModel request, IDbConnection connection,
            IDbTransaction transaction = null)
        {
            await connection.ExecuteScalarAsync(@"DELETE FROM distributors WHERE id = @Id", request,
                transaction: transaction);
        }
    }
}
