
using Microsoft.AspNetCore.Mvc;
using PetShopProject.Models;
using PetShopProject.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using NuGet.Protocol.Core.Types;

public class AdministratorController : Controller
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IWebHostEnvironment _hostingEnvironment;

    public AdministratorController(IAnimalRepository animalRepository, IWebHostEnvironment hostingEnvironment)
    {
        _animalRepository = animalRepository;
        _hostingEnvironment = hostingEnvironment;
    }

    public IActionResult Index(int? selectedCategoryId) // Shows the full list of animals by default: manageble to sort by category
    {
        var categories = _animalRepository.GetCategories();
        IEnumerable<Animal> animals;

        if (selectedCategoryId.HasValue && selectedCategoryId.Value != 0)
        {
            animals = _animalRepository.GetAnimals().Where(animal => animal.CategoryId == selectedCategoryId.Value);
        }
        else
        {
            animals = _animalRepository.GetAnimals();
        }

        var viewModel = new AdministratorViewModel
        {
            Categories = categories,
            Animals = animals
        };

        ViewBag.SelectedCategoryId = selectedCategoryId.HasValue ? selectedCategoryId.Value : 0;

        return View(viewModel);
    }




    [HttpGet] //retrieves the prompt for adding an animal
    public IActionResult EditAnimal(int id)
    {
        var animal = _animalRepository.GetAnimal(id);
        if (animal == null)
        {
            return NotFound();
        }

        var categories = _animalRepository.GetCategories().Select(c => new SelectListItem
        {
            Value = c.CategoryId.ToString(),
            Text = c.Name
        });

        var viewModel = new AnimalEditViewModel
        {
            Animal = animal,
            AnimalName = animal.Name,
            Age = animal.Age,
            Description = animal.Description,
            SelectedCategoryId = animal.CategoryId,
            Categories = categories
        };

        return View(viewModel);
    }



    [HttpPost] //POST mehod for editing an animal, retrieves the exissting details, I chose a unique way of uploading the image
    public IActionResult EditAnimal(int id, Animal animal, IFormFile pictureName)
    {
        if (ModelState.IsValid)
        {
            if (pictureName != null)
            {
                // Generate a unique file name (e.g., using GUID)
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(pictureName.FileName);

                // Specify the path to save the file
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);

                // Save the file
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pictureName.CopyTo(fileStream);
                }

                // Update the animal object with the new file name
                animal.PictureName = fileName;
            }

            _animalRepository.UpdateAnimal(animal);
            TempData["SuccessMessage"] = "Animal updated successfully";
            return RedirectToAction("index");
        }
        else
        {
            var categories = _animalRepository.GetCategories().Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            });

            var viewModel = new AnimalEditViewModel
            {
                Animal = animal,
                AnimalName = animal.Name,
                Age = animal.Age,
                Description = animal.Description,
                SelectedCategoryId = animal.CategoryId,
                Categories = categories
            };

            return View(viewModel);
        }
    }




    [HttpGet] //retrieves the prompt for adding an animal
    public IActionResult InsertAnimal()
    {
        var categories = _animalRepository.GetCategories();
        var viewModel = new NewAnimalViewModel
        {
            Categories = new SelectList(categories, "CategoryId", "Name"),

        };

        return View(viewModel);
    }
    [HttpPost] //similar approach as the POST method for inserting/adding a new animal
    public IActionResult InsertAnimal(NewAnimalViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            viewModel.Categories = new SelectList(_animalRepository.GetCategories(), "CategoryId", "Name");
            return View(viewModel);
        }

        string fileName = null;

        if (viewModel.PictureName != null)
        {
            fileName = Guid.NewGuid().ToString() + Path.GetExtension(viewModel.PictureName.FileName);
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                viewModel.PictureName.CopyTo(fileStream);
            }
        }

        var newAnimal = new Animal
        {
            Name = viewModel.AnimalName,
            Age = viewModel.Age,
            Description = viewModel.Description,
            PictureName = fileName, 
            CategoryId = viewModel.CategoryId
        };

        _animalRepository.AddAnimal(newAnimal);

        TempData["SuccessMessage"] = "Animal added successfully";

        return RedirectToAction("Index");
    }



    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteAnimal(int id)  //deleting animal from database
    {
        var animal = _animalRepository.GetAnimal(id);

        if (animal == null)
        {
            return NotFound(); 
        }

        _animalRepository.DeleteAnimal(animal);

        TempData["SuccessMessage"] = "Animal successfully deleted"; 

        return RedirectToAction("Index");

    }
}

