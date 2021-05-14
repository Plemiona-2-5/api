namespace ApplicationCore.Contract.Requests
{
    public class ConfirmEmailRequest
    {
        public string Email { get; set; }
        public string EmailConfirmationToken { get; set; }
    }
}