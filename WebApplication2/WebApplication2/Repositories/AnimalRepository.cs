using System.Data.SqlClient;
using WebApplication2.Models;

namespace WebApplication2.Repositories;

public class AnimalRepository : IAnimalRepository
{
    private string _connectionString;

    public AnimalRepository()
    {
        _connectionString = "Data Source=localhost;Initial Catalog=master;User ID=sa;Password=VeryStr0ngP@ssw0rd";
    }

    public ICollection<AnimalDTO> GetAnimals()
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = "Select * from Animal";

        using SqlCommand command = new SqlCommand(query,connection);

        using SqlDataReader reader = command.ExecuteReader();
        List<AnimalDTO> animals = new List<AnimalDTO>();
        
        while (reader.Read())
        {
            int id = reader.GetInt32(reader.GetOrdinal("IdAnimal"));
            string name = reader.GetString(reader.GetOrdinal("Name"));
            string description = reader.GetString(reader.GetOrdinal("Description"));
            string category = reader.GetString(reader.GetOrdinal("Category"));
            string area = reader.GetString(reader.GetOrdinal("Area"));

            AnimalDTO animalDto = new AnimalDTO
            {
                Id = id,
                Name = name,
                Description = description,
                Category = category,
                Area = area
            };
            
            animals.Add(animalDto);
        }

        return animals;
    }

    public AnimalDTO GetAnimal(int id)
    {
        using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        sqlConnection.Open();

        string query = "SELECT * FROM ANIMAL WHERE IDANIMAL = @ID";

        using SqlCommand command = new SqlCommand(query,sqlConnection);
        command.Parameters.AddWithValue("ID", id);

        using SqlDataReader reader = command.ExecuteReader();

        reader.Read();
        string name = reader.GetString(reader.GetOrdinal("Name"));
        string description = reader.GetString(reader.GetOrdinal("Description"));
        string category = reader.GetString(reader.GetOrdinal("Category"));
        string area = reader.GetString(reader.GetOrdinal("Area"));

        AnimalDTO animalDto = new AnimalDTO
        {
            Id = id,
            Name = name,
            Description = description,
            Category = category,
            Area = area
        };

        return animalDto;
    }

    public ICollection<AnimalDTO> GetAnimalsOrderedBy(string param = "name")
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string query = $"SELECT * FROM Animal ORDER BY {param}";

        using SqlCommand command = new SqlCommand(query,connection);

        using SqlDataReader reader = command.ExecuteReader();
        List<AnimalDTO> animals = new List<AnimalDTO>();
        
        while (reader.Read())
        {
            int id = reader.GetInt32(reader.GetOrdinal("IdAnimal"));
            string name = reader.GetString(reader.GetOrdinal("Name"));
            string description = reader.GetString(reader.GetOrdinal("Description"));
            string category = reader.GetString(reader.GetOrdinal("Category"));
            string area = reader.GetString(reader.GetOrdinal("Area"));

            AnimalDTO animalDto = new AnimalDTO
            {
                Id = id,
                Name = name,
                Description = description,
                Category = category,
                Area = area
            };
            
            animals.Add(animalDto);
        }

        return animals;
    }

    public AnimalDTO AddAnimal(AnimalDTO animal)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string query = "insert into animal(Name, Description, Category, Area) values (@Name, @Description,@Category,@Area)";
        using SqlCommand command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("Name", animal.Name);
        command.Parameters.AddWithValue("Description", animal.Description);
        command.Parameters.AddWithValue("Category", animal.Category);
        command.Parameters.AddWithValue("Area", animal.Area);


        command.ExecuteNonQuery();
        return animal;
    }

    public AnimalDTO EditAnimal(AnimalDTO animal)
    {
        using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        sqlConnection.Open();

        string query =
            "UPDATE ANIMAL SET NAME=@NAME, DESCRIPTION=@DESCRIPTION, CATEGORY=@CATEGORY, AREA=@AREA WHERE IDANIMAL = @ID";

        using SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("NAME", animal.Name);
        command.Parameters.AddWithValue("DESCRIPTION", animal.Description);
        command.Parameters.AddWithValue("CATEGORY", animal.Category);
        command.Parameters.AddWithValue("AREA", animal.Area);
        command.Parameters.AddWithValue("ID", animal.Id);

        command.ExecuteNonQuery();
        return animal;
    }

    public void DeleteAnimal(int id)
    {
        using SqlConnection sqlConnection = new SqlConnection(_connectionString);
        sqlConnection.Open();

        string query = "Delete from Animal where idAnimal = @id";
        SqlCommand command = new SqlCommand(query, sqlConnection);
        command.Parameters.AddWithValue("id", id);

        command.ExecuteNonQuery();
    }
}