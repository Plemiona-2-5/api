using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.Requests
{
    public class CreateUserRequest
    {
        [Required] 
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "The {0} must be between {1} and {2} characters length")]
        public string Nickname { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "The {0} must be between {1} and {2} characters length")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",
            ErrorMessage = "The {0} must contains small, big and alphanumeric letters")]
        public string Password { get; set; }

        [Required]
        [StringLength(18, MinimumLength = 8, ErrorMessage = "The {0} must be between {1} and {2} characters length")]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$",
            ErrorMessage = "The {0} must contains small, big and alphanumeric letters")]
        [Compare("Password")]
        public string ConfirmedPassword { get; set; }
    }
}