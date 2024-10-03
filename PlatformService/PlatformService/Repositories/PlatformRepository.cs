using PlatformService.Data;
using PlatformService.Interfaces;
using PlatformService.Models;

namespace PlatformService.Repositories
{
    public class PlatformRepository : IPlatformRepository
    {
        
        private readonly AppDbContext _appDbContext;

        public PlatformRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreatePlatform(Platform platform)
        {
            if(platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _appDbContext.Add(platform);
            _appDbContext.SaveChanges();
        }

        public Platform GetPlatformById(int Id)
        {
            return _appDbContext.Platforms.FirstOrDefault(p => p.Id == Id);
        }

        public IEnumerable<Platform> GetPlatforms()
        {
            return _appDbContext.Platforms.ToList();
        }

        public bool SaveChanges()
        {
            return (_appDbContext.SaveChanges() >= 0);
        }
    }
}
