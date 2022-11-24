using BachTX9_MiniProject_API.DTOs.UserDtos;
using FluentValidation;

namespace BachTX9_MiniProject_API.Validator
{
    public class UserValidate:AbstractValidator<UserRegisterDto>
    {
        public UserValidate()
        {
            RuleFor(n => n.UserName).NotNull().WithMessage("Not null");
            RuleFor(n => n.Email).EmailAddress().WithMessage("Not null");
            RuleFor(n => n.Password).NotNull().WithMessage("Not null");
        }
    }
}
