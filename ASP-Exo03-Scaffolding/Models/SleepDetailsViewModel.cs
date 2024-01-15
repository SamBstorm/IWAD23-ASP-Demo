using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Exo03_Scaffolding.Models
{
    public class SleepDetailsViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Heure de couché")]
        [DataType("datetime-local")]
        public DateTime SleepStart { get; set; }
        [DisplayName("Heure du réveil")]
        [DataType("datetime-local")]
        public DateTime SleepEnd { get; set; }
        [DisplayName("Durée")]
        [DataType(DataType.Duration)]
        public TimeSpan Duration
        {
            get => SleepEnd - SleepStart;
        }
        [DisplayName("Avoir rêver")]
        public bool HaveDreamed { get; set; }
        [DisplayName("S'agit-il d'un cauchemard")]
        public bool IsNightmare { get; set; }
        [DisplayName("Description du rêve")]
        [DataType(DataType.MultilineText)]
        public string? DreamDescription { get; set; }
        [DisplayName("Ronflements")]
        public bool HaveSnored { get; set; }
    }
}
