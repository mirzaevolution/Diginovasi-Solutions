using System;
using System.Collections.Generic;
using System.Text;

namespace Diginovasi.BusinessObjects.Sales
{
    public class Sales
    {
        public int Id { get; set; }
        public string NoSalesOrder { get; set; }
        public DateTime Tanggal { get; set; }
        public int CustomerId { get; set; }
    }
}
