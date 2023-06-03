using ErrorOr;
using MediatR;
using STGenetics.Application.Common.Interfaces.Persistence;
using STGenetics.Domain.Common.Errors;
using STGenetics.Domain.Entities;

namespace STGenetics.Application.Animals.Queries.GetAnimal;

public class GetAnimalQueryHandler : IRequestHandler<GetAnimalQuery, ErrorOr<Animal>>
{
    private readonly IAnimalRepository _animalRepository;

    public GetAnimalQueryHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<ErrorOr<Animal>> Handle(GetAnimalQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_animalRepository.Get(request.Id) is not Animal animal)
            return Errors.AnimalError.AnimalNotFound;
        return animal;
    }
}
