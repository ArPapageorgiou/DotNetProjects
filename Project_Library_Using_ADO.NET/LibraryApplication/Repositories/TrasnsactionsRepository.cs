using Domain.Entities;
using Library_Application.Interfaces;

namespace Library_Infrastructure.Repositories
{
    public class TrasnsactionsRepository : Base_Repository, ITransactionsRepository
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public TrasnsactionsRepository(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }

        public void CreateTransaction(int memberId, int BookId);
        public void DoesTransactionExist(int transactionId);
        public Transactions GetTransaction(int memberId, int bookId);
        public void UpdateTransaction(Transactions transaction);//it looks like i have to think this one through
    }
}
