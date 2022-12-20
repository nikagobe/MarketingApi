using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Document.Request;
using NetworkMarketingCore.Contracts.Models.Document.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Services
{
    public interface IDocumentService
    {
        public Task<int> AddDocument(AddDocumentRequestModel request, IDbTransaction transaction = null);
        public Task UpdateDocument(UpdateDocumentRequestModel request, IDbTransaction transaction = null);
        public Task<GetDocumentResponseModel> GetDocument(GetDocumentRequestModel request);
        public Task DeleteDocument(DeleteDocumentRequestModel request, IDbTransaction transaction = null);

    }
}
