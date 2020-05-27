using CRM.CORE;
using System.Security;

namespace CRM.WPF
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<RegisterViewModel>, IHavePassword
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;

    }
}
