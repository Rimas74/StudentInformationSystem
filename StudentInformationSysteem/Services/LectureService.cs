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
    public class LectureService : ILectureService
        {

        private readonly IRepository<Lecture> _lectureRepository;
        private readonly IRepository<Department> _departmentRepository;

        public LectureService(IRepository<Lecture> lectureRepository, IRepository<Department> departmentRepository)
            {
            _lectureRepository = lectureRepository;
            _departmentRepository = departmentRepository;
            }

        public async Task AssignLectureToDepartmentAsync(int lectureId, int departmentId)
            {
            var lecture = await _lectureRepository.GetByIdAsync(lectureId);
            var department = await _departmentRepository.GetByIdAsync(departmentId);
            if (lecture != null && department != null)
                {
                if (lecture.Departments == null)
                    {
                    lecture.Departments = new List<Department>();
                    }
                lecture.Departments.Add(department);
                await _lectureRepository.UpdateAsync(lecture);
                }
            }

        public async Task<Lecture> CreateLectureAsync(Lecture lecture)
            {
            await _lectureRepository.AddAsync(lecture);
            return lecture;
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
