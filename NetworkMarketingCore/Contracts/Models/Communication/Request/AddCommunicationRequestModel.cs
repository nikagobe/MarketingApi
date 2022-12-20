using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Attributes;

namespace NetworkMarketingCore.Contracts.Models.Communication.Request
{
    public class AddCommunicationRequestModel
    {
        public int TypeId { get; set; }
        
        [RequiredField]
        public string CommunicationInfo { get; set; }
    }
}
