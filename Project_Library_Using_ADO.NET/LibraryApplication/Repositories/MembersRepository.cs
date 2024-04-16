using Domain.Entities;
using Library_Application.Interfaces;
using Microsoft.Data.SqlClient;

namespace Library_Infrastructure.Repositories
{
    public class MembersRepository : Base_Repository, IMembersRepository
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public MembersRepository(DatabaseConfiguration databaseConfiguration) : base(databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }

        public bool DoesMemberExist(int memberId) { }
        public bool DoesMemberExist(string fullName) { }
        public bool MemberHasMaxBooks(int memberId) { }
        public Members GetMember(int memberid) { }
        public Members GetMember(string fullName) { }
        public void InsertMember(Members members) { }
        public void DeleteMember(int memberId) { }
    }
}
