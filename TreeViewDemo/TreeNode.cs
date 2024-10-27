using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewDemo
{
    public interface ITreeNode
    {
        IEnumerable<ITreeNode> Children { get; }
    }

    public class GroupTreeNode : ITreeNode
    {
        public string Name { get; set; } = string.Empty;

        public ObservableCollection<ITreeNode> Children { get; } = new();

        IEnumerable<ITreeNode> ITreeNode.Children => Children;
    }

    public class EntityTreeNode : ITreeNode
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
