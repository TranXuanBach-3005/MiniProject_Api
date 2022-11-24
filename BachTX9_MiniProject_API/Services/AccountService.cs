using AutoMapper;
using BachTX9_MiniProject_API.DTOs.UserDtos;
using BachTX9_MiniProject_API.Enums;
using BachTX9_MiniProject_API.Helper;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services.IServices;
using BachTX9_MiniProject_API.UnitOfWorks;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ReponseMessage> Login(UserLoginDto userLoginDto)
        {
            var account = await _unitOfWork.AccountRepository.GetByUserName(userLoginDto.UserName, userLoginDto.Password);
            if (account != null)
            {
                var token = _unitOfWork.AccountRepository.GenereateJwtTonken(account);
                if (token != null)
                {
                    return new ReponseMessage()
                    {
                        Message = "ssss",
                        Success = true,
                        Data = token,
                    };
                }
                else
                {
                    return new ReponseMessage()
                    {
                        Success = false,
                    };
                }
            }
            return new ReponseMessage()
            { 
                Message = "fail"
            };
        }

        public async Task<string> Register(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<User>(userRegisterDto);
            user.Role = RoleEnum.Student;
            await _unitOfWork.AccountRepository.CreateAsync(user);
            await _unitOfWork.SavesChangeAsync();
            return "Success";
        }

        public async Task<string> RegisterTeacher(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<User>(userRegisterDto);
            user.Role = RoleEnum.Teacher;
            var result = _unitOfWork.AccountRepository.CreateAsync(user);
            await _unitOfWork.SavesChangeAsync();
            return "Success";
        }

        public bool lockAccount(int id)
        {
            var result = _unitOfWork.AccountRepository.lockAccount(id);
            if (result == false) return false;
            _unitOfWork.Save();
            return true;
        }
    }
}
