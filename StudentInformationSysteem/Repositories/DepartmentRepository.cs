using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories
    {
    public class DepartmentRepository : IRepository<Department>
        {
        private readonly StudentInfoContext _context;

        public DepartmentRepository()
            {
            _context = new StudentInfoContext();
            }

        public async Task AddAsync(Department entity)
            {
            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();
            }

        public async Task DeleteAsync(int id)
            {
            var department = await _context.Departments.FindAsync(id);
            if (department != null)
                {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
                }
            }

        public async Task<List<Department>> GetAllAsync()
            {
            return await _context.Departments.ToListAsync();
            }

        public async Task<Department> GetByIdAsync(int id)
            {
            return await _context.Departments
                                 .Include(d => d.Students)
                                 .Include(l => l.Lectures)
                                 .FirstOrDefaultAsync(d => d.DepartmentId == id);
            }

        public async Task UpdateAsync(Department entity)
            {
            _context.Departments.Update(entity);
            await _context.SaveChangesAsync();
            }
        }
    }
