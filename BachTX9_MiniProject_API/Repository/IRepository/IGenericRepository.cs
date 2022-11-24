using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository.IRepository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(int id);
        void CreateRange(List<T> entity);
        Task CreateAsync(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
