using Domain.Entities;

namespace Library_Application.Interfaces
{
    public interface ITransactionsRepository
    {

        void CreateTransaction(int memberId, int BookId);
        bool DoesTransactionExist(int memberId, int BookId);
        void UpdateTransaction(int memberId, int bookId);
        bool HasMemberAlreadyRentedBook(int memberId, int bookId);

    }
}
