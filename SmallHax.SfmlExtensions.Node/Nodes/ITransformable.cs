using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHax.SfmlExtensions.Nodes
{
    public interface ITransformable
    {
        /// <summary>
        /// Position of the object
        /// </summary>
        Vector2f Position { get; set; }

        /// <summary>
        /// Rotation of the object
        /// </summary>
        float Rotation { get; set; }

        /// <summary>
        /// Scale of the object
        /// </summary>
        Vector2f Scale { get; set; }

        /// <summary>
        ///     The origin of an object defines the center point for all transformations (position,
        ///     scale, rotation). The coordinates of this point must be relative to the top-left
        ///     corner of the object, and ignore all transformations (position, scale, rotation).
        /// </summary>
        Vector2f Origin { get; set; }

        /// <summary>
        /// The combined transform of the object
        /// </summary>
        Transform Transform { get; }

        /// <summary>
        /// The combined transform of the object
        /// </summary>
        Transform InverseTransform { get; }
    }
}
