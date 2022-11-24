using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DataDbContext _context;

        public GenericRepository(DataDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _context.Set<T>().ToListAsync();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);

        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void CreateRange(List<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }
    }
}
