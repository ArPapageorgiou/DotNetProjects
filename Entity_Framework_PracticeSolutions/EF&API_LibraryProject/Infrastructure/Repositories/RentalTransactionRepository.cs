using Application.Interfaces;

namespace Infrastructure.Repositories
{
    internal class RentalTransactionRepository : IRentalTransaction
    {
        public void CreateTransaction(int memberId, int bookId)
        {
            throw new NotImplementedException();
        }

        public bool DoesTransactionExist(int memberId, int bookId)
        {
            throw new NotImplementedException();
        }

        public bool HasMemberAlreadyRentedBook(int memberId, int bookId)
        {
            throw new NotImplementedException();
        }

        public void UpdateTransaction(int memberId, int bookId)
        {
            throw new NotImplementedException();
        }
    }
}
