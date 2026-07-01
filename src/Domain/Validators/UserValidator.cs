using FluentValidation;
using RymCloneApi.src.Domain.Entities;

namespace RymCloneApi.src.Domain.Validators
{
  public class UserValidator : AbstractValidator<User>
  {
    public UserValidator()
    {
      RuleFor(u => u.Username).MaximumLength(50).NotEmpty();
    }
  }
}
