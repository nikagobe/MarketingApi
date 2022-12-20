using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Address.Response
{
    public class GetAddressResponseModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
}
