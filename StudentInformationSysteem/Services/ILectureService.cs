using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
    {
    public interface ILectureService
        {
        Task<IEnumerable<Lecture>> GetAllLecturesAsync();
        Task<Lecture> GetLectureByIdAsync(int lectureId);
        Task CreateLectureAsync(Lecture lecture);
        Task UpdateLectureAsync(Lecture lecture);
        Task DeleteLectureAsync(int lectureId);
        Task AssignLectureToDepartmentAsync(int lectureId, int departmentId);
        Task AssignLectureToStudentsAsync(int lectureId, IEnumerable<int> studentsIds);
        }
    }
