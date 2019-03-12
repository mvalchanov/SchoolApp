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

        public Student GetById(int id)
        {
            var users = context.Students.Include(u => u.Courses);
            var user = users.FirstOrDefault(u => u.ID == id);
            return user;
        }

        public IQueryable<Student> GetAll(bool includeGroups = false)
        {
            var allUsers = context.Students;
            if (includeGroups)
            {
                allUsers
                    .Include(u => u.Courses).ToList();
            }
            return allUsers.AsQueryable();
        }

        public void Add(Student entity)
        {
            this.context.Students.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntry = this.context.Students.FirstOrDefault(e => e.ID == id);
            this.context.Remove(dbEntry);
            this.context.SaveChanges();
        }

        public void Edit(Student student)
        {

            //this.context.SaveChanges();
        }

        public Student GetCourseById(int id)
        {
            //TODO
            throw new System.NotImplementedException();
        }
    }
}
