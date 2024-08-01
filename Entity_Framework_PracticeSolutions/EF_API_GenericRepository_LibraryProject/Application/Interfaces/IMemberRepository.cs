
﻿using Domain.Models;

namespace Application.Interfaces
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        bool MemberHasMaxBooks(int memberId);
        void AddRentedBookToMember(int memberId);
        void RemoveRentedBookFromMember(int memberId);

    }
}
