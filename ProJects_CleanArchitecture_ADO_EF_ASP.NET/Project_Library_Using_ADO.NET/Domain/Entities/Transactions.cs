using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transactions
    {
        public int TransactionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
        public DateTime RentedAt { get; set; }
        public DateTime ReturnedAt { get; set; }
    }
}
