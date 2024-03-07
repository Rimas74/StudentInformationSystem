using StudentInformationSystem.Data;
using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories
    {
    internal class LectureRepository : IRepository<Lecture>
        {
        public async Task AddAsync(Lecture entity)
            {
            using (var context = new StudentInfoContext())
                {
                context.Add(entity);
                await context.SaveChangesAsync();
                }
            await Task.CompletedTask;
            }

        public async Task DeleteAsync(int id)
            {
            using (var context = new StudentInfoContext())
                {
                var lecture = context.Lectures.Find(id);
                if (lecture != null)
                    {
                    context.Lectures.Remove(lecture);
                    context.SaveChanges();
                    }
                }
            await Task.CompletedTask;
            }

        public async Task<List<Lecture>> GetAllAsync()
            {
            using (var context = new StudentInfoContext())
                {
                return await Task.FromResult(context.Lectures.ToList());
                }

            }

        public async Task<Lecture> GetByIdAsync(int id)
            {
            using (var context = new StudentInfoContext())
                {
                return await Task.FromResult(context.Lectures.Find(id));
                }
            }

        public async Task UpdateAsync(Lecture entity)
            {
            using (var context = new StudentInfoContext())
                {
                context.Lectures.Update(entity);
                context.SaveChanges();
                }
            await Task.CompletedTask;
            }

        }
    }
