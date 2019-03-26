namespace SchoolApp.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Models;
    using System.Linq;

    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext context;

        public TeacherRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        public Course GetCourseById(int id, bool includeStudents = false)
        {
            DbSet<Course> dbEntity = this.context.Courses;

            if (includeStudents)
            {
                dbEntity
                    .Include(s => s.Students)
                        .ThenInclude(st => st.Student)
                    .ToList();
            }

            return dbEntity.FirstOrDefault(e => e.CourseID == id);
        }

        public Teacher GetById(int id, bool includeCourses = false)
        {
            //DbSet<Teacher> teachers = context.Teachers;
            //if (includeCourses)
            //{
            //    teachers
            //        .Include(u => u.Courses)
            //            .ThenInclude(s=>s.Students)
            //        .ToList();
            //}

            //return teachers.FirstOrDefault(x=>x.ID == id);
            return null;
        }

        public IQueryable<Teacher> GetAll(bool includeCourses = false)
        {
            DbSet<Teacher> allTeachers = context.Teachers;
            if (includeCourses)
            {
                allTeachers
                    .Include(u => u.Courses)
                    .ToList();
            }
            return allTeachers.AsQueryable();
        }

        public void Add(Teacher teacher)
        {
            this.context.Teachers.Add(teacher);
        }

        public void Delete(int id)
        {
            //Teacher teacher = this.context.Teachers
            //    .FirstOrDefault(e => e.ID == id);

            //this.context.Remove(teacher);
        }

        public void Edit(Teacher teacher)
        {
            this.context.Update(teacher);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
