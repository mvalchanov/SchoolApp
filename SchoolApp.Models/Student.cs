
namespace SchoolApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Student : Person
    {
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

    }
}
