using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TreeViewDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [ObservableObject]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = this;

            var rootNode = new GroupGroupTreeNode()
            {
                Name = "Root"
            };

            for (int i = 0; i < 30; i++)
            {
                var group = new EntityGroupTreeNode()
                {
                    Name = $"Group {i + 1}"
                };

                for (int j = 0; j < 300000; j++)
                {
                    group.Children.Add(new EntityTreeNode()
                    {
                        Name = System.IO.Path.GetRandomFileName()
                    });
                }

                rootNode.Children.Add(group);
            }

            RootTreeNodes.Add(rootNode);

            InitializeComponent();
        }

        public ObservableCollection<GroupGroupTreeNode> RootTreeNodes { get; } = new();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddChildCommand))]
        private ITreeNode? _selectedNode;


        public bool CanAddChild()
        {
            return SelectedNode is GroupGroupTreeNode or EntityGroupTreeNode;
        }

        [RelayCommand(CanExecute = nameof(CanAddChild))]
        public void AddChild()
        {
            if (SelectedNode is GroupGroupTreeNode groupGroupTreeNode)
            {
                groupGroupTreeNode.Children.Add(new EntityGroupTreeNode()
                {
                    Name = System.IO.Path.GetRandomFileName()
                });
            }
            else if (SelectedNode is EntityGroupTreeNode entityGroupTreeNode)
            {
                entityGroupTreeNode.Children.Add(new EntityTreeNode()
                {
                    Name = System.IO.Path.GetRandomFileName(),
                });
            }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (sender is not TreeView treeView)
            {
                return;
            }

            SelectedNode = treeView.SelectedItem as ITreeNode;
        }
    }
}