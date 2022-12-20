using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Bonus.Repository
{
    public class AddBonusRepositoryModel
    {
        public int DistributorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double BonusAmount { get; set; }
    }
}
