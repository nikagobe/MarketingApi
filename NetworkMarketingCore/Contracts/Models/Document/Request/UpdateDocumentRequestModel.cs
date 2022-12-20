using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Document.Request
{
    public class UpdateDocumentRequestModel : AddDocumentRequestModel
    {
        public int Id { get; set; }
    }
}
