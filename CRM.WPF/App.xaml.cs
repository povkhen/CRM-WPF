using AutoMapper;
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
            

            IoC.Application.GoToPage(
                await IoC.ClientDataStore.HasCredentialsAsync() ?
                ApplicationPage.Home :
                ApplicationPage.Login
                );


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
            IoC.Kernel.Bind<IMapper>().ToConstructor(c => new Mapper(AutoMapperConfig.CreateConfiguration())).InSingletonScope();


            await IoC.ClientDataStore.EnsureDataStoreAsync();

        }
    }
}
