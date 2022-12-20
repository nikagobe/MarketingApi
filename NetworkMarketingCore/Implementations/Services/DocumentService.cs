using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Interfaces.Repositories;
using NetworkMarketingCore.Contracts.Interfaces.Services;
using NetworkMarketingCore.Contracts.Models.Document.Request;
using NetworkMarketingCore.Contracts.Models.Document.Response;

namespace NetworkMarketingCore.Implementations.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _repository;
        private readonly IDbConnection _connection;
        public DocumentService(IDbConnection connection, IDocumentRepository repository)
        {
            _connection = connection;
            _repository = repository;
        }
        public async Task<int> AddDocument(AddDocumentRequestModel request, IDbTransaction? tran = null)
        {
            return await _repository.AddDocument(request, _connection, transaction: tran);
        }

        public async Task UpdateDocument(UpdateDocumentRequestModel request, IDbTransaction transaction = null)
        {
            await _repository.UpdateDocument(request, _connection, transaction);
        }

        public async Task<GetDocumentResponseModel> GetDocument(GetDocumentRequestModel request)
        {
            return await _repository.GetDocument(request, _connection);
        }

        public async Task DeleteDocument(DeleteDocumentRequestModel request, IDbTransaction transaction = null)
        {
            await _repository.DeleteDocument(request, _connection, transaction);
        }
    }
}
