namespace SchoolApp.Data.Repository
{
    using SchoolApp.Models;
    using System.Linq;

    public interface ITeacherRepository
    {
        Teacher GetById(int id, bool includeCourses = false);
        IQueryable<Teacher> GetAll(bool includeCourses = false);
        Course GetCourseById(int id, bool includeStudents = false);


        void Add(Teacher entity);
        void Delete(int id);
        void Edit(Teacher entity);
        void Save();
    }
}