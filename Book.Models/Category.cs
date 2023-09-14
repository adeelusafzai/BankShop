using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Book.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage ="Category is required")]
        [MaxLength(30, ErrorMessage = "Max Length is 30 charaters")]
        [DisplayName("Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Display Order is required")]
        [Range(1,100, ErrorMessage = "Display Order must be between 1-100")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

    }
}
