using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Attributes;
using NetworkMarketingCore.Contracts.Models.Distributor.Request;

namespace NetworkMarketingCore.Contracts.Models.Distributor.Repository
{
    public class AddDistributorRepositoryModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int FileId { get; set; }
        public int DocumentId { get; set; }
        public int CommunicationId { get; set; }
        public int AddressId { get; set; }
        public int? ReferralId { get; set; }
        public int ReferralLevel { get; set; } = 0;

        public AddDistributorRepositoryModel(AddDistributorRequestModel req)
        {
            FirstName = req.FirstName;
            LastName = req.LastName;
            BirthDate = req.BirthDate;
            Gender = req.Gender;
            FileId = req.FileId;
            ReferralId = req.ReferralId;
        }
    }
}
