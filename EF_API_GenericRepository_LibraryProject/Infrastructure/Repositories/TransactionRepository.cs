using Application.Interfaces;
using Infrastructure.Data;
using Domain.Models;


namespace Infrastructure.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly AppDbContext _appDbContext;

        public TransactionRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public bool HasMemberAlreadyRentedBook(int memberId, int bookId)
        {
            return _appDbContext.transactions.Any(t => t.MemberId == memberId && t.BookId == bookId && t.ReturnedAt == null);
            
        }

        public void UpdateTransaction(int memberId, int bookId)
        {
            var transaction = _appDbContext.transactions.FirstOrDefault(t => t.MemberId == memberId && t.BookId == bookId && t.ReturnedAt == null);
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

        public IEnumerable<Transaction> GetTransactions(int memberId, int bookId) 
        {
            var transactions = _appDbContext.transactions.Where(t => t.MemberId == memberId && t.BookId == bookId).ToList();
            return transactions;
        }

        public void CreateTransaction (int memberId, int bookId) 
        { 
            var transaction = new Transaction { MemberId = memberId, BookId = bookId };
            _appDbContext.transactions.Add(transaction);
            _appDbContext.SaveChanges();

        }

        public bool DoesOpenTransactionExist(int memberId, int bookId) 
        { 
            return _appDbContext.transactions.Any(t => t.MemberId == memberId && t.BookId == bookId && t.ReturnedAt == null);
        }



    }
}
