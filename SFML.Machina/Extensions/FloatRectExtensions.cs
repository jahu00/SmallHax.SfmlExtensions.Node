using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.System
{
    public static class FloatRectExtensions
    {
        public static bool Contains(this FloatRect rect, Vector2f vector) 
        {
            return rect.Contains(vector.X, vector.Y);
        }

        public static bool Contains(this FloatRect rect, Vector2i vector)
        {
            return rect.Contains(vector.X, vector.Y);
        }
    }
}
