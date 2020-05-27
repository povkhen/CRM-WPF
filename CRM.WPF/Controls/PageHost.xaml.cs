using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CRM.WPF
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Properties


        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CurrentPage"/> as dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        #endregion

        #region Property Changed Evenets

        /// <summary>
        /// Called when <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newPageFrame = (d as PageHost).NewPage;
            var oldPageFrame = (d as PageHost).OldPage;

            //Store the curent page content as the old page
            var oldPageContent = newPageFrame.Content;
            newPageFrame.Content = null;

            oldPageFrame.Content = oldPageContent;

            if (oldPageContent is BasePage oldPage)
            {
                oldPage.ShouldAnimateOut = true;
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith(t =>
                {
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                    
                });
            }



            newPageFrame.Content = e.NewValue;

        } 
        #endregion




        #region Contsructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageHost()
        {

            InitializeComponent();

        } 

        #endregion

    }
}
