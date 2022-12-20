using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Product.Response
{
    public class GetProductResponseModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

    }
}
