using SFML.Graphics;
using SmallHax.SfmlExtensions.Helpers;

namespace SmallHax.SfmlExtensions.Nodes
{
    public class RenderNode : ContainerNode
    {
        public uint Width { get; protected set; }
        public uint Height { get; protected set; }

        public bool AutoRefresh { get; set; }

        protected RenderTexture RenderTexture { get; set; }

        protected Sprite RenderSprite { get; set; }

        public RenderNode(uint width, uint height, bool autoRefresh = true)
        {
            Width = width;
            Height = height;
            AutoRefresh = autoRefresh;
            RenderTexture = new RenderTexture(Width, Height);
            RenderSprite = new Sprite(RenderTexture.Texture);
        }

        public void Refresh()
        {
            // Create new render state for our RenderNode using IdentityMatrix
            var states = new RenderStates(IdentityMatrix.GetTransform());
            base.DrawChildren(RenderTexture, states);
            RenderTexture.Display();
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (AutoRefresh)
            {
                Refresh();
            }
            states.Transform *= Transform;
            RenderSprite.Draw(target, states);
        }

        public override FloatRect GetGlobalBounds()
        {
            var bounds = new FloatRect(0, 0, Width, Height);
            return Transform.TransformRect(bounds);
        }
    }
}
