using System.ComponentModel.DataAnnotations;

namespace StudentMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [EmailAddress(ErrorMessage="Enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Age is required")]
        [Range(1,100,ErrorMessage ="Age must be between 1 and 100")]
        public int Age { get; set; }
    }
}
