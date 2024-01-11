using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Exo_Formulaire.Models
{
    public class AuthLoginForm
    {
        [DisplayName("Votre adresse e-mail :")]
        [Required(ErrorMessage = "L'adresse e-mail est nécessaire pour se connecter.")]
        [MinLength(5, ErrorMessage ="Une adresse est toujours composé de minimum 5 caractères")]
        [MaxLength(256, ErrorMessage ="Une adresse est toujours composé de maximum 256 caractères")]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Votre mot de passe :")]
        [Required(ErrorMessage = "Le mot de passe est nécessaire pour se connecter.")]
        [MinLength(8, ErrorMessage = "Un mot de passe efficace est composé de minimum 8 caractères")]
        [MaxLength(16, ErrorMessage = "Un mot de passe est composé de maximum 16 caractères")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
