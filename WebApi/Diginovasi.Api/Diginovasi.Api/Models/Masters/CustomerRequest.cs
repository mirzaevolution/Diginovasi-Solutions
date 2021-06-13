using System.ComponentModel.DataAnnotations;

namespace Diginovasi.Api.Models.Masters
{
    public class CustomerRequest
    {
        public int Id { get; set; }
        public string NoCustomer { get; set; }
        [Required(ErrorMessage = GlobalConstants.FieldMandatory)]
        public string Nama { get; set; }
        [Required(ErrorMessage = GlobalConstants.FieldMandatory)]
        public string NoKontak { get; set; }
    }
}
