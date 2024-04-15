
﻿using Domain.Entities;
namespace Library_Infrastructure.Interfaces
{
    public interface IMembersRepository
    {
        bool DoesMemberExist(int memberId);
        bool DoesMemberExist(string fullName);
        bool MemberHasMaxBooks(int memberId);
        Members GetMember(int id);
        Members GetMember(string fullName);
        void InsertMember(Members members);
        void DeleteMember(int memberId);






    }
}
