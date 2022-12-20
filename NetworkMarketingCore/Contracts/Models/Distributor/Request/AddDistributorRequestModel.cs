using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Attributes;
using NetworkMarketingCore.Contracts.Models.Address.Request;
using NetworkMarketingCore.Contracts.Models.Communication.Request;
using NetworkMarketingCore.Contracts.Models.Document.Request;

namespace NetworkMarketingCore.Contracts.Models.Distributor.Request
{
    public class AddDistributorRequestModel
    {
        [RequiredField]
        public string FirstName { get; set; }
        [RequiredField]
        public string LastName { get; set; }
        [RequiredField]
        public DateTime BirthDate { get; set; }
        [RequiredField]
        public string Gender { get; set; }
        public int FileId { get; set; }
        public AddDocumentRequestModel Document { get; set; }
        public AddCommunicationRequestModel Communication { get; set; }
        public AddAddressRequestModel Address { get; set; }
        public int? ReferralId { get; set; }
    }
}
