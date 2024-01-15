using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Exo03_Scaffolding.Models
{
    public class SleepEditForm
    {
        [DisplayName("Identifiant")]
        [HiddenInput]
        [Required(ErrorMessage = "L'identifiant est obligatoire")]
        public int Id { get; set; }
        [DisplayName("Avez-vous rêver ?")]
        public bool HaveDreamed { get; set; }
        [DisplayName("Était-ce un cauchemard ?")]
        public bool IsNightmare { get; set; }
        [DisplayName("Pouvez-vous le décrire ?")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1024, ErrorMessage = "La description ne peut enregistrer plus de 1024 caractères")]
        public string? DreamDescription { get; set; }
    }
}
