namespace ApplicationCore.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string userId);
    }
}