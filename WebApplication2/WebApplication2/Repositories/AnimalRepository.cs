using WebApplication2.Models;

namespace WebApplication2.Repositories;

public class AnimalRepository : IAnimalRepository
{
    
    public ICollection<AnimalDTO> GetAnimals()
    {
        throw new NotImplementedException();
    }

    public AnimalDTO GetAnimal(int id)
    {
        throw new NotImplementedException();
    }

    public ICollection<AnimalDTO> GetAnimalsOrderedBy(string param = "name")
    {
        throw new NotImplementedException();
    }

    public AnimalDTO AddAnimal(AnimalDTO animal)
    {
        throw new NotImplementedException();
    }

    public AnimalDTO EditAnimal(AnimalDTO animal)
    {
        throw new NotImplementedException();
    }

    public void DeleteAnimal(int id)
    {
        throw new NotImplementedException();
    }
}