namespace ASP_Exo03_Scaffolding.Models
{
    public class SleepModel
    {
        public int Id { get; set; }
        public DateTime SleepStart { get; set; }
        public DateTime SleepEnd { get; set; }
        public bool HaveDreamed { get; set; }
        public bool IsNightmare { get; set; }
        public string? DreamDescription { get; set; }
        public bool HaveSnored { get; set; }
    }
}
