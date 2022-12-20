using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Communication.Request;
using NetworkMarketingCore.Contracts.Models.Communication.Response;

namespace NetworkMarketingCore.Contracts.Interfaces.Services
{
    public interface ICommunicationService
    {
        public Task<int> AddCommunication(AddCommunicationRequestModel request, IDbTransaction transaction = null);
        public Task UpdateCommunication(UpdateCommunicationRequestModel request, IDbTransaction transaction = null);
        public Task DeleteCommunication(DeleteCommunicationRequestModel request, IDbTransaction transaction = null);

        public Task<GetCommunicationResponseModel> GetCommunication(GetCommunicationRequestModel request);
    }
}
