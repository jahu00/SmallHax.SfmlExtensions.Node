using SFML.Graphics;
using SFML.Machina.Demo.Models;
using SFML.Machina.Managers;
using SFML.Machina.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.Machina.Demo.Components
{
    public class ActorComponent : ContainerNode
    {
        private Actor Actor { get; set; }
        private TextureManager TextureManager { get; set; }
        private TextureManager FontManager { get; set; }

        private SpriteNode ActorSprite { get; set; }
        private SpriteNode MarkerSprite { get; set; }

        private ActorLevelComponent ActorLevel { get; set; }

        private ProgressBarNode HpProgressBar { get; set; }
        private ProgressBarNode TurnProgressBar { get; set; }

        public ActorComponent(TextureManager textureManager, FontManager fontManager, Actor actor)
        {
            TextureManager = textureManager;
            FontManager = FontManager;
            Actor = actor;

            ActorSprite = TextureManager.GetSpriteNode(actor.Image, 128, 128);
            ActorSprite.Position = new SFML.System.Vector2f(0, 24);
            Children.Add(ActorSprite);

            ActorLevel = new ActorLevelComponent(fontManager, actor);
            Children.Add(ActorLevel);

            HpProgressBar = new ProgressBarNode(new SFML.System.Vector2f(104, 12)) { Color = Color.Green };
            HpProgressBar.Position = new SFML.System.Vector2f(24, 0);
            Actor.HpChanged += OnHpChanged;
            OnHpChanged(Actor);
            Children.Add(HpProgressBar);

            TurnProgressBar = new ProgressBarNode(new SFML.System.Vector2f(104, 12)) { Color = Color.Yellow };
            TurnProgressBar.Position = new SFML.System.Vector2f(24, 12);
            Actor.TurnProgressChanged += OnTurnProgressChanged;
            OnTurnProgressChanged(Actor);
            Children.Add(TurnProgressBar);

            MarkerSprite = TextureManager.GetSpriteNode("plain-arrow", 32, 32);
            MarkerSprite.Position = new SFML.System.Vector2f(48, -48);
            Children.Add(MarkerSprite);
        }

        private void OnHpChanged(Actor sender)
        {
            HpProgressBar.Max = Actor.MaxHp;
            HpProgressBar.Value = Actor.Hp;
        }

        private void OnTurnProgressChanged(Actor sender)
        {
            TurnProgressBar.Max = Actor.TurnInterval;
            TurnProgressBar.Value = Actor.TurnProgress;
        }
    }
}
