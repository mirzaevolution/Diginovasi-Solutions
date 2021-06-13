namespace Diginovasi.DataTransferObjects.Sales
{
    public class SalesOrderItemDto
    {
        public int Id { get; set; }
        public int? SalesOrderId { get; set; }
        public string NoSalesOrder { get; set; }
        public int? MaterialId { get; set; }
        public string KodeMaterial { get; set; }
        public string DeskripsiMaterial { get; set; }
        public int Jumlah { get; set; }
        public string KodeSatuan { get; set; }
        public decimal Harga { get; set; }
        public decimal SubTotal { get; set; }
    }
}
