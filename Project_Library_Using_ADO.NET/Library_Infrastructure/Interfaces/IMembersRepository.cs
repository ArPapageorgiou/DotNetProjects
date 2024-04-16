
﻿using Domain.Entities;
namespace Library_Application.Interfaces
{
    public interface IMembersRepository
    {

        bool DoesMemberExist(int memberId);
        bool DoesMemberExist(string fullName);
        bool MemberHasMaxBooks(int memberId);

        Members GetMember(int memberId);

        Members GetMember(string fullName);
        void InsertMember(Members members);
        void DeleteMember(int memberId);








    }
}
