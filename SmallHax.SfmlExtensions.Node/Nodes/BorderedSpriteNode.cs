using SFML.System;
using SFML.Graphics;
using SmallHax.SfmlExtensions.Graphics;
using SmallHax.SfmlExtensions.System;

namespace SmallHax.SfmlExtensions.Nodes
{
    public class BorderedSpriteNode : BorderedSprite, INode
    {
        #region Properties
        public INode Parent { get; set; }
        public bool Visible { get; set; } = true;
        public int ZIndex { get; set; } = 0;
        #endregion

        public BorderedSpriteNode(float width, float height, float borderWidth, float textureBorderWidth, Texture texture, Color? color = null)
            : this
            (
                  size: new Vector2f(width, height),
                  borderWidth: new FloatMargin(borderWidth),
                  textureBorderWidth: new FloatMargin(textureBorderWidth),
                  texture: texture,
                  color: color
            )
        {
        }

        public BorderedSpriteNode(Vector2f size, FloatMargin borderWidth, FloatMargin textureBorderWidth, Texture texture, Color? color = null)
            : base
            (
                size: size,
                borderWidth: borderWidth,
                textureBorderWidth: textureBorderWidth,
                texture: texture,
                color: color
            )
        {
        }
    }
}
