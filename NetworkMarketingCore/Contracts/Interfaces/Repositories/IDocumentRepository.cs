using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Document.Request;
using NetworkMarketingCore.Contracts.Models.Document.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Repositories
{
    public interface IDocumentRepository
    {
        public Task<int> AddDocument(AddDocumentRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task UpdateDocument(UpdateDocumentRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task DeleteDocument(DeleteDocumentRequestModel request, IDbConnection connection, IDbTransaction transaction = null);

        public Task<GetDocumentResponseModel> GetDocument(GetDocumentRequestModel request, IDbConnection connection);
    }
}
