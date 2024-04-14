
﻿using Domain.Entities;
namespace Library_Infrastructure.Interfaces
{
    internal interface IMembersRepository
    {
        IEnumerable<Members> GetAllMembers();
        Members GetMemberById(int id);

        



    }
}
