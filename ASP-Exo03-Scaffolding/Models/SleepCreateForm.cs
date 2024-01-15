using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Exo03_Scaffolding.Models
{
    public class SleepCreateForm
    {
        [DisplayName("Heure du couché")]
        [Required(ErrorMessage ="Heure du couché obligatoire")]
        [DataType("datetime-local")]
        public DateTime SleepStart { get; set; }
        [DisplayName("Heure de réveil")]
        [Required(ErrorMessage = "Heure de réveil obligatoire")]
        [DataType("datetime-local")]
        public DateTime SleepEnd { get; set; }
        [DisplayName("Avez-vous rêver ?")]
        public bool HaveDreamed { get; set; }
        [DisplayName("Était-ce un cauchemard ?")]
        public bool IsNightmare { get; set; }
        [DisplayName("Pouvez-vous le décrire ?")]
        [DataType(DataType.MultilineText)]
        [MaxLength(1024, ErrorMessage = "La description ne peut enregistrer plus de 1024 caractères")]
        public string? DreamDescription { get; set; }
        [DisplayName("Avez-vous ronflé ?")]
        public bool HaveSnored { get; set; }
    }
}
