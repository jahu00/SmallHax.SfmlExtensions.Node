using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.Machina.Nodes
{
    public class TextNode : Text, INode
    {
        #region Properties
        public INode Parent { get; set; }
        public bool Visible { get; set; } = true;
        public int ZIndex { get; set; } = 0;
        #endregion

        public TextNode() : base()
        {
        }

        public TextNode(Text copy) : base()
        {
        }

        public TextNode(string str, Font font) : base(str, font)
        {
        }
        
        public TextNode(string str, Font font, uint characterSize) : base(str, font, characterSize)
        {
        }
    }
}
