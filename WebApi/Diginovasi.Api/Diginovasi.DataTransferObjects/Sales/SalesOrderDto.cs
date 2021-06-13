using System;

namespace Diginovasi.DataTransferObjects.Sales
{
    public class SalesOrderDto
    {
        public int Id { get; set; }
        public string NoSalesOrder { get; set; }
        public DateTime Tanggal { get; set; }
        public int CustomerId { get; set; }
        public string NoCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public decimal Total { get; set; }
        public TanggalStructDto TanggalStruct { get; set; }

    }
    public class TanggalStructDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
    }
}
