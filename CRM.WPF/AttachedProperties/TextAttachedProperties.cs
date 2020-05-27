using System.Windows;
using System.Windows.Controls;

namespace CRM.WPF
{
    /// <summary>
    /// Focuses (keyboard focus) this elemtnt on load
    /// </summary>
    public class IsFocusedProperty : BaseAttachedProperty<IsFocusedProperty, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(sender is Control control))
                return;

            var contr = sender as Control;
            contr.Loaded += (s, se) => contr.Focus();
        }
    }
}
