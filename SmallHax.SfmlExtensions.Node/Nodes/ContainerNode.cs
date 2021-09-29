using SFML.Graphics;
using SmallHax.SfmlExtensions.Events;
using SmallHax.SfmlExtensions.Nodes;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHax.SfmlExtensions.Nodes
{
    public class ContainerNode : Transformable, INode, IClickable
    {
        #region Properties
        public INode Parent { get; set; }
        public bool Visible { get; set; } = true;
        public int ZIndex { get; set; } = 0;

        public NodeCollection Children { get; set; }
        #endregion

        #region Events
        public event EventHandler<MouseClickEventArgs> Click;
        #endregion

        #region Constructors
        public ContainerNode(params INode[] children) : this()
        {
            Children.AddRange(children);
        }

        public ContainerNode() : base()
        {
            Children = new NodeCollection(this);
        }
        #endregion

        public virtual FloatRect GetGlobalBounds()
        {
            return GetBounds((node) => { return node.GetGlobalBounds(); });
        }

        /*public FloatRect GetLocalBounds()
        {
            return GetBounds((node) => { return node.GetLocalBounds(); });
        }*/

        /// <summary>
        /// Computes and returns bounds baased on children bounds
        /// </summary>
        /// <param name="getBoundsFunc"></param>
        /// <returns></returns>
        protected FloatRect GetBounds(Func<INode,FloatRect> getBoundsFunc)
        {
            var result = new FloatRect();
            var childrenBounds = Children.Select(x => Transform.TransformRect(getBoundsFunc(x)));
            result.Left = childrenBounds.Min(x => (float?)x.Left) ?? Position.X;
            result.Top = childrenBounds.Min(x => (float?)x.Top) ?? Position.Y;

            result.Width = childrenBounds.Max(x => (float?)(x.Left + x.Width - Position.X)) ?? 0;
            result.Height = childrenBounds.Max(x => (float?)(x.Top + x.Height - Position.Y)) ?? 0;
            return result;
        }

        /// <summary>
        /// Iterates over children, checks if mouse within bounds and invokes click in child, then invokes click in self
        /// </summary>
        /// <param name="e"></param>
        public virtual void InvokeClick(MouseClickEventArgs e)
        {
            var inverseTransform = InverseTransform;
            var newMousePosition = inverseTransform.TransformPoint(e.MousePosition);
            var newEvent = new MouseClickEventArgs(e) { MousePosition = newMousePosition };
            var immutableChildren = Children.OrderByDescending(x => x.ZIndex).ToList();
            foreach (var child in immutableChildren)
            {
                if (child is IClickable && child.Visible && child.GetGlobalBounds().Contains(newMousePosition))
                {
                    ((IClickable)child).InvokeClick(newEvent);
                    if (newEvent.Handled)
                    {
                        e.Handled = newEvent.Handled;
                        return;
                    }
                }
            }
            Click?.Invoke(this, e);
        }

        /// <summary>
        /// Draws transformed container node with all it's children
        /// </summary>
        /// <param name="target"></param>
        /// <param name="states"></param>
        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            DrawChildren(target, states);
        }

        /// <summary>
        /// Draws untransformed children to target
        /// </summary>
        /// <param name="target"></param>
        /// <param name="states"></param>
        protected virtual void DrawChildren(RenderTarget target, RenderStates states)
        {
            foreach (var child in Children.OrderBy(x => x.ZIndex))
            {
                DrawChild(child, target, states);
            }
        }

        /// <summary>
        /// Draws a single, untransformed child node
        /// </summary>
        /// <param name="child"></param>
        /// <param name="target"></param>
        /// <param name="states"></param>
        protected virtual void DrawChild(INode child, RenderTarget target, RenderStates states)
        {
            if (child.Visible)
            {
                child.Draw(target, states);
            }
        }
    }
}
