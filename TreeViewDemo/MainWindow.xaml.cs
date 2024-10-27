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

            var rootNode = new GroupTreeNode()
            {
                Name = "Root"
            };

            for (int i = 0; i < 30; i++)
            {
                var group = new GroupTreeNode()
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

        public ObservableCollection<GroupTreeNode> RootTreeNodes { get; } = new();

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(AddGroupChildCommand))]
        [NotifyCanExecuteChangedFor(nameof(AddEntityChildCommand))]
        private ITreeNode? _selectedNode;


        public bool CanAddChild()
        {
            return SelectedNode is GroupTreeNode;
        }

        [RelayCommand(CanExecute = nameof(CanAddChild))]
        public void AddGroupChild()
        {
            if (SelectedNode is GroupTreeNode groupGroupTreeNode)
            {
                groupGroupTreeNode.Children.Add(new GroupTreeNode()
                {
                    Name = System.IO.Path.GetRandomFileName()
                });
            }
        }

        [RelayCommand(CanExecute = nameof(CanAddChild))]
        public void AddEntityChild()
        {
            if (SelectedNode is GroupTreeNode groupGroupTreeNode)
            {
                groupGroupTreeNode.Children.Add(new EntityTreeNode()
                {
                    Name = System.IO.Path.GetRandomFileName()
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