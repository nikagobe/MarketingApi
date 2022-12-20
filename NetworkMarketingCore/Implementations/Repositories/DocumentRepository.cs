using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Models.Document.Request;
using NetworkMarketingCore.Contracts.Models.Document.Response;

namespace NetworkMarketingCore.Implementations.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        public async Task<int> AddDocument(AddDocumentRequestModel request, IDbConnection connection, IDbTransaction? tran = null)
        {
            return await connection.ExecuteScalarAsync<int>(
                @"INSERT INTO documents( type_id
                                               ,serial
                                               ,document_number
                                               ,date_of_issue
                                               ,date_of_expiration
                                               ,personal_number
                                               ,issued_by)
                                                OUTPUT Inserted.ID
                                       VALUES(  @TypeId
                                               ,@Serial
                                               ,@DocumentNumber
                                               ,@DateOfIssue
                                               ,@DateOfExpiration
                                               ,@PersonalNumber
                                               ,@IssuedBy)", request, transaction: tran);
        }

        public async Task UpdateDocument(UpdateDocumentRequestModel request, IDbConnection connection,
            IDbTransaction tran = null)
        {
            await connection.ExecuteAsync(
                @"UPDATE documents
                             SET type_id = @TypeId, 
                                 serial = @Serial, 
                                 document_number = @DocumentNumber, 
                                 date_of_issue = @DateOfIssue, 
                                 date_of_expiration = @DateOfExpiration, 
                                 personal_number = @PersonalNumber, 
                                 issued_by = @IssuedBy
                             WHERE id = @Id",
                request, transaction: tran);
        }

        public async Task DeleteDocument(DeleteDocumentRequestModel request, IDbConnection connection, IDbTransaction tran = null)
        {
            await connection.ExecuteAsync(@"DELETE FROM documents WHERE id = @Id", request,
                transaction: tran);
        }

        public async Task<GetDocumentResponseModel> GetDocument(GetDocumentRequestModel request, IDbConnection connection)
        {
            return await connection.QuerySingleOrDefaultAsync<GetDocumentResponseModel>(@"SELECT d.id,
                                                                                                     d.serial
                                                                                                    ,d.document_number
                                                                                                    ,d.date_of_issue
                                                                                                    ,d.date_of_expiration
                                                                                                    ,d.personal_number
                                                                                                    ,d.issued_by
                                                                                                    ,dt.type_name FROM documents d
                                                                                              JOIN document_type dt on d.type_id = dt.id
                                                                                              WHERE d.id = @Id",
                request);
        }
    }
}
