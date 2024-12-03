using FluentValidation;
using Service.Helper.DTOs.Account;

namespace CompanyApi.Helpers.Validations
{
    public class SignUpDtoValidation : AbstractValidator<SignUpDto>
    {
        public SignUpDtoValidation()
        {
            RuleFor(x => x.FullName).NotNull().WithMessage("FullName cant be null");    
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName required");    
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password required");    
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email required").EmailAddress().WithMessage("Invalid email format");    
        }
    }
}
