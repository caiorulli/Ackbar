using Ackbar.Models;

namespace Ackbar.Services
{
    public interface ILoginService
    {
        User Authenticate(string email, string password);
        string GenerateJwt(User user);
        User Signup(string email, string password);
    }
}