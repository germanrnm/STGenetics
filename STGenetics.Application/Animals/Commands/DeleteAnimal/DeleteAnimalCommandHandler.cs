using ErrorOr;
using MediatR;
using STGenetics.Application.Common.Interfaces.Persistence;

namespace STGenetics.Application.Animals.Commands.DeleteAnimal;

public class DeleteAnimalCommandHandler : IRequestHandler<DeleteAnimalCommand, ErrorOr<bool>>
{
    private readonly IAnimalRepository _animalRepository;

    public DeleteAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<ErrorOr<bool>> Handle(DeleteAnimalCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        return _animalRepository.Delete(request.Id);
    }
}
