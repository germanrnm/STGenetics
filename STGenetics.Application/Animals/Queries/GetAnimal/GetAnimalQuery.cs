using ErrorOr;
using MediatR;
using STGenetics.Domain.Entities;

namespace STGenetics.Application.Animals.Queries.GetAnimal;
public record GetAnimalQuery(int Id) : IRequest<ErrorOr<Animal>>;
