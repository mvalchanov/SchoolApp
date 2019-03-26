namespace SchoolApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Models;


    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>(user =>
            {
                user.HasIndex(x => x.Teacher)
                    .IsUnique(false);

                user.HasIndex(x => x.Student)
                    .IsUnique(false);
            });

            modelBuilder.Entity<CourseStudents>(cs =>
           {
               cs.ToTable("Courses_Students");
               cs.HasKey(k => new { k.StudentID, k.CourseID });

               cs.HasOne<Student>()
                    .WithMany(c => c.Courses)
                    .HasForeignKey(k => k.StudentID);

               cs.HasOne<Course>()
                    .WithMany(s => s.Students)
                    .HasForeignKey(k => k.CourseID);
           });

            //modelBuilder.Entity<CourseStudents>()
            //    .HasOne(u => u.Course)
            //    .WithMany(g => g.Students)
            //    .HasForeignKey(fk => fk.CourseID);

            //modelBuilder.Entity<CourseStudents>()
            //    .HasOne(g => g.Student)
            //    .WithMany(u => u.Courses)
            //    .HasForeignKey(fk => fk.StudentID);

            modelBuilder.Entity<Teacher>(t =>
            {
                t.ToTable("Teachers");
                t.HasKey(k => k.TeacherID);

                t.HasMany<Course>()
                    .WithOne()
                    .HasForeignKey(x => x.TeacherID)
                    .IsRequired(false);
                t.HasMany<Person>()
                    .WithOne()
                    .HasForeignKey(x => x.TeacherID);

            });

            modelBuilder.Entity<Course>(c =>
            {
                c.ToTable("Courses");
                c.HasKey(k => k.CourseID);
                c.HasOne(t => t.Teacher)
                    .WithMany(x => x.Courses)
                    .HasForeignKey(x => x.TeacherID)
                    .IsRequired(false);
                c.HasMany<CourseStudents>()
                    .WithOne(x => x.Course)
                    .HasForeignKey(x => x.CourseID);

            });

            modelBuilder.Entity<Student>(st =>
            {
                st.ToTable("Students");
                st.HasKey(k => k.StudentID);

                st.HasMany<CourseStudents>()
                    .WithOne()
                    .HasForeignKey(k => k.StudentID);
            });

            //modelBuilder.Entity<Course>()
            //    .HasOne(t => t.Teacher)
            //    .WithMany(c => c.Courses)
            //    .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
