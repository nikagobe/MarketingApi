using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Distributor.Response
{
    public class GetReferredDistributorsResponseModel
    {
        public List<int> ReferredDistributorIds { get; set; }
    }
}
