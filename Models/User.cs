using System.ComponentModel.DataAnnotations;
namespace Website.Models
{
    public class User
    {
        
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string? EmailId { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public DateOnly DateofBirth { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedTime { get; set; }=DateTime.UtcNow;
    }
}
