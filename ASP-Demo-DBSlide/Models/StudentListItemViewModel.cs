using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Demo_DBSlide.Models
{
    public class StudentListItemViewModel
    {
        [ScaffoldColumn(false)]
        public int Student_id { get; set; }
        [DisplayName("Prénom")]
        public string First_name { get; set; }
        [DisplayName("Nom de famille")]
        public string Last_name { get; set; }
    }
}
