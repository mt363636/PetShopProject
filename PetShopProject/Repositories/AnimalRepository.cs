using Microsoft.EntityFrameworkCore;
using PetShopProject.Data;
using PetShopProject.Models;

namespace PetShopProject.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Animal> GetAnimals()
        {
            return _context.Animals.Include(anm => anm.Comments);
        }
        public Animal GetAnimal(int id) //gets animal by id
        {
            return _context.Animals.FirstOrDefault(an => an.AnimalId == id);
        }

        public IEnumerable<Comment> GetCommentsForAnimal(int animalId)
        {
            return _context.Comments.Where(c => c.AnimalId == animalId).ToList();
        }

        public string GetAnimalCategoryName(int id)
        {
            return _context.Categories.First(cat => cat.CategoryId == id)?.Name;
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void AddAnimal(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
        }

        public void DeleteAnimal(Animal animal)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }

        public void UpdateAnimal(Animal animal)
        {
            _context.Entry(animal).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void GenerateCommentsForAnimals(IEnumerable<Animal> animals) //generates random comments in random amount to the animals from the list of strings below
        {
            if (!_context.Comments.Any())
            {
                var animalsFromDb = _context.Animals.ToList(); 

                var random = new Random();
                var comments = new List<string>
    {
       "I love this animal!",
    "Very naughty!",
    "Amazing companion!",
    "so cute!",
    "An amazing creature!",
    "So much personality!",
    "Very loyal!",
    "So much fun!",
    "Very intelligent!",
    "So lovely!",
    "Amazing instincts!",
    "So much energy!",
    "Very curious!",
    "So much love!",
    "amazing beauty!",
    "So much joy!",
    "Very affectionate!",
    "So much character!",
    "Incredible power!",
    "So much wind!",
    "Very entertaining!",
    "So much grace!",
    "Incredible speed!",
    "So much magic!",
    "Very royal!",
    "So disgusting!",
    "Incredible agility!",
    "So much cutie!",
    "Very photogenic!"

    };

                var maxCommentsPerAnimal = 30; 

                foreach (var animal in animalsFromDb)
                {
                    var numberOfComments = random.Next(1, maxCommentsPerAnimal + 1); 
                    for (int i = 0; i < numberOfComments; i++)
                    {
                        var comment = new Comment
                        {
                            CommentText = comments[random.Next(comments.Count)], 
                            AnimalId = animal.AnimalId 
                        };

                        _context.Comments.Add(comment); 
                    }
                }

                _context.SaveChanges();
            }

        }
  
    }

}
