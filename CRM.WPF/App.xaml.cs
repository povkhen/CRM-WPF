using CRM.CORE;
using CRM.DATA;
using CRM.HelperLogic;
using System.Threading.Tasks;
using System.Windows;

namespace CRM.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Custom startup to load IoC
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await ApplicationSetupAsync();


            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        

        /// <summary>
        /// Configures our application ready for use
        /// </summary>
        private async Task ApplicationSetupAsync()
        {
            Framework.Construct<DefaultFrameworkConstruction>()
                .UseClientDataStore()
                .Build();

            IoC.Setup();
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());
            IoC.Kernel.Bind<IAuthService>().ToConstant(new AuthService());

            await IoC.ClientDataStore.EnsureDataStoreAsync();

        }
    }
}
