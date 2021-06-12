using System;

namespace Diginovasi.DataTransferObjects.Masters
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Kode { get; set; }
        public string Deskripsi { get; set; }
        public string Satuan { get; set; }
        public decimal Price { get; set; }
        public string UrlGambar { get; set; }
    }
}
