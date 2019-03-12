namespace SchoolApp.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Models;
    using System.Linq;


    public class CourseRepository : ICourseRepository
    {
        public CourseRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }
        private ApplicationDbContext context { get; set; }


        public void Add(Course course)
        {
            this.context.Courses.Add(course);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntity = this.context.Courses.FirstOrDefault(u => u.CourseID == id);
            this.context.Courses.Remove(dbEntity);
            this.context.SaveChanges();

        }

        public void Edit(Course course)
        {
            var dbEntity = this.context.Courses.FirstOrDefault(e => e.CourseID == course.CourseID);
            if (dbEntity != null)
            {
                dbEntity.Name = course.Name;
                dbEntity.Students = course.Students;
            }
        }

        public IQueryable<Course> GetAll(bool includeStudents, bool includeTeacher)
        {
            var allcourses = this.context.Courses;
            if (includeStudents)
            {
                allcourses
                    .Include(u => u.Students)
                        .ThenInclude(s => s.Student)
                    .ToList();
            }
            if (includeTeacher)
            {
                allcourses
                    .Include(t => t.Teacher);
            }
            return allcourses.AsQueryable();
        }

        public Course GetById(int id)
        {
            var dbEntity = this.context.Courses
                .Include(s => s.Students)
                    .ThenInclude(st => st.Student)
                .Include(t => t.Teacher)
                .FirstOrDefault(e => e.CourseID == id);

            return dbEntity;
        }
    }
}
