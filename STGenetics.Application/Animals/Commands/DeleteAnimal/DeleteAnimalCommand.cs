using ErrorOr;
using MediatR;
using STGenetics.Domain.Entities;

namespace STGenetics.Application.Animals.Commands.DeleteAnimal;

public record DeleteAnimalCommand(int Id) : IRequest<ErrorOr<bool>>;