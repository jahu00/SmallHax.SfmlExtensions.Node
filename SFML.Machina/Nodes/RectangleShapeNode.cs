using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.Machina.Nodes
{
    public class RectangleShapeNode : RectangleShape, INode
    {
        #region Properties
        public INode Parent { get; set; }
        public bool Visible { get; set; } = true;
        public int ZIndex { get; set; } = 0;
        #endregion

        public RectangleShapeNode() : base()
        {
        }

        public RectangleShapeNode(Vector2f size): base(size)
        {
        }
        
        public RectangleShapeNode(RectangleShape copy) : base(copy)
        {

        }
    }
}
