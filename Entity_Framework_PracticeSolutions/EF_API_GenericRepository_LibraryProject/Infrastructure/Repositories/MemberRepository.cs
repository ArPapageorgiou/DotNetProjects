using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly AppDbContext _appDbContext;

        public MemberRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddRentedBookToMember(int memberId)
        {
            var member = _appDbContext.members.FirstOrDefault(x => x.MemberId == memberId);
            if (member != null)
            {
                member.RentedBooks += 1;
                _appDbContext.SaveChanges();
            }
            else 
            {
                throw new ArgumentException("Member does not exist");
            }
        }

        public bool MemberHasMaxBooks(int memberId)
        {
            var member = _appDbContext.members.FirstOrDefault(x => x.MemberId == memberId);
            if (member != null)
            {
                return member.RentedBooks >= 2;
            }
            else 
            {
                throw new ArgumentException("Member does not exist");
            }
        }

        public void RemoveRentedBookFromMember(int memberId)
        {
            var member = _appDbContext.members.FirstOrDefault(x => x.MemberId == memberId);
            if (member != null)
            {
                member.RentedBooks -= 1;
                _appDbContext.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Member does not exist");
            }
        }
    }
}
