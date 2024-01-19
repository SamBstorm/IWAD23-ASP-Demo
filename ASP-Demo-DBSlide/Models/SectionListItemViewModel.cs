using System.ComponentModel;

namespace ASP_Demo_DBSlide.Models
{
    public class SectionListItemViewModel
    {
        [DisplayName("Identifiant")]
        public int Section_id { get; set; }
        [DisplayName("Section")]
        public string? Section_name { get; set; }
    }
}
