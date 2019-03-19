namespace SchoolApp.Data
{
    using SchoolApp.Models;
    using System;
    using System.Linq;

    public class SeedData
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Students.Any() && context.Teachers.Any() && context.Courses.Any())
            {
                return;
            }
            else if (!context.Students.Any())
            {
                var students = new Student[]
            {
                new Student
                    {
                        FirstName = "Student1",
                        MidName = "Student1",
                        LastName = "Student1",
                        Email = "Student1@1.1",
                        Password = "Student1Pass"
                    },
                new Student
                    {
                        FirstName = "Student2",
                        MidName = "Student2",
                        LastName = "Student2",
                        Email = "Student2@2.2",
                        Password = "Student2Pass"
                    },
                new Student
                    {
                        FirstName = "Student3",
                        MidName = "Student3",
                        LastName = "Student3",
                        Email = "Student3@3.3",
                        Password = "Student3Pass"
                    },
                new Student
                    {
                        FirstName = "Student4",
                        MidName = "Student4",
                        LastName = "Student4",
                        Email = "Student4@4.4",
                        Password = "Student4Pass"
                    }
            };

                foreach (var student in students)
                {
                    try
                    {
                        context.Students.Add(student);
                    }
                    catch (Exception e)
                    {

                    }
                }
                context.SaveChanges();
            }
            else if (!context.Teachers.Any())
            {
                var teachers = new Teacher[]
            {
                    new Teacher
                    {
                        FirstName = "Teacher1",
                        MidName = "teacher1",
                        LastName = "teacher1",
                        Email = "teacher1@1.1",
                        Password = "teacher1pass"
                    },
                    new Teacher
                    {
                        FirstName = "teacher2",
                        MidName = "teacher2",
                        LastName = "teacher2",
                        Email = "teacher2@2.2",
                        Password = "teache2pass"
                    },
                    new Teacher
                    {
                        FirstName = "teacher3",
                        MidName = "teacher3",
                        LastName = "teacher3",
                        Email = "teacher3@3.3",
                        Password = "teacher3Pass"
                    },
                    new Teacher
                    {
                        FirstName = "teacher4",
                        MidName = "teacher4",
                        LastName = "teacher4",
                        Email = "teacher4@4.4",
                        Password = "teacher4Pass"
                    }
            };

                foreach (var teacher in teachers)
                {
                    try
                    {
                        context.Teachers.Add(teacher);
                    }
                    catch (Exception e)
                    {

                    }
                }
                context.SaveChanges();
            }
            else if (!context.Courses.Any())
            {
                var courses = new Course[]
                           {
                new Course
                {
                    Name ="bylgarski",
                },
                new Course
                {
                    Name ="matematika",
                },
                new Course
                {
                    Name ="fizika",
                },
                new Course
                {
                    Name ="himiq",
                },
                new Course
                {
                    Name ="nemski",
                },
                new Course
                {
                    Name ="biologiq",
                }
                           };
                foreach (var course in courses)
                {
                    try
                    {
                        context.Courses.Add(course);
                    }
                    catch (Exception e)
                    {
                    }
                }
                context.SaveChanges();
            }

            return;
        }
    }
}
