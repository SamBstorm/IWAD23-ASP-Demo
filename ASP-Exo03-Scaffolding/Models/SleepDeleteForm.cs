using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_Exo03_Scaffolding.Models
{
    public class SleepDeleteForm
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Heure du couché")]
        [DataType("datetime-local")]
        public DateTime SleepStart { get; set; }
    }
}
