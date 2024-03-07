using StudentInformationSystem.Models;
using StudentInformationSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
    {
    public class LectureService : ILectureService
        {
        private readonly IRepository<Lecture> _lectureRepository;
        private readonly IRepository<Department> _departmentRepository;
        private readonly IRepository<Student> _studentRepository;

        public LectureService(IRepository<Lecture> lectureRepository,
                              IRepository<Department> departmentRepository,
                              IRepository<Student> studentRepository)
            {
            _lectureRepository = lectureRepository;
            _departmentRepository = departmentRepository;
            _studentRepository = studentRepository;
            }
        public async Task AssignLectureToDepartmentAsync(int lectureId, int departmentId)
            {
            var lecture = await _lectureRepository.GetByIdAsync(lectureId);
            var department = await _departmentRepository.GetByIdAsync(departmentId);

            if (lecture != null && department != null)
                {
                if (department.Lectures == null)
                    {
                    department.Lectures = new List<Lecture>();
                    }
                department.Lectures.Add(lecture);
                await _departmentRepository.UpdateAsync(department);
                }
            }

        public async Task AssignLectureToStudentsAsync(int lectureId, IEnumerable<int> studentsIds)
            {
            var lecture = await _lectureRepository.GetByIdAsync(lectureId);

            if (lecture != null)
                {
                foreach (var studentId in studentsIds)
                    {
                    var student = await _studentRepository.GetByIdAsync(studentId);
                    if (student != null)
                        {
                        if (student.Lectures == null)
                            {
                            student.Lectures = new List<Lecture>();
                            }
                        student.Lectures.Add(lecture);

                        }
                    }
                await _lectureRepository.UpdateAsync(lecture);
                }
            }

        public async Task CreateLectureAsync(Lecture lecture)
            {
            await _lectureRepository.AddAsync(lecture);
            }

        public async Task DeleteLectureAsync(int lectureId)
            {
            await _lectureRepository.DeleteAsync(lectureId);
            }

        public async Task<IEnumerable<Lecture>> GetAllLecturesAsync()
            {
            return await _lectureRepository.GetAllAsync();
            }

        public async Task<Lecture> GetLectureByIdAsync(int lectureId)
            {
            return await _lectureRepository.GetByIdAsync(lectureId);
            }

        public async Task UpdateLectureAsync(Lecture lecture)
            {
            await _lectureRepository.UpdateAsync(lecture);
            }
        }

    }
