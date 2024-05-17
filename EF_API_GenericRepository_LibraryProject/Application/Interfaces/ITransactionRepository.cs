
﻿using Domain.Models;

namespace Application.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        bool HasMemberAlreadyRentedBook(int memberId, int bookId);
        void UpdateTransaction(int memberId, int bookId);
        void CreateTransaction(int memberId, int bookId);

        bool DoesTransactionExist(int memberId, int bookId);
        

    }
}
