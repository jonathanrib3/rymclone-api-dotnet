using FluentValidation;

namespace RymCloneApi.src.Domain.Validators
{
  public class ArtistValidator: AbstractValidator<Artist>
  {
    public ArtistValidator()
    {
      RuleFor(ar => ar.Name).NotEmpty().MaximumLength(250).MinimumLength(1);
    }
  }
}
