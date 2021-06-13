using System;
using System.Collections.Generic;

namespace Diginovasi.BusinessObjects.Masters
{
    public class Customer
    {
        public int Id { get; set; }
        public string NoCustomer { get; set; }
        public string Nama { get; set; }
        public string NoKontak { get; set; }
        public List<Sales.SalesOrder> SalesOrders { get; set; } = new List<Sales.SalesOrder>();
    }
}
