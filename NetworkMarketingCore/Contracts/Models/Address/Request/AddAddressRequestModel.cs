using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Attributes;

namespace NetworkMarketingCore.Contracts.Models.Address.Request
{
    public class AddAddressRequestModel
    {
        public int TypeId { get; set; }
        [RequiredField]
        public string Address { get; set; }
    }
}
