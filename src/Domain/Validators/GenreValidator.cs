using FluentValidation;
using RymCloneApi.src.Domain.Entities;

namespace RymCloneApi.src.Domain.Validators
{
  public class GenreValidator : AbstractValidator<Genre>
  {
    public GenreValidator()
    {
      RuleFor(genre => genre.Name).NotEmpty().MaximumLength(100).MinimumLength(3);
    }
  }
}
