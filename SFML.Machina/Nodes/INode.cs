using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.Machina.Nodes
{
    public interface INode : Drawable, ITransformable
    {
        INode Parent { get; set; }

        bool Visible { get; set; }

        int ZIndex { get; set; }

        FloatRect GetGlobalBounds();

        //FloatRect GetLocalBounds();
    }
}
