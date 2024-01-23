using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_DBSlide.Models
{
    public class StudentChangeSectionForm
    {
        [HiddenInput]
        [Required]
        public int Student_id { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Prénom")]
        public string? First_name { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Nom de famille")]
        public string? Last_name { get; set; }
        [Required]
        [DisplayName("Veuillez choisir votre nouvelle section:")]
        public int Section_id { get; set; }
    }
}
