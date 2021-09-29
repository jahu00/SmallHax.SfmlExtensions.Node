using System;
using SFML.System;
using SFML.Graphics;
using SmallHax.SfmlExtensions.System;

namespace SmallHax.SfmlExtensions.Nodes
{
    public class ItemListNode : ContainerNode
    {
        public float ItemOuterWidth
        {
            get
            {
                return ItemWidth + ItemMargin.Left + ItemMargin.Right;
            }
        }

        public float ItemOuterHeight
        {
            get
            {
                return ItemHeight + ItemMargin.Top + ItemMargin.Bottom;
            }
        }

        public float ItemWidth { get; set; }
        public float ItemHeight { get; set; }

        public FloatMargin ItemMargin { get; set; }

        public int Columns { get; set; }

        public ItemListNode(float itemSize, int columns, float itemMargin) : this
        (
            itemWidth: itemSize,
            itemHeight: itemSize,
            columns: columns,
            itemMargin: new FloatMargin(itemMargin)
        )
        {
        }

        public ItemListNode(float itemWidth, float itemHeight, int columns, FloatMargin itemMargin) : base()
        {
            ItemWidth = itemWidth;
            ItemHeight = itemHeight;
            Columns = columns;
            ItemMargin = itemMargin;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            for (var i = 0; i < Children.Count; i++)
            {
                var child = Children[i];
                if (!(child is ITransformable))
                {
                    continue;
                }
                var transformableChild = (ITransformable)child;
                var col = i % Columns;
                var row = (int)Math.Floor((float)i / (float)Columns);
                transformableChild.Position = new Vector2f(col * ItemOuterWidth + ItemMargin.Left, row * ItemOuterHeight + ItemMargin.Top);
            }
            base.Draw(target, states);
        }
    }
}
