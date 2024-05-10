using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    internal class RentalTransactionRepository : IRentalTransaction
    {
        private readonly AppDbContext _appDbContext;

        public RentalTransactionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public RentalTransaction GetTransaction(RentalTransaction rentalTransaction) 
        {
            return _appDbContext.RentalTransactions.FirstOrDefault(r => r.RentalTransactionId == rentalTransaction.RentalTransactionId);
        }

        public void CreateTransaction(int memberId, int bookId)
        {
            var transaction = new RentalTransaction { MemberId = memberId, BookId = bookId };
            _appDbContext.RentalTransactions.Add(transaction);
            _appDbContext.SaveChanges();
        }

        public bool DoesTransactionExist(int memberId, int bookId)
        {
            return _appDbContext.RentalTransactions.Any(r => r.MemberId == memberId && r.BookId == bookId && r.ReturnedAt != null);
        }

        public bool HasMemberAlreadyRentedBook(int memberId, int bookId)
        {
            return _appDbContext.RentalTransactions.Any(r => r.MemberId == memberId && r.BookId == bookId && r.ReturnedAt == null);
        }

        public void UpdateTransaction(int memberId, int bookId)
        {
            var transaction = _appDbContext.RentalTransactions.FirstOrDefault(r => r.MemberId == memberId && r.BookId == bookId && r.ReturnedAt == null); 
            if (transaction != null) 
            { 
             transaction.ReturnedAt = DateTime.Now;
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Transaction does not exist");
            }
        }
    }
}
