
using ErrorOr;
using MediatR;
using STGenetics.Domain.Entities;

namespace STGenetics.Application.Animals.Queries.GetAnimals;
public record GetAnimalsQuery() : IRequest<ErrorOr<GetAnimalsQueryResult>>;
