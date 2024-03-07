using StudentInformationSystem.Data;
using StudentInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories
    {
    public class DepartmentRepository : IRepository<Department>
        {
        public async Task AddAsync(Department entity)
            {
            using (var context = new StudentInfoContext())
                {
                context.Departments.Add(entity);
                context.SaveChanges();
                }
            await Task.CompletedTask;
            }

        public async Task DeleteAsync(int id)
            {
            using (var context = new StudentInfoContext())
                {
                var department = context.Departments.Find(id);
                if (department != null)
                    {
                    context.Departments.Remove(department);
                    context.SaveChanges();
                    }
                };
            }

        public async Task<List<Department>> GetAllAsync()
            {
            using (var context = new StudentInfoContext())
                {
                return await Task.FromResult(context.Departments.ToList());
                };
            }

        public async Task<Department> GetByIdAsync(int id)
            {
            using (var context = new StudentInfoContext())
                {
                return await Task.FromResult(context.Departments.Find(id));
                };
            }

        public async Task UpdateAsync(Department entity)
            {
            using (var context = new StudentInfoContext())
                {
                context.Departments.Update(entity);
                context.SaveChanges();
                }
            await Task.CompletedTask;
            }


        }
    }
