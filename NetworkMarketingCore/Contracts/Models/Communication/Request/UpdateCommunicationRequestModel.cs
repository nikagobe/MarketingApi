using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Communication.Request
{
    public class UpdateCommunicationRequestModel : AddCommunicationRequestModel
    {
        public int Id { get; set; }
    }
}
