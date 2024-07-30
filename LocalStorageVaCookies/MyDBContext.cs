using LocalStorageVaCookies.Models;
using Microsoft.EntityFrameworkCore;

namespace LocalStorageVaCookies
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User(1, "Admin", "Admin"));
        }
    }
}
