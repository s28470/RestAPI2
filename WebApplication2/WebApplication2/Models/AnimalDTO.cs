namespace WebApplication2.Models;

public class AnimalDTO(int id, string name, string description, string category, string area)
{
    public int Id { get; } = id;

    public string Name { get; } = name;

    public string Description { get; } = description;

    public string Category { get; } = category;

    public string Area { get; } = area;
    
}