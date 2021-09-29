using SmallHax.SfmlExtensions.Events;
using SmallHax.SfmlExtensions.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHax.SfmlExtensions.Nodes
{
    public interface IClickable
    {
        event EventHandler<MouseClickEventArgs> Click;

        void InvokeClick(MouseClickEventArgs e);
    }
}
