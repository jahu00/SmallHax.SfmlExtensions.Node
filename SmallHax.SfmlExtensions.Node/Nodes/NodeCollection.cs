using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHax.SfmlExtensions.Nodes
{
    public class NodeCollection : IList<INode>
    {
        protected List<INode> Nodes { get; set; }

        public INode Parent { get; set; }

        public int Count => Nodes.Count;

        public bool IsReadOnly => false;

        public INode this[int index] { get => Nodes[index]; set => Nodes[index] = value; }

        public NodeCollection(INode parent) : base()
        {
            Parent = parent;
            Nodes = new List<INode>();
        }

        public int IndexOf(INode item) => Nodes.IndexOf(item);

        public void Insert(int index, INode item)
        {
            Nodes.Insert(index, item);
            item.Parent = Parent;
        }

        public void RemoveAt(int index)
        {
            Nodes[index].Parent = null;
            Nodes.RemoveAt(index);
        }

        public void Add(INode item)
        {
            Nodes.Add(item);
            item.Parent = Parent;
        }

        public void AddRange(IEnumerable<INode> items)
        {
            Nodes.AddRange(items);
            foreach(var item in items)
            {
                item.Parent = Parent;
            }
        }

        public void Clear()
        {
            Nodes.ForEach(x => { x.Parent = null; });
            Nodes.Clear();
        }

        public bool Contains(INode item) => Nodes.Contains(item);

        public void CopyTo(INode[] array, int arrayIndex) => Nodes.CopyTo(array, arrayIndex);

        public bool Remove(INode item)
        {
            if (Nodes.Remove(item))
            {
                item.Parent = null;
                return true;
            }
            return false;
        }

        public void ForEach(Action<INode> action) => Nodes.ForEach(action);

        public IEnumerator<INode> GetEnumerator() => Nodes.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Nodes.GetEnumerator();
    }
}
