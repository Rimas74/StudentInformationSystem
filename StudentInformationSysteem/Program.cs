using StudentInformationSystem.Data;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories;
using StudentInformationSystem.Services;

namespace StudentInformationSysteem
    {
    internal class Program
        {
        static async Task Main(string[] args)
            {
            //using (var context = new StudentInfoContext())
            //    {

            //    #region 1. Create a Department and Add Students and Lectures to It.

            //List<Student> newListOfStudents = new List<Student>
            //    {
            //    new Student {Name="John Doe" },
            //    new Student {Name="Jane Doe"},
            //    new Student {Name="Tom Hanks" },
            //    new Student {Name="Jimmy Smith" },
            //    new Student {Name="Rachel Green" },
            //                        };

            //List<Lecture> newListOfLectures = new List<Lecture>
            //    {
            //    new Lecture {Title="Introduction to Physics"},
            //    new Lecture {Title="Advanced Quantum Mechanics"},
            //    new Lecture {Title="Thermodynamics"},
            //    new Lecture {Title="Mechanics"},
            //    new Lecture {Title="Electromagnetism"},
            //    };

            //var department = new Department { Name = "Physics" }; //History,Psychology,Mathematics,Biology
            //department.Students = newListOfStudents;
            //department.Lectures = newListOfLectures;
            //context.Departments.Add(department);
            //context.SaveChanges()
            //context.SaveChanges();
            //#endregion
            //}

            var departmentRepository = new DepartmentRepository();
            var lectureRepository = new LectureRepository();
            var studentRepository = new StudentRepository();
            var departmentService = new DepartmentService(departmentRepository, lectureRepository, studentRepository);
            var lectureService = new LectureService(lectureRepository, departmentRepository);


            #region 1.A. Create a Department.



            //var newDepartment = new Department { Name = "History" };
            //await departmentService.CreateDepartmentAsync(newDepartment);

            //Console.WriteLine($"Department created {newDepartment.Name}");

            #endregion

            #region 2.A. Add lectures to an existing department.

            var newLecture = new Lecture { Title = "Modern History" };




            #endregion

            #region 2.B. Add students to an existing department.






            #endregion
            }

        }
    }

