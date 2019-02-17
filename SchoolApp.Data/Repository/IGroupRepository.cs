
namespace SchoolApp.Data.Repository
{
    using SchoolApp.Models;
    using System.Linq;

    public interface IGroupRepository
    {
        Group GetById(int id);
        IQueryable<Group> GetAll(bool include);
        void Add(Group entity);
        void Delete(int id);
        void Edit(Group entity);
    
    }
}