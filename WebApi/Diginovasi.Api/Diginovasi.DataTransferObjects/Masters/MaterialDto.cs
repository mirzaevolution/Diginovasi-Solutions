using System;

namespace Diginovasi.DataTransferObjects.Masters
{
    public class MaterialDto
    {
        public int Id { get; set; }
        public string Kode { get; set; }
        public string Deskripsi { get; set; }
        public int SatuanId { get; set; }
        public decimal Harga { get; set; }
        public string UrlGambar { get; set; }
        public string FormattedUrlGambar { get; set; }
    }
}
