namespace Diginovasi.DataTransferObjects.Sales
{
    public class SalesOrderItemDto
    {
        public int Id { get; set; }
        public string KodeMaterial { get; set; }
        public string DeskripsiMaterial { get; set; }
        public int Jumlah { get; set; }
        public string Satuan { get; set; }
        public decimal Harga { get; set; }
        public decimal SubTotal { get; set; }
    }
}
