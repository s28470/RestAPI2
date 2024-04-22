using WebApplication2.Models;

namespace WebApplication2.Repositories;

public interface IAnimalRepository
{
    ICollection<AnimalDTO> GetAnimals();

    AnimalDTO GetAnimal(int id);
    
    ICollection<AnimalDTO> GetAnimalsOrderedBy(string param="name");
    
    AnimalDTO AddAnimal(AnimalDTO animal);

    AnimalDTO EditAnimal(AnimalDTO animal);
    
    void DeleteAnimal(int id);


}