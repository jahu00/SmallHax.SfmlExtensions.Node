using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHax.SfmlExtensions.Nodes
{
    public class SpriteNode : Sprite, INode
    {
        #region Properties
        public INode Parent { get; set; }
        public bool Visible { get; set; } = true;
        public int ZIndex { get; set; } = 0;
        #endregion

        public SpriteNode() : base()
        {
        }

        public SpriteNode(Texture texture) : base(texture)
        {
        }

        public SpriteNode(Sprite copy) : base(copy)
        {
        }

        public SpriteNode(Texture texture, IntRect rectangle) : base(texture, rectangle)
        {
        }
    }
}
