using WebApplication2.Models;

namespace WebApplication2.AnimalServices;

public interface IAnimalService
{
    ICollection<AnimalDTO> GetAnimals();

    AnimalDTO GetAnimal(int id);
    
    ICollection<AnimalDTO> GetAnimalsOrderedBy(string param="name");
    
    void AddAnimal(AnimalDTO animal);

    bool EditAnimal(AnimalDTO animal);
    
    bool DeleteAnimal(int id);
    
}