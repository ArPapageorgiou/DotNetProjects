using Application.Interfaces;
using Domain.Models;

namespace Infrastructure.Repositories
{
    internal class MemberRepository : IMemberRepository
    {
        public void AddRentedBookToMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public void DeleteMember(int memberId)
        {
            throw new NotImplementedException();
        }

        public bool DoesMemberExistById(int memberId)
        {
            throw new NotImplementedException();
        }

        public Member GetMemberById(int memberId)
        {
            throw new NotImplementedException();
        }

        public void InsertNewMember(Member member)
        {
            throw new NotImplementedException();
        }

        public bool MemberHasMaxBooks(int memberId)
        {
            throw new NotImplementedException();
        }

        public void RemoveRentedBookFromMember(int memberId)
        {
            throw new NotImplementedException();
        }
    }
}
