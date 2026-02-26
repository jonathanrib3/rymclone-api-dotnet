using FluentValidation;
using RymCloneApi.src.Domain.Entities;

namespace RymCloneApi.src.Domain.Validators
{
  public class ReviewValidator : AbstractValidator<Review>
  {
    public ReviewValidator()
    {
      RuleFor(r => r.Score).NotEmpty().LessThanOrEqualTo(5).GreaterThanOrEqualTo(0);
      RuleFor(r => r.Album).NotEmpty();
      RuleFor(r => r.User).NotEmpty();
      RuleFor(r => r.CreatedAt).NotEmpty();
      RuleFor(r => r.UpdatedAt).NotEmpty();
    }
  }
}
