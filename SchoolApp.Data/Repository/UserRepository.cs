namespace SchoolApp.Data.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SchoolApp.Models;
    using System.Linq;

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext ctx)
        {
            this.context = ctx;
        }

        public User GetById(int id)
        {
            return context.Users.Find(id);
        }

        public IQueryable<User> GetAll(bool includeGroups = false)
        {
            var allUsers = context.Users;
            if (includeGroups)
            {
                allUsers.Include(u => u.Groups).ToList();
            }
            return allUsers.AsQueryable();
        }

        public void Add(User entity)
        {
            this.context.Users.Add(entity);
            this.context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dbEntry = this.context.Users.FirstOrDefault(e => e.UserId == id);
            this.context.Remove(dbEntry);
            this.context.SaveChanges();
        }

        public void Edit(User user)
        {
            var dbUser = this.context.Users.FirstOrDefault(u => u.UserId == user.UserId);
            if (dbUser != null)
            {
                dbUser.FirstName = user.FirstName;
                dbUser.LastName = user.LastName;
                dbUser.IsTeacher = user.IsTeacher;
                dbUser.Groups = user.Groups;
                dbUser.ReturnUrl = user.ReturnUrl;
            }
        }

       
    }
}
