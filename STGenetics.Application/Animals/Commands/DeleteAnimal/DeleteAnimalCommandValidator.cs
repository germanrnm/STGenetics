using FluentValidation;

namespace STGenetics.Application.Animals.Commands.DeleteAnimal;

public class DeleteAnimalCommandValidator : AbstractValidator<DeleteAnimalCommand>
{
    public DeleteAnimalCommandValidator() 
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}
