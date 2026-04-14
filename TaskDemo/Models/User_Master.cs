using System.ComponentModel.DataAnnotations;

namespace TaskDemo.Models
{
    public class User_Master
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public string GenderId { get; set; }
        public string? EducationName { get; set; }
        [Required]
        public int EducationId { get; set; }

        public string Email { get; set; }
        [Required]
        [MinLength(7, ErrorMessage = "Password must be at least 7 characters long.")]
        public string Password { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
