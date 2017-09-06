using System.ComponentModel.DataAnnotations;

namespace GoApiWorkshop.Models
{
    public class ContactModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
