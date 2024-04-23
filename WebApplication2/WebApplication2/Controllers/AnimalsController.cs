using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.AnimalServices;
using WebApplication2.Models;

namespace WebApplication2.Controllers;
[ApiController]
[Route("/api/animals")]
public class AnimalsController
{

   private IAnimalService _animalService;

   public AnimalsController(IAnimalService animalService)
   {
      _animalService = animalService;
   }
   [HttpPost]
   public IResult AddAnimal(AnimalDTO animal)
   {
      _animalService.AddAnimal(animal);
      return Results.Ok();
   }
   

   [HttpDelete]
   public IResult DeleteAnimal(int id)
   {
      bool wasDeleted = _animalService.DeleteAnimal(id);
      if (wasDeleted)
      {
         return Results.Ok();
      }

      return Results.NotFound();
   }

   [HttpPut]
   public IResult EditAnimal(AnimalDTO animal)
   {
      bool wasEdit = _animalService.EditAnimal(animal);
      if (wasEdit)
      {
         return Results.Ok();
      }

      return Results.NotFound();
   }
   
   
   [HttpGet]
   public IResult GetAnimalsOrderedBy(string? param)
   {
      ICollection<AnimalDTO> animals = _animalService.GetAnimalsOrderedBy(param);
      if (animals != null)
      {
         return Results.Ok(animals);
      }

      return Results.BadRequest();
   }
   
   
}