
﻿using Domain.Models;

namespace Application.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        void AddRemoveBookCopy(int bookId, int copyChange);
        bool IsBookAvailable(int bookId);
        void AddAvailableCopies(int bookId);
        void RemoveAvailableCopies(int bookId);

    }
}
