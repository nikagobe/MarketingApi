using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Address.Request;
using NetworkMarketingCore.Contracts.Models.Address.Response;
using NetworkMarketingCore.Contracts.Models.Communication.Request;
using NetworkMarketingCore.Contracts.Models.Communication.Response;
using NetworkMarketingCore.Contracts.Models.Distributor.Repository;
using NetworkMarketingCore.Contracts.Models.Document.Request;
using NetworkMarketingCore.Contracts.Models.Document.Response;

namespace NetworkMarketingCore.Contracts.Models.Distributor.Response
{
    public class GetDistributorResponseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int FileId { get; set; }
        public GetDocumentResponseModel Document { get; set; }
        public GetCommunicationResponseModel Communication { get; set; }
        public GetAddressResponseModel Address { get; set; }
        public int ReferralId { get; set; }
        public int ReferralLevel { get; set; }

        public GetDistributorResponseModel(GetDistributorRepositoryModel rep)
        {
            Id = rep.Id;
            FirstName = rep.FirstName;
            LastName = rep.LastName;
            BirthDate = rep.BirthDate;
            Gender = rep.Gender;
            FileId = rep.FileId;
            ReferralId = rep.ReferralId;
            ReferralLevel = rep.ReferralLevel;
        }
    }


}