
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopProject.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetShopProject.Models
{
    public class AnimalEditViewModel
    {
        public Animal? Animal { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int SelectedCategoryId { get; set; }

        public IEnumerable<SelectListItem>? Categories { get; set; }

        [Required(ErrorMessage = "Animal Name is required")]
        [StringLength(100, ErrorMessage = "Animal Name must be less than 100 characters")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string? AnimalName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a positive number")]
        [AgeValidation]

        public int Age { get; set; }

        [Required(ErrorMessage = "Please upload a JPG/JPEG image.")]
        [AllowedExtensions(new[] { ".jpg", ".jpeg" }, ErrorMessage = "Only JPG/JPEG files are allowed.")]
        public IFormFile? PictureName { get; set; }


        [Required(ErrorMessage = "Please enter a description.")]
        [MaxLength(300, ErrorMessage = "Description cannot exceed 300 characters")]
        public string? Description { get; set; }
    }

}

