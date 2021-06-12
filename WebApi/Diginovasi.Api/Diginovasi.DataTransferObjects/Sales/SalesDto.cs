using System;

namespace Diginovasi.DataTransferObjects.Sales
{
    public class SalesDto
    {
        public int Id { get; set; }
        public string NoSalesOrder { get; set; }
        public DateTime Tanggal { get; set; }
        public string NoCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public decimal Total { get; set; }

    }
}
