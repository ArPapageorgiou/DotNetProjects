using Domain.Models;

namespace Application.Interfaces
{
    internal interface IMemberRepository
    {
        bool DoesMemberExistById(int memberId);
        Member GetMemberById(int memberId);
        void InsertNewMember(Member member);
        bool MemberHasMaxBooks(int memberId);
        void AddRentedBookToMember(int memberId);
        void RemoveRentedBookFromMember(int memberId);
        void DeleteMember(int memberId);



    }
}
