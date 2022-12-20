using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Communication.Response
{
    public class GetCommunicationResponseModel
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string CommunicationInfo { get; set; }
    }
}
