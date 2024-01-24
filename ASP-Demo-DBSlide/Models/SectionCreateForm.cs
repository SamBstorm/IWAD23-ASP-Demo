using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_DBSlide.Models
{
    public class SectionCreateForm
    {
        [DisplayName("Identifiant")]
        [Required(ErrorMessage ="L'identifiant est obligatoire")]
        [Range(1000,9999, ErrorMessage ="L'identifiant doit être compris entre 1000 et 9999")]
        public int Section_id { get; set; }
        [DisplayName("Nom de la section")]
        [MaxLength(50, ErrorMessage ="Le nom de la section ne doit pas excéder 50 caractères")]
        [MinLength(1, ErrorMessage ="Le nom de la section doit avoir au minimum 1 caractère")]
        public string? Section_name { get; set;}
        [DisplayName("Étudiant délégué")]
        public int? Delegate_id { get; set; }
    }
}
