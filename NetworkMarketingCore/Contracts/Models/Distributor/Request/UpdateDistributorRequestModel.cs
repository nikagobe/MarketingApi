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
    public class UpdateDistributorRequestModel
    {
        public int Id { get; set; }
        [RequiredField]
        public string FirstName { get; set; }
        [RequiredField]
        public string LastName { get; set; }
        [RequiredField]
        public DateTime BirthDate { get; set; }
        [RequiredField]
        public string Gender { get; set; }
        public int FileId { get; set; }
        public UpdateDocumentRequestModel Document { get; set; }
        public UpdateCommunicationRequestModel Communication { get; set; }
        public UpdateAddressRequestModel Address { get; set; }
    }
}
