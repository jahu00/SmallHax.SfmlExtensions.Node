using SFML.Machina.Events;
using SFML.Machina.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.Machina.Nodes
{
    public interface IClickable
    {
        event EventHandler<MouseClickEventArgs> Click;

        void InvokeClick(MouseClickEventArgs e);
    }
}
