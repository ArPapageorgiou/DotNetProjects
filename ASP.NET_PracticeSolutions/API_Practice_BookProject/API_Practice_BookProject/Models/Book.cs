namespace API_Practice_BookProject.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public bool isRented { get; set;}
    }
}
