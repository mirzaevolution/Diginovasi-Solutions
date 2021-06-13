using System.ComponentModel.DataAnnotations;

namespace Diginovasi.Api.Models.Masters
{
    public class SatuanRequest
    {

        public int Id { get; set; }
        [Required(ErrorMessage = GlobalConstants.FieldMandatory)]

        public string Kode { get; set; }
        [Required(ErrorMessage = GlobalConstants.FieldMandatory)]

        public string Deskripsi { get; set; }
    }
}
