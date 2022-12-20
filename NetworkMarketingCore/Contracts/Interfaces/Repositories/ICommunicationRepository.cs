using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Communication.Request;
using NetworkMarketingCore.Contracts.Models.Communication.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Repositories
{
    public interface ICommunicationRepository
    {
        public Task<int> AddCommunication(AddCommunicationRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        
        public Task UpdateCommunication(UpdateCommunicationRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task DeleteCommunication(DeleteCommunicationRequestModel request, IDbConnection connection, IDbTransaction transaction = null);
        public Task<GetCommunicationResponseModel> GetCommunication(GetCommunicationRequestModel request, IDbConnection connection);
    }
}
