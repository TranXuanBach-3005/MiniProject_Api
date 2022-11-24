using AutoMapper;
using BachTX9_MiniProject_API.DTOs.User;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services.IServices;
using BachTX9_MiniProject_API.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);
            if(user != null)
            {
                _unitOfWork.UserRepository.Delete(user);
                _unitOfWork.Save();
            }

        }

        public async Task<IEnumerable<User>> GetAllStudent()
        {
            var listStu = await _unitOfWork.UserRepository
                                .GetAllStudentAsync();
            return listStu;
        }

        public async Task<IEnumerable<User>> GetAllTeacher()
        {
            var listTea = await _unitOfWork.UserRepository
                                 .GetAllTeacherAsync();
            return listTea;
        }

        public void Update(UserUpdateDto userUpdateDto)
        {
            var user1 =_mapper.Map<User>(userUpdateDto);
            var user = _unitOfWork.UserRepository.GetById(user1.UserId);
            user.UserName = userUpdateDto.UserName;
            user.Email = userUpdateDto.Email;
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Save();
        }

        public Task<User> UpdateAsnyc()
        {
            throw new NotImplementedException();
        }
    }
}
