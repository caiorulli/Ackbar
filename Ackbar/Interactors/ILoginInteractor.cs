using Ackbar.Models;
using Ackbar.Models.Entities;

namespace Ackbar.Interactors
{
    public interface ILoginInteractor
    {
        User Authenticate(string email, string password);
        string GenerateJwt(User user);
        User Signup(string email, string password);
    }
}