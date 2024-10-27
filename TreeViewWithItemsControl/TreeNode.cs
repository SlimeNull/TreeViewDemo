using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TreeViewWithItemsControl
{
    public interface ITreeNode
    {
        IEnumerable<ITreeNode> Children { get; }
    }

    public class GroupGroupTreeNode : DependencyObject, ITreeNode
    {
        public string Name { get; set; } = string.Empty;

        public ObservableCollection<EntityGroupTreeNode> Children { get; } = new();

        IEnumerable<ITreeNode> ITreeNode.Children => Children;
    }

    public class EntityGroupTreeNode : DependencyObject, ITreeNode
    {
        public string Name { get; set; } = string.Empty;

        public ObservableCollection<EntityTreeNode> Children { get; } = new();

        IEnumerable<ITreeNode> ITreeNode.Children => Children;
    }

    public class EntityTreeNode : DependencyObject, ITreeNode
    {
        public string Name { get; set; } = string.Empty;
        public int BlockNumber { get; set; }

        public IEnumerable<ITreeNode> Children
        {
            get
            {
                yield break;
            }
        }
    }
}
