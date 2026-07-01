using FluentValidation;
using RymCloneApi.src.Domain.Entities;

namespace RymCloneApi.src.Domain.Validators
{
  public class AlbumValidator: AbstractValidator<Album>
  {
    public AlbumValidator()
    {
      RuleFor(ar => ar.Title).NotEmpty().MaximumLength(250);
      RuleFor(ar => ar.ReleaseDate).NotEmpty();
      RuleFor(ar => ar.Artist).NotEmpty();
      RuleFor(ar => ar.Genres).NotEmpty();
    }
  }
}
