using BachTX9_MiniProject_API.Data;
using BachTX9_MiniProject_API.Enums;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAllStudentAsync()
        {
            var listStu = await _context.users.Where(n => n.Role == RoleEnum.Student).ToListAsync();
            return listStu;
        }

        public async Task<IEnumerable<User>> GetAllTeacherAsync()
        {
            var listTea = await _context.users.Where(n => n.Role == RoleEnum.Teacher).ToListAsync();
            return listTea;
        }
    }
}
