using coreweb.Models;
using FluentValidation;

namespace coreweb.Validators
{
    public class CatAdoptionRequestValidator : AbstractValidator<CatAdoptionRequest>
    {
        public CatAdoptionRequestValidator()
        {
            RuleFor(profile => profile.Cat).NotNull();
            RuleFor(profile => profile.AdoptionRequest).NotNull();
            RuleFor(profile => profile.Cat.Name).NotEmpty();
        }
    }
}
