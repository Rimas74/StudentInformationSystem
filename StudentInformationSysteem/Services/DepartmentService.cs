using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Models;
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
        public async Task AddLectureToDepartmentAsync(int lectureId, int departmentId)
            {
            using (var context = new StudentInfoContext())
                {
                var lecture = await context.Lectures.FindAsync(lectureId);
                var department = await context.Departments.FindAsync(departmentId);
                if (lecture != null && department != null)
                    {
                    department.Lectures.Add(lecture);
                    await context.SaveChangesAsync();
                    }
                }
            }

        public async Task AddStudentToDepartmentAsync(int studentId, int departmentId)
            {
            using (var context = new StudentInfoContext())
                {
                var student = await context.Students.FindAsync(studentId);
                var department = await context.Departments.FindAsync(departmentId);
                if (student != null && department != null)
                    {
                    department.Students.Add(student);
                    await context.SaveChangesAsync();

                    }
                }
            }

        public async Task<Department> CreateDepartmentAsync(Department department)
            {

            using (var context = new StudentInfoContext())
                {
                context.Departments.Add(department);
                await context.SaveChangesAsync();
                return department;
                }
            }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
            {
            using (var context = new StudentInfoContext())
                {
                return await context.Departments.ToListAsync();
                }
            }

        public async Task<IEnumerable<Lecture>> GetAllLecturesInDepartmentAsync(int departmentId)
            {
            using (var context = new StudentInfoContext())
                {
                var department = await context.Departments.FindAsync(departmentId);
                return department?.Lectures.ToList() ?? new List<Lecture>();
                }
            }

        public async Task<IEnumerable<Student>> GetAllStudentsInDepartmentAsync(int departmentId)
            {
            using (var context = new StudentInfoContext())
                {
                var department = await context.Departments.FindAsync(departmentId);
                return department?.Students.ToList() ?? new List<Student>();
                };
            }


        }
    }
