using Microsoft.EntityFrameworkCore;
using Domain.Models;


namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Domain.Models.Data> Data { get; set; }
        public DbSet<Weather> Weather { get; set; }
        public DbSet<WeatherData> WeatherData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Models.Data>().HasKey(d => d.Id);
            modelBuilder.Entity<Weather>().HasKey(d => d.Id);
            modelBuilder.Entity<WeatherData>().HasKey(d => d.Id);

            modelBuilder.Entity<Domain.Models.Data>()
                .HasOne(d => d.WeatherData)
                .WithMany(w => w.DataList)
                .HasForeignKey(d => d.WeatherDataForeignKey);

            modelBuilder.Entity<Domain.Models.Data>()
                .HasOne(d => d.Weather)
                .WithOne(w => w.Db_Data)
                .HasForeignKey<Domain.Models.Data>(d => d.WeatherId);

            


            






        }
    }
}
