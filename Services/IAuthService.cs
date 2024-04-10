namespace CookieBasedAuthentication.Services
{
    public interface IAuthService
    {
        Task<bool> Login();
    }
}
