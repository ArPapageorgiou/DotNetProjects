namespace Domain.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
