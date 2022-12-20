using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Bonus.Response
{
    public class CalculateBonusResponseModel
    {
        public int DistributorId { get; set; }
        public double BonusAmount { get; set; }
    }
}
