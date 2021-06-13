using Diginovasi.BusinessObjects.Masters;

namespace Diginovasi.BusinessObjects.Sales
{
    public class SalesOrderItem
    {
        public int Id { get; set; }
        public int Jumlah { get; set; }

        public int? SalesId { get; set; }
        public SalesOrder Sales { get; set; }

        public int? MaterialId { get; set; }
        public Material Material {get;set;}
    }
}
