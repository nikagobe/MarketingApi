﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkMarketingCore.Contracts.Models.Product.Request
{
    public class AddProductRequestModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
