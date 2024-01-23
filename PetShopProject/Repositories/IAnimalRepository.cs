using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;

namespace PetShopProject.Repositories
{
    public interface IAnimalRepository
    {
        IEnumerable<Animal> GetAnimals();
        Animal GetAnimal(int id);
        IEnumerable<Comment> GetCommentsForAnimal(int animalId);
        string GetAnimalCategoryName(int id);
        IEnumerable<Category> GetCategories();
        void AddComment(Comment comment);
        void Save();
        void GenerateCommentsForAnimals(IEnumerable<Animal> animals);
        void AddAnimal(Animal animal); 
        void DeleteAnimal(Animal animal); 
        void UpdateAnimal(Animal animal); 
    }
}
