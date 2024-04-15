using Domain.Entities;
namespace Library_Infrastructure.Interfaces
{
    public interface IMembersRepository
    {
        bool DoesMemberExist(int memberId);//
        bool MemberHasMaxBooks(int memberId);//
        IEnumerable<Members> GetAllMembers();
        Members GetMember(int id);//
        Members GetMember(string fullName);//
        void InsertMember(Members members);//
        void DeleteMember(int memberId);//





    }
}
