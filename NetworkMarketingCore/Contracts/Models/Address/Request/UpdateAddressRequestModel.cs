using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Address.Request
{
    public class UpdateAddressRequestModel : AddAddressRequestModel
    {
        public int Id { get; set; }
    }
}
