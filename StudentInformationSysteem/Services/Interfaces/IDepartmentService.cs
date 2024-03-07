using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Interfaces
    {
    public interface IDepartmentService
        {
        Task<Department> CreateDepartmentAsync(Department department);
        Task AddStudentToDepartmentAsync(int studentId, int departmentId);
        Task AddLectureToDepartmentAsync(int lectureId, int departmentId);
        Task<IEnumerable<Student>> GetAllStudentsInDepartmentAsync(int departmentId);
        Task<IEnumerable<Lecture>> GetAllLecturesInDepartmentAsync(int departmentId);
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        }
    }
