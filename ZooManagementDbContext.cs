using Microsoft.EntityFrameworkCore;
using ZooManagement.Models.Database;

namespace ZooManagement
{
    public class ZooManagementDbContext : DbContext
    {
        public ZooManagementDbContext(DbContextOptions<ZooManagementDbContext> options) : base(options) {}
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }
        public DbSet<Animal> Animals { get; set; }

    }
}