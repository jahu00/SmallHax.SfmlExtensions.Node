using SFML.Graphics;
using SFML.Machina.Demo.Models;
using SFML.Machina.Managers;
using SFML.Machina.Nodes;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.Machina.Demo.Components
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
