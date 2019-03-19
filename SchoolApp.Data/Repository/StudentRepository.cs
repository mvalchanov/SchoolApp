namespace SchoolApp.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Models;
    using System.Linq;

    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext context;

        public StudentRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        public Student GetById(int id, bool includeCourses = false)
        {
            DbSet<Student> students = context.Students;

            if (includeCourses)
            {
                students
                    .Include(u => u.Courses)
                        .ThenInclude(c => c.Course)
                    .ToList();
            }

            return students.FirstOrDefault(u => u.ID == id);
        }

        public IQueryable<Student> GetAll(bool includeGroups = false)
        {
            DbSet<Student> students = context.Students;
            if (includeGroups)
            {
                students
                    .Include(u => u.Courses)
                        .ThenInclude(c => c.Course)
                    .ToList();
            }
            return students.AsQueryable();
        }

        public Student GetCourseById(int id)
        {
            //TODO
            throw new System.NotImplementedException();
        }

        public void Add(Student student)
        {
            this.context.Students.Add(student);
        }

        public void Delete(int id)
        {
            Student student = this.context.Students
                .FirstOrDefault(e => e.ID == id);

            this.context.Remove(student);
        }

        public void Edit(Student student)
        {
            this.context.Update(student);
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
    }
}
