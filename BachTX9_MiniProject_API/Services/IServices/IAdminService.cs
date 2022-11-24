using BachTX9_MiniProject_API.DTOs.User;
using BachTX9_MiniProject_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Services.IServices
{
    public interface IAdminService
    {
        Task<IEnumerable<User>> GetAllTeacher();
        Task<IEnumerable<User>> GetAllStudent();
        void Delete(int id);
        void Update(UserUpdateDto userUpdateDto);
        Task<User> UpdateAsnyc();
    }
}
