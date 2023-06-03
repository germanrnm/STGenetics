using STGenetics.Domain.Entities;

namespace STGenetics.Application.Common.Interfaces.Persistence;

public interface IAnimalRepository
{
    List<Animal> Get(Animal animal);
    List<Animal> Get();
    Animal? Get(int id);
    bool Add(Animal animal);
    bool Add(List<Animal> animals);
    bool Update(Animal animal);
    bool Update(List<Animal> animals);
    bool Delete(int id);
}
