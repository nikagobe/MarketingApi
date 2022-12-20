using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Bonus.Request
{
    public class SearchBonusRequestModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public float? MaxAmount { get; set; }
        public float? MinAmount { get; set; }
    }
}
