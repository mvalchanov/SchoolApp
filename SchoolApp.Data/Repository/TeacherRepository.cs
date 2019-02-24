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

        public Teacher GetById(int id)
        {
            var users = context.Teachers.Include(u => u.Courses);
            var user = users.FirstOrDefault(u => u.ID == id);
            return user;
        }

        public IQueryable<Teacher> GetAll(bool includeGroups = false)
        {
            var allUsers = context.Teachers;
            if (includeGroups)
            {
                allUsers
                    .Include(u => u.Courses).ToList();
            }
            return allUsers.AsQueryable();
        }

        public void Add(Teacher entity)
        {
            this.context.Teachers.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntry = this.context.Teachers.FirstOrDefault(e => e.ID == id);
            this.context.Remove(dbEntry);
            this.context.SaveChanges();
        }

        public void Edit(Teacher teacher)
        {
            var dbUser = this.context.Teachers.FirstOrDefault(u => u.ID == teacher.ID);
            if (dbUser != null)
            {
                dbUser.FirstName = teacher.FirstName;
                dbUser.MidName = teacher.MidName;
                dbUser.LastName = teacher.LastName;
                dbUser.Email = teacher.Email;
                dbUser.Courses = teacher.Courses;
            }

            this.context.SaveChanges();
        }
        public Course GetCourseById(int id)
        {
            var dbEntity = this.context.Courses
                .Include(s => s.Students)
                    .ThenInclude(st => st.Student)
                .FirstOrDefault(e => e.CourseID == id);

            return dbEntity;
        }
    }

}
