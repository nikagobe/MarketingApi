using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Document.Response
{
    public class GetDocumentResponseModel
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string? Serial { get; set; }
        public string? DocumentNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public string PersonalNumber { get; set; }
        public string? IssuedBy { get; set; }
    }
}
