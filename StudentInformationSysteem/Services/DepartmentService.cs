using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
    {
    public class DepartmentService : IDepartmentService
        {
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Lecture> _lectureRepository;

        public DepartmentService(IRepository<Department> departmentRepository,
                                 IRepository<Student> studentRepository,
                                 IRepository<Lecture> lectureRepository)
            {
            _departmentRepository = departmentRepository;
            _studentRepository = studentRepository;
            _lectureRepository = lectureRepository;
            }

        public async Task AddLectureToDepartmentAsync(int lectureId, int departmentId)
            {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            var lecture = await _lectureRepository.GetByIdAsync(lectureId);

            if (department != null && lecture != null)
                {
                if (department.Lectures == null)
                    {
                    department.Lectures = new List<Lecture>();
                    }
                department.Lectures.Add(lecture);
                await _departmentRepository.UpdateAsync(department);
                }
            }

        public async Task AddStudentToDepartmentAsync(int studentId, int departmentId)
            {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            var student = await _studentRepository.GetByIdAsync(studentId);

            if (department != null && student != null)
                {
                if (department.Students == null)
                    {
                    department.Students = new List<Student>();
                    }
                department.Students.Add(student);
                await _departmentRepository.UpdateAsync(department);
                }
            }

        public async Task CreateDepartmentAsync(Department department)
            {
            await _departmentRepository.AddAsync(department);
            }

        public async Task DeleteDepartmentAsync(int departmentId)
            {
            await _departmentRepository.DeleteAsync(departmentId);
            }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
            {
            return await _departmentRepository.GetAllAsync();
            }

        public async Task<Department> GetDepartmentByIdAsync(int departmentId)
            {
            return await _departmentRepository.GetByIdAsync(departmentId);
            }

        public async Task UpdateDepartmentAsync(Department department)
            {
            await _departmentRepository.UpdateAsync(department);
            }
        }

    }
