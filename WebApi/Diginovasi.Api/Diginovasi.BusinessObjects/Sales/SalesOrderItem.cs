using Diginovasi.BusinessObjects.Masters;

namespace Diginovasi.BusinessObjects.Sales
{
    public class SalesOrderItem
    {
        public int Id { get; set; }
        public string KodeMaterial { get; set; }
        public int Jumlah { get; set; }

        public int SalesId { get; set; }
        public virtual SalesOrder Sales { get; set; }

        public int? MaterialId { get; set; }
        public virtual Material Material {get;set;}
    }
}
