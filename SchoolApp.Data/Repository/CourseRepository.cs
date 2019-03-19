namespace SchoolApp.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Models;
    using System.Linq;

    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext context;

        public CourseRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        public IQueryable<Course> GetAll(bool includeStudents = false, bool includeTeacher = false)
        {
            DbSet<Course> courses = this.context.Courses;
            if (includeStudents)
            {
                courses
                    .Include(u => u.Students)
                        .ThenInclude(s => s.Student)
                    .ToList();
            }
            if (includeTeacher)
            {
                courses
                    .Include(t => t.Teacher)
                    .ToList();
            }
            return courses.AsQueryable();
        }

        public Course GetById(int id, bool includeStudents = false, bool includeTeacher = false)
        {
            DbSet<Course> courses = this.context.Courses;

            if (includeStudents)
            {
                courses
                    .Include(x => x.Students)
                        .ThenInclude(x => x.Student)
                    .ToList();
            }

            if (includeTeacher)
            {
                courses
                    .Include(x => x.Teacher)
                    .ToList();
            }

            return courses.FirstOrDefault(x => x.CourseID == id);
        }

        public void Add(Course course)
        {
            this.context.Courses.Add(course);
        }

        public void Delete(int id)
        {
            Course course = this.context.Courses
                .FirstOrDefault(u => u.CourseID == id);

            this.context.Courses.Remove(course);
        }

        public void Edit(Course course)
        {
            Course crs = this.context.Courses
                .FirstOrDefault(e => e.CourseID == course.CourseID);

            if (crs != null)
            {
                crs.Name = course.Name;
                crs.Students = course.Students;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
