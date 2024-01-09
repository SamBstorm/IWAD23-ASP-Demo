namespace Demo02.Models
{
    public class ArticleModel
    {
        public string Titre { get;set; }
        public List<string> Paragraphes { get; set; } = new List<string>();
        public string ImageURL { get; set; }
        public string Auteur { get; set; }
    }
}
