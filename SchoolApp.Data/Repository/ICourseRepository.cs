
namespace SchoolApp.Data.Repository
{
    using SchoolApp.Models;
    using System.Linq;

    public interface ICourseRepository
    {
        Course GetById(int id, bool includeStudents = false, bool includeTeacher = false);
        IQueryable<Course> GetAll(bool includeStudents = false, bool includeTeacher = false);


        void Add(Course entity);
        void Delete(int id);
        void Edit(Course entity);
        void Save();
    }
}