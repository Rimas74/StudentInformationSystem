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
        Task<IEnumerable<Department>> GetAllDepartmentsAsync();
        Task<Department> GetDepartmentByIdAsync(int id);
        Task UpdateDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(int id);

        Task AddStudentToDepartmentAsync(int studentId, int departmentId);
        Task AddLectureToDepartmentAsync(int lectureId, int departmentId);
        Task<IEnumerable<Student>> GetAllStudentsInDepartmentAsync(int departmentId);
        Task<IEnumerable<Lecture>> GetAllLecturesInDepartmentAsync(int departmentId);
        //Task TransferStudentToAnotherDepartmentAsync(int studentId, int targetDepartmentId);

        }
    }
