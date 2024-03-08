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
    public class StudentService : IStudentService
        {
        private readonly IRepository<Student> _studentRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Lecture> _lectureRepository;

        public StudentService(IRepository<Student> studentRepository, IRepository<Department> departmentRepository, IRepository<Lecture> lectureRepository)
            {
            _studentRepository = studentRepository;
            _departmentRepository = departmentRepository;
            _lectureRepository = lectureRepository;
            }

        public async Task AssignStudentToDepartmentAsync(int studentId, int departmentId)
            {
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            var student = await _studentRepository.GetByIdAsync(studentId);

            if (student != null && department != null)
                {
                student.DepartmentId = departmentId;
                await _studentRepository.UpdateAsync(student);
                }
            }

        public async Task AssignStudentToLecturesAsync(int studentId, IEnumerable<int> lectureIds)
            {
            var student = await _studentRepository.GetByIdAsync(studentId);
            if (student != null)
                {
                student.Lectures ??= new List<Lecture>();

                foreach (var lectureId in lectureIds)
                    {
                    var lecture = await _lectureRepository.GetByIdAsync(lectureId);
                    if (lecture != null)
                        {
                        student.Lectures.Add(lecture);
                        }
                    }
                await _studentRepository.UpdateAsync(student);
                }
            }

        public async Task CreateStudentAsync(Student student)
            {
            await _studentRepository.AddAsync(student);
            }

        public async Task DeleteStudentAsync(int studentId)
            {
            await _studentRepository.DeleteAsync(studentId);
            }

        public async Task<IEnumerable<Lecture>> GetAllLecturesByStudentAsync(int studentId)
            {
            var student = await _studentRepository.GetByIdAsync(studentId);
            return student?.Lectures ?? new List<Lecture>();
            }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
            {
            return await _studentRepository.GetAllAsync();
            }

        public async Task<Student> GetStudentByIdAsync(int studentId)
            {
            return await _studentRepository.GetByIdAsync(studentId);
            }

        public async Task TransferStudentToAnotherDepartmentAsync(int studentId, int newDepartmentId)
            {
            var student = await _studentRepository.GetByIdAsync(studentId);
            var newDepartment = await _departmentRepository.GetByIdAsync(newDepartmentId);
            if (student != null && newDepartment != null)
                {
                student.DepartmentId = newDepartmentId;
                await _studentRepository.UpdateAsync(student);
                }
            }

        public async Task UpdateStudentAsync(Student student)
            {
            await _studentRepository.UpdateAsync(student);
            }
        }
    }
