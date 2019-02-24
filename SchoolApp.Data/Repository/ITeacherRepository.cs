namespace SchoolApp.Data.Repository
{
    using SchoolApp.Models;
    using System.Linq;

    public interface ITeacherRepository
    {
        Teacher GetById(int id);
        IQueryable<Teacher> GetAll(bool include);
        void Add(Teacher entity);
        void Delete(int id);
        void Edit(Teacher entity);
        Course GetCourseById(int id);

    
    }
}