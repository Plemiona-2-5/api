using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Contract.Requests
{
    public class ConfirmEmailRequest
    {
        [Required] 
        [EmailAddress] 
        public string Email { get; set; }

        [Required] 
        public string EmailConfirmationToken { get; set; }
    }
}