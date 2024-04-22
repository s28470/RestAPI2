using WebApplication2.Models;
using WebApplication2.Repositories;

namespace WebApplication2.AnimalServices;

public class AnimalService : IAnimalService
{
    private IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    

    public ICollection<AnimalDTO> GetAnimals()
    {
        return _animalRepository.GetAnimals();
    }

    public AnimalDTO GetAnimal(int id)
    {
        return _animalRepository.GetAnimal(id);
    }

    public ICollection<AnimalDTO> GetAnimalsOrderedBy(string param = "name")
    {
        return _animalRepository.GetAnimalsOrderedBy(param);
    }

    public void AddAnimal(AnimalDTO animal)
    {
        _animalRepository.AddAnimal(animal);
    }

    public bool EditAnimal(AnimalDTO animal)
    {
        bool presented = _animalRepository.GetAnimals().Any(dbAnimal => dbAnimal.Id == animal.Id );
        if (presented)
        {
            _animalRepository.EditAnimal(animal);
        }
        
        return presented;
    }

    public bool DeleteAnimal(int id)
    {
        bool presented = _animalRepository.GetAnimals().Any(animal => animal.Id == id);
        if (presented)
        {
            _animalRepository.DeleteAnimal(id); 
        }

        return presented;
    }
}