using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class RentalTransaction
    {
        public int RentalTransactionId { get; set; }
        public int MemberId {get; set;}
        public Member Member { get; set;}
        public int BookId { get; set;}
        public Book Book { get; set;}
        public DateTime RentedAt { get; set;}
        public DateTime? ReturnedAt { get; set; }
        
    }
}
