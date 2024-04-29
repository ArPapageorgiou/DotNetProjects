using Domain.Models;

namespace Application.Interfaces
{
    internal interface IRentalTransaction
    {
        void CreateTransaction(int memberId, int bookId);
        bool DoesTransactionExist(int memberId, int bookId);
        void UpdateTransaction(int memberId, int bookId);
        bool HasMemberAlreadyRentedBook(int memberId, int bookId);
    }
}
