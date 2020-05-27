using System;
using System.Windows;
using System.Windows.Controls;

namespace CRM.WPF
{
    /// <summary>
    /// The NoFrame attached property for creating a <see cref="Frame"/> that never shows navigation
    /// and keeps the navigation history emptry
    /// </summary>
    public class NoFrameHistory : BaseAttachedProperty<NoFrameHistory, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var frame = (sender as Frame);
            frame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;

            //Clear history on navigate

            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
