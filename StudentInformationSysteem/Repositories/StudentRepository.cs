using Microsoft.EntityFrameworkCore;
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
                await context.SaveChangesAsync();
                }

            }

        public async Task DeleteAsync(int id)
            {
            using (var context = new StudentInfoContext())
                {
                var student = await context.Students.FindAsync(id);
                if (student != null)
                    {
                    context.Students.Remove(student);
                    await context.SaveChangesAsync();
                    }
                }
            }
        public async Task<List<Student>> GetAllAsync()
            {
            using (var context = new StudentInfoContext())
                {
                return await context.Students.ToListAsync();
                }
            }

        public async Task<Student> GetByIdAsync(int id)
            {
            using (var context = new StudentInfoContext())
                {
                return await context.Students
                     .Include(s => s.Lectures)
                     .FirstOrDefaultAsync(s => s.StudentId == id);
                }
            }

        public async Task UpdateAsync(Student entity)
            {
            using (var context = new StudentInfoContext())
                {
                context.Students.Update(entity);
                await context.SaveChangesAsync();
                }

            }
        }
    }
