using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Sale.Request
{
    public class GetSalesToCalculateBonusRequestModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int DistributorId { get; set; }
    }
}
