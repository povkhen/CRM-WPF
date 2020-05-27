using System.Threading.Tasks;

namespace CRM.CORE
{
    public interface IAuthService
    {
        Task LoginAsync(object parameter, bool loginIsRunning);
    }
}
