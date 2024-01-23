using System.ComponentModel.DataAnnotations;

namespace PetShopProject.Models
{
    public class DetailViewModel
    {
        public Animal? Animal { get; set; }
        public IEnumerable<Comment>? AnimalComments { get; set; }
        public string? AnimalCategory { get; set; }
        [MaxLength(100, ErrorMessage = "The comment cannot exceed 100 characters.")]
        public string? CommentText { get; set; }
    }
}
