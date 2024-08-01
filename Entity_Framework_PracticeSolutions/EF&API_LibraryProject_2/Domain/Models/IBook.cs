namespace Domain.Models
{
    public interface IBook
    {
        int AvailableCopies { get; set; }
        int BookId { get; set; }
        string Description { get; set; }
        string Genre { get; set; }
        string Title { get; set; }
        int TotalCopies { get; set; }
    }
}