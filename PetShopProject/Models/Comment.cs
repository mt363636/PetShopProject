using System.ComponentModel.DataAnnotations;

namespace PetShopProject.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
        [MaxLength(100, ErrorMessage = "The comment cannot exceed 100 characters.")]
        public string? CommentText { get; set; }
    }
}
