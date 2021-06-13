using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Diginovasi.Api.Models.Masters
{
    public class MaterialRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = GlobalConstants.FieldMandatory)]
        public string Kode { get; set; }
        public string Deskripsi { get; set; }
        public int SatuanId { get; set; }
        [Required(ErrorMessage = GlobalConstants.FieldMandatory)]
        public decimal Harga { get; set; }
        public IFormFile Gambar { get; set; }
        public string UrlGambar { get; set; }

    }
}
