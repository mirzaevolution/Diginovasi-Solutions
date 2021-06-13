using System;

namespace Diginovasi.DataTransferObjects.Masters
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Kode { get; set; }
        public string Deskripsi { get; set; }
        public string KodeSatuan { get; set; }
        public decimal Harga { get; set; }
        public string UrlGambar { get; set; }
    }
}
