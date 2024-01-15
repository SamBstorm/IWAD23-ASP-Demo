using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Exo03_Scaffolding.Models
{
    public class SleepListItemViewModel
    {
        [DisplayName("Identifiant")]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Date d'enregistrement")]
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; }
        [DisplayName("Durée")]
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }
        [DisplayName("Avoir rêvé/cauchemardé")]
        public bool HaveDreamed { get; set; }
    }
}
