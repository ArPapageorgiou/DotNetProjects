using Domain.Models;

namespace Application.DTOs
{
    public class TransactionRequest
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }

    }
}
