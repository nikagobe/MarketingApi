using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Attributes;

namespace NetworkMarketingCore.Contracts.Models.Sale.Request
{
    public class AddSaleRequestModel
    {
        public int DistributorId { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
