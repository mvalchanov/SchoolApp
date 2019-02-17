namespace SchoolApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Models;


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>()
                .HasKey(k => new { k.UserId, k.GroupId });

            modelBuilder.Entity<UserGroup>()
                .HasOne(u => u.User)
                .WithMany(g => g.Groups);

            modelBuilder.Entity<UserGroup>()
                .HasOne(g => g.Group)
                .WithMany(u => u.Users); 
        }
    }
}
