using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Models
{
    public class Person : IdentityUser
    {
        public Person()
        {

        }
        public Person(bool isStudent = false, bool isTeacher = false)
        {
            if (isTeacher)
            {
                this.Teacher = new Teacher();
            }
            if (isStudent)
            {
                this.Student = new Student();
            }
        }

        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int StudentID { get; set; }
        public virtual Student Student { get; set; } 
    }
}
