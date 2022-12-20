using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Attributes;

namespace NetworkMarketingCore.Contracts.Models.Document.Request
{
    public class AddDocumentRequestModel
    {
        
        [RequiredField]
        public int TypeId {get; set;}

        public string? Serial {get; set;}
        public string? DocumentNumber {get; set;}
        [RequiredField]
        public DateTime DateOfIssue {get; set;}
        [RequiredField]
        public DateTime DateOfExpiration {get; set;}
        [RequiredField]
        public string PersonalNumber {get; set;}
        public string? IssuedBy { get; set; }
    }
}
