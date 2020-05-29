using System.Threading.Tasks;

namespace CRM.CORE
{
    public interface IAuthService
    {
        Task LoginAsync(LoginCredentials loginCredentials,  bool loginIsRunning);
        Task RegisterAsync(RegisterCredentials registerCredentials, bool registerIsRunning);
        Task LogoutAsync();
    }
}
