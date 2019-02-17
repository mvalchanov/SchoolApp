
namespace SchoolApp.Data.Repository
{
    using SchoolApp.Models;
    using System.Linq;

    public interface IUserRepository
    {
        User GetById(int id);
        IQueryable<User> GetAll(bool include);
        void Add(User user);
        void Delete(int id);
        void Edit(User entity);
    
    }
}