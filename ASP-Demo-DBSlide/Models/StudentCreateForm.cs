using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_DBSlide.Models
{
    public class StudentCreateForm
    {
        [DisplayName("Prénom")]
        [Required(ErrorMessage ="Le prénom est obligatoire.")]
        [MaxLength(50, ErrorMessage ="Le prénom ne peut dépasser 50 caractères.")]
        [MinLength(2, ErrorMessage ="Le prénom doit avoir au minimum 2 caractères.")]
        public string First_name {  get; set; }
        [DisplayName("Nom de famille")]
        [Required(ErrorMessage = "Le nom est obligatoire.")]
        [MaxLength(50, ErrorMessage = "Le nom ne peut dépasser 50 caractères.")]
        [MinLength(2, ErrorMessage = "Le nom doit avoir au minimum 2 caractères.")]
        public string Last_name { get; set;}
        [DisplayName("Date de naissance")]
        [Required(ErrorMessage ="La date de naissance est obligatoire.")]
        [DataType(DataType.Date)]
        public DateTime Birth_date { get; set; }
        [DisplayName("Section")]
        [Required(ErrorMessage ="Une section doit être choisie.")]
        public int Section_id { get; set; }
    }
}
