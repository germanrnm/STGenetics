using FluentValidation;

namespace STGenetics.Application.Animals.Commands.AddAnimal;

public class AddAnimalCommandValidator : AbstractValidator<AddAnimalCommand>
{
    public AddAnimalCommandValidator() 
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Breed).NotEmpty();
        RuleFor(x => x.BirthDate).NotEmpty();
        RuleFor(x => x.Sex).NotEmpty();
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.Status).NotEmpty();
    }
}
