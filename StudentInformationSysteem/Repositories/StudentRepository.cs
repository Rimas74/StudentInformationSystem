using StudentInformationSystem.Data;
using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories
    {
    public class StudentRepository : IRepository<Student>
        {
        public async Task AddAsync(Student entity)
            {
            using (var context = new StudentInfoContext())
                {
                context.Students.Add(entity);
                context.SaveChanges();
                }
            await Task.CompletedTask;
            }

        public async Task DeleteAsync(int id)
            {
            using (var context = new StudentInfoContext())
                {
                var student = context.Students.Find(id);
                if (student != null)
                    {
                    context.Students.Remove(student);
                    context.SaveChanges();
                    }

                }
            await Task.CompletedTask;
            }

        public async Task<List<Student>> GetAllAsync()
            {
            using (var context = new StudentInfoContext())
                {
                return await Task.FromResult(context.Students.ToList());
                }
            }

        public async Task<Student> GetByIdAsync(int id)
            {
            using (var context = new StudentInfoContext())
                {
                return await Task.FromResult(context.Students.Find(id));
                }
            }

        public async Task UpdateAsync(Student entity)
            {
            using (var context = new StudentInfoContext())
                {
                context.Students.Update(entity);
                context.SaveChanges();
                }
            await Task.CompletedTask;
            }
        }
    }
