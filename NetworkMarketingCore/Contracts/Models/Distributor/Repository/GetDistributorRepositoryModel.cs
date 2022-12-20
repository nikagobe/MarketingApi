using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Distributor.Repository
{
    public class GetDistributorRepositoryModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public int FileId { get; set; }
        public int DocumentId { get; set; }
        public int ContactInfoId { get; set; }
        public int AddressId { get; set; }
        public int ReferralId { get; set; }
        public int ReferralLevel { get; set; }
    }
}
