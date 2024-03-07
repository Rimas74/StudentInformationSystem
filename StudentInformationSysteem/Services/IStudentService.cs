using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
    {
    public interface IStudentService
        {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(int studentId);
        Task CreateStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int studentId);
        Task AssignStudentToDepartmentAsync(int studentId, int departmentId);
        Task AssignStudentToLecturesAsync(int studentId, IEnumerable<int> lectureIds);
        Task TransferStudentToAnotherDepartmentAsync(int studentId, int newDepartmentId);
        }
    }
