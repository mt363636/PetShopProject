using Microsoft.EntityFrameworkCore;
using PetShopProject.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace PetShopProject.Data
{
    public class PetShopDbContext : DbContext
    {
        public PetShopDbContext(DbContextOptions<PetShopDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //creating the categories
        {
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Mammal" },
                new { CategoryId = 2, Name = "Reptile" },
                new { CategoryId = 3, Name = "Bird" },
                new { CategoryId = 4, Name = "Aquatic" }
            );
            //creating the rest of data
            modelBuilder.Entity<Animal>().HasData(
                new { AnimalId = 1, Name = "Dog", Age = 3, PictureName = "dog.jpg", Description = "Dogs are loyal and friendly companions known for their diverse breeds, from playful and energetic to calm and protective.", CategoryId = 1 },
                new { AnimalId = 2, Name = "Cat", Age = 2, PictureName = "cat.jpg", Description = "Cats are independent yet affectionate animals. They vary in personality from playful and curious to reserved and observant.", CategoryId = 1 },
                new { AnimalId = 3, Name = "Parrot", Age = 4, PictureName = "parrot.jpg", Description = "Parrots are colorful birds known for their ability to mimic human speech. They're social creatures and require interaction and mental stimulation.", CategoryId = 3 },
                new { AnimalId = 4, Name = "Snake", Age = 5, PictureName = "snake.jpg", Description = "Snakes are reptiles that come in various sizes and colors. They're known for their unique movement and diverse species, from non-venomous to venomous.", CategoryId = 2 },
                new { AnimalId = 5, Name = "Fish", Age = 1, PictureName = "fish.jpg", Description = "Fish encompass a wide variety of aquatic animals, each with its unique colors, shapes, and behaviors. They thrive in different water environments.", CategoryId = 4 },
                new { AnimalId = 6, Name = "Hamster", Age = 1, PictureName = "hamster.jpg", Description = "Hamsters are small rodents known for their playful and energetic nature. They're popular as pets due to their size and low maintenance.", CategoryId = 1 },
                new { AnimalId = 7, Name = "Lizard", Age = 2, PictureName = "lizard.jpg", Description = "Lizards are reptiles that vary greatly in size, color, and behavior. They range from small geckos to larger iguanas and are found in diverse habitats.", CategoryId = 2 },
                new { AnimalId = 8, Name = "Guinea Pig", Age = 2, PictureName = "guinea_pig.jpg", Description = "Guinea pigs are social and gentle rodents. They're known for their vocalizations and are popular pets due to their friendly demeanor.", CategoryId = 1 },
                new { AnimalId = 9, Name = "Parakeet", Age = 3, PictureName = "parakeet.jpg", Description = "Parakeets, or budgerigars, are small parrots with vibrant plumage. They're intelligent and can be trained to perform various tricks.", CategoryId = 3 },
                new { AnimalId = 10, Name = "Turtle", Age = 7, PictureName = "turtle.jpg", Description = "Turtles are reptiles with shells protecting their bodies. They're known for their slow movement and longevity, living in both aquatic and terrestrial environments.", CategoryId = 4 },
                new { AnimalId = 11, Name = "Rabbit", Age = 2, PictureName = "rabbit.jpg", Description = "Rabbits are small mammals known for their long ears and hopping gait. They're social animals and require mental and physical stimulation.", CategoryId = 1 },
                new { AnimalId = 12, Name = "Gecko", Age = 3, PictureName = "gecko.jpg", Description = "Geckos are small lizards known for their ability to climb walls. They come in various colors and patterns and are popular as pets.", CategoryId = 2 },
                new { AnimalId = 13, Name = "Canary", Age = 1, PictureName = "canary.jpg", Description = "Canaries are small songbirds known for their melodious singing. They're sociable and require adequate space to fly and explore.", CategoryId = 3 },
                new { AnimalId = 14, Name = "Goldfish", Age = 1, PictureName = "goldfish.jpg", Description = "Goldfish are colorful freshwater fish known for their vibrant scales and varied fin shapes. They're popular pets and have a long history of domestication.", CategoryId = 4 },
                new { AnimalId = 15, Name = "Hedgehog", Age = 2, PictureName = "hedgehog.jpg", Description = "Hedgehogs are small spiny mammals with a nocturnal lifestyle. They're characterized by their spiky coat and tendency to curl into a ball for protection.", CategoryId = 1 },
                new { AnimalId = 16, Name = "Crocodile", Age = 5, PictureName = "crocodile.jpg", Description = "Crocodiles are large reptiles found in tropical regions. They're apex predators known for their powerful jaws and stealthy hunting abilities.", CategoryId = 2 },
                new { AnimalId = 17, Name = "Cockatoo", Age = 4, PictureName = "cockatoo.jpg", Description = "Cockatoos are large parrots known for their prominent crests and sociable nature. They require social interaction and mental stimulation.", CategoryId = 3 },
                new { AnimalId = 18, Name = "Shark", Age = 6, PictureName = "shark.jpg", Description = "Sharks are apex predators of the ocean known for their streamlined bodies and sharp teeth. They play a crucial role in marine ecosystems.", CategoryId = 4 },
                new { AnimalId = 19, Name = "Chinchilla", Age = 3, PictureName = "chinchilla.jpg", Description = "Chinchillas are small rodents with soft fur and a playful demeanor. They're known for their agility and require dust baths to maintain thei", CategoryId = 1 },
                new { AnimalId = 20, Name = "Iguana", Age = 4, PictureName = "iguana.jpg", Description = "Iguanas are large lizards with distinct dorsal spines. They're herbivores and are often found basking in the sun for warmth.", CategoryId = 2 }
            );
        }

    }

}
