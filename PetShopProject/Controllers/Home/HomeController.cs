using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using PetShopProject.Repositories;

namespace PetShopProject.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IAnimalRepository _animalRepository;

        public HomeController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IActionResult Index()  //home page: retrieves top 2 most commented animals
        {
            var animals = _animalRepository.GetAnimals().OrderByDescending(a => a.Comments.Count()).Take(2);
            _animalRepository.GenerateCommentsForAnimals(animals);

            return View(animals);
        }


    }

}
