using BachTX9_MiniProject_API.DTOs.Test;
using FluentValidation;

namespace BachTX9_MiniProject_API.Validator
{
    public class TestValidate:AbstractValidator<AddTestDto>
    {
        public TestValidate() 
        {
            RuleFor(n => n.TestName).NotNull().WithMessage("Not null");
            RuleFor(n => n.Description).NotNull().WithMessage("Not null");
        }
    }
}
