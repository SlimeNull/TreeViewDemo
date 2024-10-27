using System.Windows;

namespace TreeViewWithItemsControl
{
    class TreeStructure
    {
        public static bool GetIsExpanded(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsExpandedProperty);
        }

        public static void SetIsExpanded(DependencyObject obj, bool value)
        {
            obj.SetValue(IsExpandedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.RegisterAttached("IsExpanded", typeof(bool), typeof(TreeStructure), new PropertyMetadata(false));
    }
}
