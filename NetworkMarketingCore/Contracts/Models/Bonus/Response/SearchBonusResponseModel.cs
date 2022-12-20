using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Bonus.Response
{
    public class SearchBonusResponseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float BonusAmount { get; set; }
    }
}
