
using CRM.CORE;
using System.Threading.Tasks;
using System.Windows;

namespace CRM.WPF
{
    public class UIManager : IUIManager
    {
        /// <summary>
        /// Dispays a single messagebox to the user
        /// </summary>
        /// <param name="viewModel">The view model</param>
        /// <returns></returns>
        public Task ShowMessage(MessageBoxDialogViewModel viewModel)
        {
            return new DialogMessageBox().ShowDialog(viewModel);


        }
    }
}
