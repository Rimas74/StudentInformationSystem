using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Repositories
    {
    internal class Repository<T> : IRepository<T> where T : class
        {
        private readonly StudentInfoContext _context;
        private readonly DbSet<T> _entities;

        public Repository(StudentInfoContext context)
            {
            _context = context;
            _entities = context.Set<T>();
            }
        public async Task AddAsync(T entity)
            {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            }

        public async Task DeleteAsync(int id)
            {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                {
                _entities.Remove(entity);
                _context.SaveChanges();
                }
            }

        public async Task<IEnumerable<T>> GetAllAsync()
            {
            return await _entities.ToListAsync();
            }

        public async Task<T> GetByIdAsync(int id)
            {
            return await _entities.FindAsync(id);
            }

        public async Task UpdateAsync(T entity)
            {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
            }
        }

    }
