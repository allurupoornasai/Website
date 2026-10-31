using System.ComponentModel.DataAnnotations;

namespace Website.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string? EmailId { get; set; }
        [Required]
        public string? Password { get; set; }

    }
}
