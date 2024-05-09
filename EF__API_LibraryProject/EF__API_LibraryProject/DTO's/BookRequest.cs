using Domain.Models;

namespace EF_API_LibraryProject.DTO_s
{
    public class BookRequest
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
      
    }
}
