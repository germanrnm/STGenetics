
using ErrorOr;
using MediatR;
using STGenetics.Application.Common.Interfaces.Persistence;
using STGenetics.Domain.Common.Errors;
using STGenetics.Domain.Entities;

namespace STGenetics.Application.Animals.Commands.AddAnimal;

public class AddAnimalCommandHandler : IRequestHandler<AddAnimalCommand, ErrorOr<Animal>>
{
    private readonly IAnimalRepository _animalRepository;

    public AddAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<ErrorOr<Animal>> Handle(AddAnimalCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        var animal = new Animal
        {
            Name = request.Name,
            BirthDate = request.BirthDate,
            Breed = request.Breed,
            Price = request.Price,
            Sex = request.Sex,
            Status = request.Status,
        };
        if (!_animalRepository.Add(animal))
            return Errors.AnimalError.CreateAnimalFail;
        return animal;
    }
}
