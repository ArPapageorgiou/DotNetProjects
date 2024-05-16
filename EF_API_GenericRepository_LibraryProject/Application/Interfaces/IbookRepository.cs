
﻿using Domain.Models;

namespace Application.Interfaces
{
    public interface IbookRepository : IGenericRepository<Book>
    {
        void AddRemoveBookCopy(int bookId, int copyChange);
        bool IsBookAvailable(int bookId);
        void AddAvailableCopies(int bookId);
        void RemoveAvailableCopies(int bookId);

    }
}
