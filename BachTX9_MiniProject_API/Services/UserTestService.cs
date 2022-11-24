using AutoMapper;
using BachTX9_MiniProject_API.DTOs.UserTest;
using BachTX9_MiniProject_API.Models;
using BachTX9_MiniProject_API.Services.IServices;
using BachTX9_MiniProject_API.UnitOfWorks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BachTX9_MiniProject_API.Services
{
    public class UserTestService : IUserTestService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserTestService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CreateUserTestAsync(UserTestDto userTestDto)
        {
            var result = _mapper.Map<UserTest>(userTestDto);
            await _unitOfWork.UserTestRepository.CreateAsync(result);
            await _unitOfWork.SavesChangeAsync();
            return "Success";
        }
        public async Task<UserTestDto> GetUserTestById(int studentId, int testId)
        {
            var result = await _unitOfWork.UserTestRepository.GetUserTestAsync(studentId, testId);
            var userTest = _mapper.Map<UserTestDto>(result);
            return userTest;
        }
        public async Task<List<UserTestDto>> GetListTestCompletedAsync(int studentId)
        {
            var listExam = await _unitOfWork.UserTestRepository
                                             .GetListTestCompletedAsync(studentId, true);
            var listExamViewModel = _mapper.Map<List<UserTestDto>>(listExam);
            return listExamViewModel;
        }
        public async Task<List<UserTestDto>> GetListTestNotCompletedAsync(int studentId)
        {
            var listExam = await _unitOfWork.UserTestRepository
                                             .GetListTestCompletedAsync(studentId, false);
            var listExamViewModel = _mapper.Map<List<UserTestDto>>(listExam);
            return listExamViewModel;
        }

    }
}
