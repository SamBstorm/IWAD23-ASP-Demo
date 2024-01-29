using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_Session.Models
{
    public class AuthLoginForm
    {
        [DisplayName("Adresse e-mail")]
        [Required(ErrorMessage ="L'adresse email est requise.")]
        [EmailAddress(ErrorMessage ="L'adresse email ne correspond pas au format.")]
        [MaxLength(320,ErrorMessage ="L'adresse email ne peut excéder 320 caractères.")]
        [MinLength(5,ErrorMessage ="L'adresse email doit avoir au minimum 5 caractères.")]
        public string Email { get; set; }
        [DisplayName("Mot de passe")]
        [Required(ErrorMessage ="Le mot de passe est requis.")]
        [MaxLength(32, ErrorMessage = "Le mot de passe ne peut excéder 32 caractères.")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit avoir au minimum 8 caractères.")]
        [RegularExpression(@"^.*(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[-=\\\/\.@#!+]).*$",ErrorMessage ="Le mot de passe n'est pas assez complèxe.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
