using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Website.DTOs
{
    public class RegisterDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(16,ErrorMessage="UserName Must Contain at Least 8 Characters")]

        [RegularExpression(@"^[A-Za-z0-9_]{4,16}$")]
        [DefaultValue("UserName")]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string EmailId { get; set; } = string.Empty;
        [Required]
        [MinLength(8, ErrorMessage = "Password must contain at least 8 characters")]
        [RegularExpression(@"^[A-Z](?=.*[a-z])(?=.*\d)[A-Za-z\d]*[@#$%&!][A-Za-z\d]*$",
        ErrorMessage = "Password must contain uppercase, lowercase, number and special character")]
        [DefaultValue("Password")]
        public string Password { get; set; } =string.Empty ;
        [Required]
        public string? Confirm_Password { get; set; }
        [Required]
        public DateOnly DateofBirth { get; set; }
    }
}
