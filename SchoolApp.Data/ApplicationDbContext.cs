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

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudents>()
                .HasKey(k => new { k.StudentID, k.CourseID });

            modelBuilder.Entity<CourseStudents>()
                .HasOne(u => u.Course)
                .WithMany(g => g.Students)
                .HasForeignKey(fk => fk.CourseID);

            modelBuilder.Entity<CourseStudents>()
                .HasOne(g => g.Student)
                .WithMany(u => u.Courses)
                .HasForeignKey(fk => fk.StudentID);

            modelBuilder.Entity<Teacher>()
                .HasMany(c => c.Courses)
                .WithOne()
            //.IsRequired();
            .OnDelete(DeleteBehavior.SetNull);


            modelBuilder.Entity<Course>()
                .HasOne(t => t.Teacher)
                .WithMany(c => c.Courses);
            //.OnDelete(DeleteBehavior.SetNull);
        }
    }
}
