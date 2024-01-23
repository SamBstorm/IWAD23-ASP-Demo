using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_DBSlide.Models
{
    public class SectionDetailsViewModel
    {
        [DisplayName("Identifiant")]
        public int Section_id { get; set; }
        [DisplayName("Nom")]
        public string? Section_name { get; set; }
        [ScaffoldColumn(false)]
        public int? Delegate_id { get; set; }
        [DisplayName("Nom de Famille")]
        public string? Delegate_Last_name { get; set; }
        [DisplayName("Prénom")]
        public string? Delegate_First_name { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<StudentListItemViewModel> Students { get; set; }
    }
}
