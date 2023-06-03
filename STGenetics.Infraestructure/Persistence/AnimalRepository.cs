using JsonFlatFileDataStore;
using STGenetics.Domain.Entities;
using STGenetics.Application.Common.Interfaces.Persistence;

namespace STGenetics.Infraestructure.Persistence;

public class AnimalRepository : IAnimalRepository
{
    private IDocumentCollection<Animal> _animals;
    private readonly DataStore _store;

    public AnimalRepository()
    {
        _store = new DataStore("STGeneticsDb.json");
        _animals = _store.GetCollection<Animal>();
    }

    public List<Animal> Get(Animal animal) { 
        return _animals.AsQueryable()
                       .Where( a => (a.Name == animal.Name || animal.Name == "")
                                    || (a.Breed == animal.Breed || animal.Breed == "")
                                    || (a.BirthDate == animal.BirthDate || animal.Breed is null)
                                    || (a.Sex == animal.Sex || animal.Sex == "")
                                    || (a.Price == animal.Price || animal.Price == 0)
                       )
                       .ToList();
    }

    public List<Animal> Get()
    {
        return _animals.AsQueryable()
                       .ToList();
    }

    public Animal? Get(int id)
    {
        return _animals.AsQueryable()
                       .Where(a => a.Id == id)
                       .FirstOrDefault();
    }

    public bool Add(Animal animal)
    {
        return _animals.InsertOne(animal);
    }

    public bool Add(List<Animal> animals)
    {
        return _animals.InsertMany(animals);
    }

    public bool Update(Animal animal)
    {
        return _animals.UpdateOne(animal.Id, animal);
    }

    public bool Update(List<Animal> animals)
    {
        bool result = false;
        foreach (var animal in animals)
        {
            result = result || _animals.UpdateOne(animal.Id, animal);
        }
        return result;
    }

    public bool Delete(int id)
    {
        return _animals.DeleteOne(id);
    }
}
