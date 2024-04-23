namespace WebApplication2.Models;

public class AnimalDTO
{
    public int Id { get; init; } 

    public string Name { get; init; } 

    public string Description { get; init; } 

    public string Category { get; init; } 

    public string Area { get; init; }

    public AnimalDTO(int id, string name, string description, string category, string area)
    {
        Id = id;
        Name = name;
        Description = description;
        Category = category;
        Area = area;
    }

    public AnimalDTO(string name, string description, string category, string area)
    {
        Name = name;
        Description = description;
        Category = category;
        Area = area;
    }

    public AnimalDTO()
    {
        
    }
}