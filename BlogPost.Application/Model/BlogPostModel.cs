using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Model
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [Required]
        public string Text { get; set; }
    }
}
