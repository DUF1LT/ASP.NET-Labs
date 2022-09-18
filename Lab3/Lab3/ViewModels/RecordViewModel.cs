using System.ComponentModel.DataAnnotations;

namespace Lab3.ViewModels
{
    public class RecordViewModel
    {
        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }
    }
}