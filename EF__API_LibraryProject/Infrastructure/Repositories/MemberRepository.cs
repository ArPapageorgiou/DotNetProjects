using Application.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    internal class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _appDbContext;

        public MemberRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddRentedBookToMember(int memberId)
        {
            var member = _appDbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
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

        public void DeleteMember(int memberId)
        {
            var member = _appDbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
            if (member != null)
            {
                _appDbContext.Members.Remove(member);
                _appDbContext.SaveChanges();
            }
            else 
            {
                throw new ArgumentException("Member does not exist");
            }
        }

        public bool DoesMemberExistById(int memberId)
        {
            return _appDbContext.Members.Any(m => m.MemberId == memberId);
        }

        public Member GetMemberById(int memberId)
        {
            return _appDbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
        }

        public void InsertNewMember(Member member)
        {
            _appDbContext.Members.Add(member);
            _appDbContext.SaveChanges();
        }

        public bool MemberHasMaxBooks(int memberId)
        {
            var member = _appDbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
            return member.RentedBooks >= 2;
        }

        public void RemoveRentedBookFromMember(int memberId)
        {
            var member = _appDbContext.Members.FirstOrDefault(m => m.MemberId == memberId);
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
