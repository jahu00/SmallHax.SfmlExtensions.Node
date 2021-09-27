using System;
using SFML.System;
using SFML.Window;

namespace SFML.Machina.Events
{
    public class MouseClickEventArgs : EventArgs
    {
        public Mouse.Button MouseButton { get; set; }

        public Vector2f MousePosition { get; set; }

        public bool Handled { get; set; }

        public MouseClickEventArgs(Mouse.Button mouseButton, Vector2f mousePosition) : base()
        {
            MouseButton = mouseButton;
            MousePosition = mousePosition;
        }

        public MouseClickEventArgs(MouseClickEventArgs e) : base()
        {
            MouseButton = e.MouseButton;
            MousePosition = e.MousePosition;
        }
    }
}
