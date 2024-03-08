using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services.Interfaces
    {
    public interface ILectureService
        {
        Task<IEnumerable<Lecture>> GetAllLecturesAsync();
        Task<Lecture> GetLectureByIdAsync(int lectureId);
        Task<Lecture> CreateLectureAsync(Lecture lecture);
        Task UpdateLectureAsync(Lecture lecture);
        Task DeleteLectureAsync(int lectureId);
        Task AssignLectureToDepartmentAsync(int lectureId, int departmentId);

        }
    }

