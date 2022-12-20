using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Sale.Response
{
    public class GetSaleResponseModel
    {
        public int Id { get; set; }
        public Guid SaleCode { get; set; }
        public int DistributorId { get; set; }
        public DateTime SaleDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public float Total { get; set; }

    }
}
