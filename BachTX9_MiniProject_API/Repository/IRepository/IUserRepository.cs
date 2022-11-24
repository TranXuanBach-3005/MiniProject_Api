using BachTX9_MiniProject_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository.IRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        Task<IEnumerable<User>> GetAllTeacherAsync();
        Task<IEnumerable<User>> GetAllStudentAsync();
    }
}
