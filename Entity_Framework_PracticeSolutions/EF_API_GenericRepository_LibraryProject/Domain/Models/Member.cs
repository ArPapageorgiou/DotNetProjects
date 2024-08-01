namespace Domain.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int RentedBooks { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
