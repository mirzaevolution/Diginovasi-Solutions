using Diginovasi.BusinessObjects.Sales;
using System;
using System.Collections.Generic;

namespace Diginovasi.BusinessObjects.Masters
{
    public class Material
    {
        public int Id { get; set; }
        public string Kode { get; set; }
        public string Deskripsi { get; set; }
        public decimal Harga { get; set; }
        public string UrlGambar { get; set; }
        public int? SatuanId { get; set; }
        public Satuan Satuan { get; set; }
        public List<SalesOrderItem> SalesOrderItems { get; set; } = new List<SalesOrderItem>();
    }
}
