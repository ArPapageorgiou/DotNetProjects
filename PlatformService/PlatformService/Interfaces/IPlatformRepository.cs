using PlatformService.Models;

namespace PlatformService.Interfaces
{
    public interface IPlatformRepository
    {
        bool SaveChanges();

        IEnumerable<Platform> GetPlatforms();

        Platform GetPlatformById(int Id);

        void CreatePlatform(Platform platform);
    }
}
