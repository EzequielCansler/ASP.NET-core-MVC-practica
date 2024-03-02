using System.ComponentModel.DataAnnotations;

namespace NehuenOrg.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; } = string.Empty;
        [Required]
        public string? CategoryDescription { get; set; } = string.Empty;
    }
}
