﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diginovasi.Api.Models.Sales
{
    public class SalesOrderRequest
    {
        public int Id { get; set; }
        public string NoSalesOrder { get; set; }
        public DateTime Tanggal { get; set; }
        public int CustomerId { get; set; }
        public string NoCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public decimal Total { get; set; }
    }
}
