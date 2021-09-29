using SFML.Graphics;
using SmallHax.SfmlExtensions.Nodes;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHax.SfmlExtensions.Nodes
{
    public class ProgressBarNode : ContainerNode
    {
        private Vector2f Size { get; set; }
        private int _min { get; set; } = 0;
        private int _max { get; set; } = 100;
        private int _value { get; set; } = 0;

        public int Min
        {
            get
            {
                return _min;
            }
            set
            {
                if (value == _min)
                {
                    return;
                }
                if (value >= Min)
                {
                    throw new Exception($"Min has to be smaller tahn {Max}.");
                }
                _min = value;
                UpdateProgress();
            }
        }

        public int Max
        {
            get
            {
                return _max;
            }
            set
            {
                if (value == _max)
                {
                    return;
                }
                if (value <= Min)
                {
                    throw new Exception($"Max has to be grater tahn {Min}.");
                }
                _max = value;
                UpdateProgress();
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == _value)
                {
                    return;
                }
                if (value < Min || value > Max)
                {
                    throw new Exception($"Value has to be between {Min} and {Max}.");
                }
                _value = value;
                UpdateProgress();
            }
        }

        private bool Initialized { get; set; } = false;

        private RectangleShapeNode Bar { get; set; }

        private Color _color { get; set; } = Color.White;

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                if (_color == value)
                {
                    return;
                }
                _color = value;
                UpdateProgress();
            }
        }

        public ProgressBarNode(Vector2f size)
        {
            Size = size;
            Bar = new RectangleShapeNode();
            Initialized = true;
            UpdateProgress();
            Children.Add(Bar);
        }

        public void UpdateProgress()
        {
            if (!Initialized)
            {
                return;
            }
            if (Color != Bar.FillColor)
            {
                Bar.FillColor = Color;
            }
            var progress = (float)(Value - Min) / (float)(Max - Min);
            var barWidth = Convert.ToInt32(Size.X * progress);
            Bar.Size = new Vector2f(barWidth, Size.Y);
        }
    }
}
