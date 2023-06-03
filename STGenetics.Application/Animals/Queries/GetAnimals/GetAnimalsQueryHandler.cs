using ErrorOr;
using MediatR;
using STGenetics.Application.Common.Interfaces.Persistence;
using STGenetics.Domain.Common.Errors;
using STGenetics.Domain.Entities;

namespace STGenetics.Application.Animals.Queries.GetAnimals;

public class GetAnimalsQueryHandler : IRequestHandler<GetAnimalsQuery, ErrorOr<GetAnimalsQueryResult>>
{
    private readonly IAnimalRepository _animalRepository;

    public GetAnimalsQueryHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<ErrorOr<GetAnimalsQueryResult>> Handle(GetAnimalsQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        if (_animalRepository.Get() is not List<Animal> animals)
            return Errors.AnimalError.AnimalNotFound;
        return new GetAnimalsQueryResult(animals);
    }
}
