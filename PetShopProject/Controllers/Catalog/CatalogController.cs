using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using PetShopProject.Models;
using PetShopProject.Repositories;

namespace PetShopProject.Controllers.Catalog
{
    public class CatalogController : Controller
    {
        private readonly IAnimalRepository _animalRepository;

        public CatalogController(IAnimalRepository animalRepository)
        {
            _animalRepository = animalRepository;
        }

        public IActionResult CatalogPage(int id = 1) //catalog shows mammal as default category, manageable to chose the category 
        {
            ViewBag.CurrentCategory = _animalRepository.GetAnimalCategoryName(id);
            ViewBag.CategoryId = id;
            ViewBag.Categories = _animalRepository.GetCategories().ToList();
            var animalsInCategory = _animalRepository.GetAnimals().Where(anm => anm.CategoryId == id);
            return View(animalsInCategory);
        }

        [HttpPost]
       
        public IActionResult AddComment(int animalId, string commentMessage) //handles the process of adding the comment
        {
            if (!string.IsNullOrEmpty(commentMessage))
            {
                Comment newComment = new Comment
                {
                    AnimalId = animalId,
                    CommentText = commentMessage,
                };

                _animalRepository.AddComment(newComment);
                _animalRepository.Save();
            }

            return RedirectToAction("DetailPage", new { id = animalId });
        }


        public IActionResult DetailPage(int id) //shows the detail page oof the animal: shows details such as age,existing comments, name and description
        {
            var animal = _animalRepository.GetAnimals().FirstOrDefault(an => an.AnimalId == id);
            if (animal != null)
            {
                var model = new DetailViewModel()
                {
                    Animal = animal,
                    AnimalCategory = _animalRepository.GetAnimalCategoryName(animal.CategoryId),
                    AnimalComments = animal.Comments
                };
                return View(model);
            }
            return RedirectToAction("CatalogPage");
        }

        [HttpPost]
        public IActionResult DetailPage(int AnimalId, string CommentText)
        {
            var animal = _animalRepository.GetAnimals().FirstOrDefault(an => an.AnimalId == AnimalId);

            if (animal != null && !string.IsNullOrEmpty(CommentText))
            {
                animal.Comments.Add(new Comment() { CommentText = CommentText });
                _animalRepository.Save(); // Assuming a method to save changes
            }
            else
            {
                // Handle the case where the comment is empty
                ModelState.AddModelError("CommentText", "Comment cannot be empty.");
            }

            // Redirect back to the DetailPage
            var model = new DetailViewModel()
            {
                Animal = animal,
                AnimalCategory = _animalRepository.GetAnimalCategoryName(animal.CategoryId),
                AnimalComments = animal.Comments
            };

            return View(model);
        }


    }
}
