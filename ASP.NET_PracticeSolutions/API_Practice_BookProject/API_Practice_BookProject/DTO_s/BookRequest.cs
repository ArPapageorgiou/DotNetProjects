using System.ComponentModel.DataAnnotations;

namespace API_Practice_BookProject.DTO_s
{
    public class BookRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
