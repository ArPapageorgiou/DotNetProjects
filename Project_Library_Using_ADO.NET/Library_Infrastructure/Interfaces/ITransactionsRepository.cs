﻿using Domain.Entities;

namespace Library_Infrastructure.Interfaces
{
    public interface ITransactionsRepository
    {
        void CreateTransaction(int memberId, int BookId);//
        void DoesTransactionExist(int transactionId);//
        Transactions GetTransaction(int memberId, int bookId);//
        void UpdateTransaction(Transactions transaction);//
    }
}
