using Ackbar.Models;

namespace Ackbar.Interactors
{
    public interface ILoginInteractor
    {
        User Authenticate(string username, string password);
        string GenerateJwt(User user);
        User Signup(string username, string password);
    }
}