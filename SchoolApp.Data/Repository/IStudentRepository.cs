namespace SchoolApp.Data.Repository
{
    using SchoolApp.Models;
    using System.Linq;

    public interface IStudentRepository
    {
        Student GetById(int id);
        IQueryable<Student> GetAll(bool include);
        void Add(Student entity);
        void Delete(int id);
        void Edit(Student entity);

    
    }
}