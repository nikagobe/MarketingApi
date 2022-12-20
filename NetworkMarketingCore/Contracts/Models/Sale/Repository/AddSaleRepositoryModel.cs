using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkMarketingCore.Contracts.Models.Sale.Request;

namespace NetworkMarketingCore.Contracts.Models.Sale.Repository
{
    public class AddSaleRepositoryModel : AddSaleRequestModel
    {
        public Guid SaleCode { get; set; }
        public float Total { get; set; }

        public AddSaleRepositoryModel(AddSaleRequestModel req)
        {
            DistributorId = req.DistributorId;
            SaleDate = req.SaleDate;
            Quantity = req.Quantity;
            ProductId = req.ProductId;
        }
    }

}
