using System.Windows;
using System.Windows.Controls;

namespace TreeViewWithItemsControl
{
    public class MyTreeControl : ItemsControl
    {
        static MyTreeControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyTreeControl), new FrameworkPropertyMetadata(typeof(MyTreeControl)));
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new MyTreeControlItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is MyTreeControlItem;
        }
    }
}
