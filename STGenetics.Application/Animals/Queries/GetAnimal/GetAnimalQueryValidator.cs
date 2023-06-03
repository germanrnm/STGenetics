
using FluentValidation;

namespace STGenetics.Application.Animals.Queries.GetAnimal;
public class GetAnimalQueryValidator : AbstractValidator<GetAnimalQuery>
{
    public GetAnimalQueryValidator() {
        RuleFor(x => x.Id).NotEmpty();
    }
}
