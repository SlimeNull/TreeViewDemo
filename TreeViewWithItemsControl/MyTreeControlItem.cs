using System.Windows;
using System.Windows.Controls;

namespace TreeViewWithItemsControl
{
    public class MyTreeControlItem : ContentControl
    {
        static MyTreeControlItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyTreeControlItem), new FrameworkPropertyMetadata(typeof(MyTreeControlItem)));
        }



        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public DataTemplate ContentTemplate
        {
            get { return (DataTemplate)GetValue(ContentTemplateProperty); }
            set { SetValue(ContentTemplateProperty, value); }
        }

        public DataTemplateSelector ContentTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty); }
            set { SetValue(ContentTemplateSelectorProperty, value); }
        }




        public static readonly DependencyProperty ContentProperty =
            ContentControl.ContentProperty.AddOwner(typeof(MyTreeControlItem));

        public static readonly DependencyProperty ContentTemplateProperty =
            ContentControl.ContentTemplateProperty.AddOwner(typeof(MyTreeControlItem));

        public static readonly DependencyProperty ContentTemplateSelectorProperty =
            ContentControl.ContentTemplateSelectorProperty.AddOwner(typeof(MyTreeControlItem));


    }
}
