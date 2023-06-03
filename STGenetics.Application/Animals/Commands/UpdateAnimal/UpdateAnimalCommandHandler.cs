
using ErrorOr;
using MediatR;
using STGenetics.Application.Common.Interfaces.Persistence;
using STGenetics.Domain.Common.Errors;
using STGenetics.Domain.Entities;

namespace STGenetics.Application.Animals.Commands.UpdateAnimal;

public class UpdateAnimalCommandHandler : IRequestHandler<UpdateAnimalCommand, ErrorOr<Animal>>
{
    private readonly IAnimalRepository _animalRepository;

    public UpdateAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<ErrorOr<Animal>> Handle(UpdateAnimalCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var animal = new Animal
        {
            Id = request.Id,
            Name = request.Name,
            BirthDate = request.BirthDate,
            Breed = request.Breed,
            Price = request.Price,
            Sex = request.Sex,
            Status = request.Status,
        };
        if (!_animalRepository.Update(animal))
            return Errors.AnimalError.UpdateAnimalFail;
        return animal;
    }
}
