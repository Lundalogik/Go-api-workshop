using System.ComponentModel.DataAnnotations;

namespace GoApiWorkshop.Models
{
    public class ContactModel
    {
        [Required]
        public string CompanyName { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
