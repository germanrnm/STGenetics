using Mapster;
using STGenetics.Application.Animals.Commands.AddAnimal;
using STGenetics.Application.Animals.Commands.DeleteAnimal;
using STGenetics.Application.Animals.Commands.UpdateAnimal;
using STGenetics.Application.Animals.Queries.GetAnimal;
using STGenetics.Application.Animals.Queries.GetAnimals;
using STGenetics.Contracts.Animals;
using STGenetics.Domain.Entities;

namespace STGenetics.UI.Common.Mapping;

public class AnimalMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AnimalRequest, GetAnimalQuery>();
        config.NewConfig<Animal, GetAnimalResponse>();
        config.NewConfig<GetAnimalsQueryResult, GetAnimalsResponse>();
        config.NewConfig<GetAnimalResponse, AddAnimalCommand>();
        config.NewConfig<EditAnimalRequest, AddAnimalCommand>();
        config.NewConfig<EditAnimalRequest, UpdateAnimalCommand>();
        config.NewConfig<AnimalRequest, DeleteAnimalCommand>();
    }
}