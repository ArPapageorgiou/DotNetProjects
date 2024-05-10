using System.ComponentModel.DataAnnotations;

namespace EF_API_LibraryProject.DTOs
{
    public class BookRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int TotalCopies { get; set; }
        
    }
}
