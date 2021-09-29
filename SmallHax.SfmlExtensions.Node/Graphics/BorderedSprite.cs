using SFML.Graphics;
using SmallHax.SfmlExtensions.System;
using SFML.System;

namespace SmallHax.SfmlExtensions.Graphics
{
    public class BorderedSprite : Transformable, Drawable
    {
        protected VertexArray VertexArray { get; set; }

        public Texture Texture { get; set; }

        public FloatMargin BorderWidth { get; set; }
        public FloatMargin TextureBorderWidth { get; set; }

        public Vector2f Size { get; set; }

        protected Color _color { get; set; }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                UpdateColor();
            }
        }

        public bool BorderOnly { get; set; } = false;

        public BorderedSprite() : base()
        {
        }

        public BorderedSprite(float width, float height, float borderWidth, float textureBorderWidth, Texture texture, Color? color = null)
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

        public BorderedSprite(Vector2f size, FloatMargin borderWidth, FloatMargin textureBorderWidth, Texture texture, Color? color = null) : this()
        {
            Size = size;
            BorderWidth = borderWidth;
            TextureBorderWidth = textureBorderWidth;
            Texture = texture;
            Color = color ?? Color.White;
            PrepareVertexArray(BorderOnly);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            states.Texture = Texture;
            VertexArray.Draw(target, states);
        }

        protected void PrepareVertexArray(bool borderOnly)
        {
            VertexArray = new VertexArray();
            VertexArray.PrimitiveType = PrimitiveType.Quads;

            #region Upper row

            #region Upper left corner
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(0, 0),
                    new Vector2f(0, 0)
                )
            );
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, 0),
                    new Vector2f(TextureBorderWidth.Left, 0)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, BorderWidth.Top),
                    new Vector2f(TextureBorderWidth.Left, TextureBorderWidth.Top)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(0, BorderWidth.Top),
                    new Vector2f(0, TextureBorderWidth.Top)
                )
            );
            #endregion

            #region Upper edge
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, 0),
                    new Vector2f(TextureBorderWidth.Left, 0)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, 0),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, 0)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, BorderWidth.Top),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, TextureBorderWidth.Top)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, BorderWidth.Top),
                    new Vector2f(TextureBorderWidth.Left, TextureBorderWidth.Top)
                )
            );

            #endregion

            #region Upper right edge
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, 0),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, 0)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X, 0),
                    new Vector2f(Texture.Size.X, 0)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X, BorderWidth.Top),
                    new Vector2f(Texture.Size.X, TextureBorderWidth.Top)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, BorderWidth.Top),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, TextureBorderWidth.Top)
                )
            );

            #endregion

            #endregion

            #region Middle row

            #region Left edge
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(0, BorderWidth.Top),
                    new Vector2f(0, TextureBorderWidth.Top)
                )
            );
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, BorderWidth.Top),
                    new Vector2f(TextureBorderWidth.Left, TextureBorderWidth.Top)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, Size.Y - BorderWidth.Bottom),
                    new Vector2f(TextureBorderWidth.Left, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(0, Size.Y - BorderWidth.Bottom),
                    new Vector2f(0, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );
            #endregion

            if (!borderOnly)
            {
                #region Middle
                VertexArray.Append
                (
                    new Vertex
                    (
                        new Vector2f(BorderWidth.Left, BorderWidth.Top),
                        new Vector2f(TextureBorderWidth.Left, TextureBorderWidth.Top)
                    )
                );
                VertexArray.Append
                (
                    new Vertex
                    (
                        new Vector2f(Size.X - BorderWidth.Right, BorderWidth.Top),
                        new Vector2f(Texture.Size.X - TextureBorderWidth.Right, TextureBorderWidth.Top)
                    )
                );

                VertexArray.Append
                (
                    new Vertex
                    (
                        new Vector2f(Size.X - BorderWidth.Right, Size.Y - BorderWidth.Bottom),
                        new Vector2f(Texture.Size.X - TextureBorderWidth.Right, Texture.Size.Y - TextureBorderWidth.Bottom)
                    )
                );

                VertexArray.Append
                (
                    new Vertex
                    (
                        new Vector2f(BorderWidth.Left, Size.Y - BorderWidth.Bottom),
                        new Vector2f(TextureBorderWidth.Left, Texture.Size.Y - TextureBorderWidth.Bottom)
                    )
                );
                #endregion
            }

            #region Right edge
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, BorderWidth.Top),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, TextureBorderWidth.Top)
                )
            );
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X, BorderWidth.Top),
                    new Vector2f(Texture.Size.X, TextureBorderWidth.Top)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X, Size.Y - BorderWidth.Bottom),
                    new Vector2f(Texture.Size.X, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, Size.Y - BorderWidth.Bottom),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );
            #endregion

            #endregion

            #region Lower row

            #region Lower left corner
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(0, Size.Y - BorderWidth.Bottom),
                    new Vector2f(0, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, Size.Y - BorderWidth.Bottom),
                    new Vector2f(TextureBorderWidth.Left, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, Size.Y),
                    new Vector2f(TextureBorderWidth.Left, Texture.Size.Y)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(0, Size.Y),
                    new Vector2f(0, Texture.Size.Y)
                )
            );
            #endregion

            #region Lower edge
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, Size.Y - BorderWidth.Bottom),
                    new Vector2f(TextureBorderWidth.Left, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, Size.Y - BorderWidth.Bottom),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, Size.Y),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, Texture.Size.Y)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(BorderWidth.Left, Size.Y),
                    new Vector2f(TextureBorderWidth.Left, Texture.Size.Y)
                )
            );

            #endregion

            #region Lower right edge
            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, Size.Y - BorderWidth.Bottom),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X, Size.Y - BorderWidth.Bottom),
                    new Vector2f(Texture.Size.X, Texture.Size.Y - TextureBorderWidth.Bottom)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X, Size.Y),
                    new Vector2f(Texture.Size.X, Texture.Size.Y)
                )
            );

            VertexArray.Append
            (
                new Vertex
                (
                    new Vector2f(Size.X - BorderWidth.Right, Size.Y),
                    new Vector2f(Texture.Size.X - TextureBorderWidth.Right, Texture.Size.Y)
                )
            );

            #endregion

            #endregion

            UpdateColor();
        }

        protected void UpdateColor()
        {
            if (VertexArray == null)
            {
                return;
            }
            for (uint i = 0; i < VertexArray.VertexCount; i++)
            {
                var vertex = VertexArray[i];
                vertex.Color = Color;
                VertexArray[i] = vertex;
            }
        }

        public FloatRect GetGlobalBounds()
        {
            return Transform.TransformRect(VertexArray.Bounds);
        }
    }
}
