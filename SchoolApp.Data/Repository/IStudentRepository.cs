namespace SchoolApp.Data.Repository
{
    using SchoolApp.Models;
    using System.Linq;

    public interface IStudentRepository
    {
        Student GetById(int id, bool includeCourses = false);
        IQueryable<Student> GetAll(bool includeGroups = false);

        void Add(Student entity);
        void Delete(int id);
        void Edit(Student entity);
        void Save();
    }
}