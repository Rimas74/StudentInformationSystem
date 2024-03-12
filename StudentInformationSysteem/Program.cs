using StudentInformationSystem.Data;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories;
using StudentInformationSystem.Services;
using StudentInformationSystem.Services.Interfaces;

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
            var studentService = new StudentService(studentRepository, departmentRepository, lectureRepository);


            #region 1.A. Create a Department.



            //var newDepartment = new Department { Name = "History" };
            //await departmentService.CreateDepartmentAsync(newDepartment);

            //Console.WriteLine($"Department created {newDepartment.Name}");

            #endregion

            #region 1.B. Create a new Lecture.

            //var newLecture = new Lecture { Title = "Modern History" };
            //await lectureService.CreateLectureAsync(newLecture);

            #endregion

            #region 2.A. Add an existing lecture to an existing department.

            //int LectureID = 6;
            //int departmentId = 2;
            //await departmentService.AddLectureToDepartmentAsync(LectureID, departmentId);

            #endregion


            #region 2.B. Add existing student to an existing department.
            //int studentId = 3;
            //int departmentId = 2;

            //await departmentService.AddStudentToDepartmentAsync(studentId, departmentId);

            #endregion

            #region 3.A. Create a lecture.
            //var newLecture = new Lecture() { Title = "History of Europe" };
            //await lectureService.CreateLectureAsync(newLecture);
            #endregion

            #region 3.B. Lecture assign to a department.

            //var lectureId = 7;
            //var departmentId = 2;
            //await departmentService.AddLectureToDepartmentAsync(lectureId, departmentId);

            #endregion


            #region 4. Create a student, add it to an existing department and assign it to existing lectures.

            // 4.A. Create new student.

            //var newSudent = new Student { Name = "Tim Snaider", DepartmentId = 2 };
            //await studentService.CreateStudentAsync(newSudent);

            //var newsSudent = new Student { Name = "Jamie Oliver" };
            //await studentService.CreateStudentAsync(newsSudent);

            // 4.B. Add existing student to an existing department

            //int studentId = 11;
            //int departmentId = 2;
            //await departmentService.AddStudentToDepartmentAsync(studentId, departmentId);

            //4.C. Assign student to existing lectures

            //var studentId = 5;
            //IEnumerable<int> lectureIds = new List<int> { 1, 2, 5, 6, 7 };
            //await studentService.AssignStudentToLecturesAsync(studentId, lectureIds);

            #endregion

            #region 5. Transfer the student to another department 
            //var studentId = 1;
            //var departmentId = 2;

            //await studentService.TransferStudentToAnotherDepartmentAsync(studentId, departmentId);

            #endregion

            #region 6.Display all students in the department.

            //var departmentId = 2;
            //var studentsInDepartment = await departmentService.GetAllStudentsInDepartmentAsync(departmentId);
            //Console.WriteLine($"Students in Department ID {departmentId}:");
            //foreach (var student in studentsInDepartment)
            //    {
            //    Console.WriteLine($"- {student.Name}");
            //    }

            #endregion

            #region 7. Display all lectures in the department.

            //var departmentId = 2;
            //var lecturesInDepartment = await departmentService.GetAllLecturesInDepartmentAsync(departmentId);

            //Console.WriteLine($"Lectures in Department ID {departmentId}:");
            //foreach (var lecture in lecturesInDepartment)
            //    {
            //    Console.WriteLine($"- {lecture.Title}");
            //    }

            #endregion

            #region 8.Display all lectures by student.

            var studentId = 5;
            var lecturesForStudent = await studentService.GetAllLecturesByStudentAsync(studentId);
            Console.WriteLine($"Lectures assigned to the student {studentId}");
            foreach (var lecture in lecturesForStudent)
                {
                Console.WriteLine($"- {lecture.Title}");
                }


            #endregion


            }

        }
    }

