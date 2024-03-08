using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories;
using StudentInformationSystem.Services.Interfaces;
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
        private readonly IRepository<Lecture> _lectureRepository;
        private IRepository<Student> _studentRepository;

        public DepartmentService(IRepository<Department> departmentRepository, IRepository<Lecture> lectureRepository, IRepository<Student> studentRepository)
            {
            _departmentRepository = departmentRepository;
            _lectureRepository = lectureRepository;
            _studentRepository = studentRepository;
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

        public async Task<Department> CreateDepartmentAsync(Department department)
            {
            await _departmentRepository.AddAsync(department);
            return department;
            }

        public async Task DeleteDepartmentAsync(int id)
            {
            await _departmentRepository.DeleteAsync(id);
            }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
            {
            return await _departmentRepository.GetAllAsync();
            }

        public async Task<IEnumerable<Lecture>> GetAllLecturesInDepartmentAsync(int departmentId)
            {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            return department?.Lectures ?? new List<Lecture>();
            }

        public async Task<IEnumerable<Student>> GetAllStudentsInDepartmentAsync(int departmentId)
            {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            return department?.Students ?? new List<Student>();
            }

        public async Task<Department> GetDepartmentByIdAsync(int id)
            {
            return await _departmentRepository.GetByIdAsync(id);

            }

        //public async Task TransferStudentToAnotherDepartmentAsync(int studentId, int targetDepartmentId)
        //{
        //var student = await _studentRepository.GetByIdAsync(studentId);
        //var targetDepartment = await _departmentRepository.GetByIdAsync(targetDepartmentId);

        //if (student != null && targetDepartment != null)
        //    {
        //    student.DepartmentId = targetDepartment.DepartmentId;
        //    await _studentRepository.UpdateAsync(student);
        //    }
        //}

        public async Task UpdateDepartmentAsync(Department department)
            {
            await _departmentRepository.UpdateAsync(department);
            }
        }
    }
