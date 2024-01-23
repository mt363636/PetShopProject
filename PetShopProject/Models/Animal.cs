using PetShopProject.Attributes;
using System.ComponentModel.DataAnnotations;
namespace PetShopProject.Models

{
    public class Animal
    {
        public int AnimalId { get; set; }
        [Required(ErrorMessage = "Animal Name is required")]
        [StringLength(100, ErrorMessage = "Animal Name must be less than 100 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a positive number")]
        [AgeValidation]
        public int Age { get; set; }
        public string? PictureName { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        [MaxLength(300, ErrorMessage = "Description cannot exceed 300 characters")]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }

}
