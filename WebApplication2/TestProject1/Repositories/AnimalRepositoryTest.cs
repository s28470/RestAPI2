using System.Data.SqlClient;
using JetBrains.Annotations;
using WebApplication2.AnimalServices;
using WebApplication2.Models;
using WebApplication2.Repositories;

namespace TestProject1.Repositories;

[TestSubject(typeof(AnimalRepository))]
public class AnimalRepositoryTest
{
    private string _connectionString = "";
    
    public void SetUp()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        builder.DataSource = "localhost";
        builder.InitialCatalog = "master";
        builder.UserID = "sa";
        builder.Password = "VeryStr0ngP@ssw0rd";
        

        _connectionString = builder.ConnectionString;

        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        string tableName = "dbo.Animal";
        string sqlQuary = $"TRUNCATE TABLE {tableName}";
        
        SqlCommand command = new SqlCommand(sqlQuary,connection);

        command.ExecuteNonQuery();
        
        string quary2 = @"
                INSERT INTO Animal (Name, Description, Category, Area) VALUES
                ('Lion', 'Large carnivorous feline with golden fur.', 'Mammal', 'Africa'),
                ('Tiger', 'Striped big cat native to various parts of Asia.', 'Mammal', 'Asia'),
                ('Elephant', 'Giant herbivorous mammal with a long trunk.', 'Mammal', 'Africa, Asia'),
                ('Giraffe', 'Tall herbivorous mammal with a long neck.', 'Mammal', 'Africa'),
                ('Panda', 'Large bear-like mammal native to China.', 'Mammal', 'Asia'),
                ('Kangaroo', 'Marsupial with large hind legs for hopping.', 'Mammal', 'Australia'),
                ('Eagle', 'Large bird of prey with keen eyesight.', 'Bird', 'Various'),
                ('Orca', 'Large black and white marine mammal, also known as a killer whale.', 'Mammal', 'Worldwide Oceans'),
                ('Dolphin', 'Highly intelligent marine mammal known for its playful behavior.', 'Mammal', 'Worldwide Oceans'),
                ('Shark', 'Predatory fish with cartilaginous skeleton and sharp teeth.', 'Fish', 'Worldwide Oceans')
            ";

        command = new SqlCommand(quary2, connection);
        command.ExecuteNonQuery();
        
    }

    [Fact]
    public void TestDb()
    {
        SetUp();
        
    }
    
    [Fact]
    public void GetAnimalsTest()
    {
        SetUp();
        IAnimalRepository animalRepository = new AnimalRepository();

        int count = animalRepository.GetAnimals().Count;
        
        Assert.Equal(10, count);
    }



    [Fact]
    public void GetAnimalTest()
    {
        SetUp();
        IAnimalRepository animalRepository = new AnimalRepository();
        int id = 1;

        AnimalDTO animalDto = animalRepository.GetAnimal(id);
        
        Assert.Equal("Lion", animalDto.Name);
    }

    [Fact]
    public void GetAnimalsOrderedByNameTest()
    {
        SetUp();
        string param = "name";
        IAnimalRepository animalRepository = new AnimalRepository();
        int count = animalRepository.GetAnimals().Count;


        List<AnimalDTO> animalsOrderedByName = animalRepository.GetAnimalsOrderedBy(param).ToList();

        int i = animalsOrderedByName.Count;
        
        Assert.Equal(count,i);
    }


    [Fact]
    public void AddAnimalTest()
    {
        SetUp();
        int oldAnimalsNumber = 10;
        AnimalRepository animalRepository = new AnimalRepository();
        AnimalDTO animalDto = new AnimalDTO("string name", "string description", "string category", "string area");

        animalRepository.AddAnimal(animalDto);
        int count = animalRepository.GetAnimals().Count;
        
        Assert.Equal(oldAnimalsNumber + 1 , count);
    }



    [Fact]
    public void EditAnimalTestIfAnimalIsPresented()
    {
        SetUp();
        var animalDto = new AnimalDTO(1,"changed", "changed", "changed", "changed");
        IAnimalRepository animalRepository = new AnimalRepository();

        animalRepository.EditAnimal(animalDto);
        string name = animalRepository.GetAnimal(animalDto.Id).Name;
        
        
        Assert.Equal("changed" , name);
    }

    [Fact]
    public void DeleteAnimalTest()
    {
        SetUp();
        int oldNumberAnimals = 10;
        IAnimalRepository repository = new AnimalRepository();

        repository.DeleteAnimal(1);
        int count = repository.GetAnimals().Count;
        
        Assert.Equal(oldNumberAnimals - 1, count);
    }
    
}