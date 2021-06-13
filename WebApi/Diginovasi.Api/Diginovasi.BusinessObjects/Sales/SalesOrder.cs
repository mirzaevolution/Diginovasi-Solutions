using Diginovasi.BusinessObjects.Masters;
using System;
using System.Collections.Generic;

namespace Diginovasi.BusinessObjects.Sales
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public string NoSalesOrder { get; set; }
        public DateTime Tanggal { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();

    }
}
