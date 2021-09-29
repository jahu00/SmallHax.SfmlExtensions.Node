using SFML.Graphics;
using SmallHax.SfmlExtensions.Node.Demo.Models;
using SmallHax.SfmlExtensions.Managers;
using SmallHax.SfmlExtensions.Nodes;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallHax.SfmlExtensions.Node.Demo.Components
{
    public class ActorLevelComponent : ContainerNode
    {
        private FontManager FontManager { get; set; }
        private Actor Actor { get; set; }

        private RectangleShapeNode Background { get; set; }
        private TextNode LevelLabel { get; set; }

        public ActorLevelComponent(FontManager fontManager, Actor actor)
        {
            FontManager = fontManager;
            Actor = actor;

            Background = new RectangleShapeNode(new Vector2f(24, 24));
            Background.FillColor = Color.White;
            Children.Add(Background);
            LevelLabel = FontManager.GetTextNode("Ac437_IBM_VGA_8x16", Actor.Level.ToString(), 16, Color.Black);
            LevelLabel.Position = new Vector2f(Actor.Level < 10 ? 8 : 4 , 2);
            Children.Add(LevelLabel);
        }
    }
}
