using SFML.Graphics;
using System.Collections.Generic;

namespace SFML.Machina.Graphics
{
    public class DrawableContainer : DrawableContainer<Drawable>
    {
        public DrawableContainer(params Drawable[] children) : base(children)
        {
            Children.AddRange(children);
        }

        public DrawableContainer() : base()
        {
        }
    }

    public class DrawableContainer<TDrawable> : Transformable, Drawable
        where TDrawable : Drawable
    {
        public List<TDrawable> Children { get; set; }

        public DrawableContainer(params TDrawable[] children) : this()
        {
            Children.AddRange(children);
        }

        public DrawableContainer()
        {
            Children = new List<TDrawable>();
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;

            DrawChildren(target, states);
        }

        protected virtual void DrawChildren(RenderTarget target, RenderStates states)
        {
            DrawChildren(Children, target, states);
        }

        protected virtual void DrawChildren(IEnumerable<TDrawable> children, RenderTarget target, RenderStates states)
        {
            foreach (var child in children)
            {
                DrawChild(child, target, states);
            }
        }

        protected virtual void DrawChild(TDrawable child, RenderTarget target, RenderStates states)
        {
            child.Draw(target, states);
        }
    }
}
