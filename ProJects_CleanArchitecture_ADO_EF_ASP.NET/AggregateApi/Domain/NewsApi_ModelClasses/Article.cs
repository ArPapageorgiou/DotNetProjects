namespace Domain.NewsApi_ModelClasses
{
    public class Article
    {
        public Source Source { get; set; }
        public string Author { get; set; } // This can be null
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; } // This can be null
        public DateTime PublishedAt { get; set; } // Ideally use DateTime for dates
        public string Content { get; set; }
    }
}
