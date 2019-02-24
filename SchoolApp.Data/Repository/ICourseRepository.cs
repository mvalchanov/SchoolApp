
namespace SchoolApp.Data.Repository
{
    using SchoolApp.Models;
    using System.Linq;

    public interface ICourseRepository
    {
        Course GetById(int id);
        IQueryable<Course> GetAll(bool include);
        void Add(Course entity);
        void Delete(int id);
        void Edit(Course entity);
    
    }
}