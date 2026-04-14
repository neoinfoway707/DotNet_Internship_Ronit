using System.ComponentModel.DataAnnotations;

namespace TaskDemo.Models
{
    public class Education_Master
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EducationName { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
