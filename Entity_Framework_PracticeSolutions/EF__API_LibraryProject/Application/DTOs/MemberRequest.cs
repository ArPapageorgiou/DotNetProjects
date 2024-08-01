using System.ComponentModel.DataAnnotations;

namespace EF_API_LibraryProject.DTOs
{
    public class MemberRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        
    }
}
