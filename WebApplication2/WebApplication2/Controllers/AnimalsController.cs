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
   
   
   
}