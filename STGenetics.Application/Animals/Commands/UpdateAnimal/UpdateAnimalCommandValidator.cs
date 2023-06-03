using FluentValidation;

namespace STGenetics.Application.Animals.Commands.UpdateAnimal;

public class UpdateAnimalCommandValidator : AbstractValidator<UpdateAnimalCommand>
{
    public UpdateAnimalCommandValidator() 
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Breed).NotEmpty();
        RuleFor(x => x.BirthDate).NotEmpty();
        RuleFor(x => x.Sex).NotEmpty();
        RuleFor(x => x.Price).NotEmpty();
        RuleFor(x => x.Status).NotEmpty();
    }
}
