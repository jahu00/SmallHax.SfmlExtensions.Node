using SFML.Graphics;
using SmallHax.SfmlExtensions.Node.Demo.Components;
using SmallHax.SfmlExtensions.Node.Demo.Models;
using SmallHax.SfmlExtensions.Events;
using SmallHax.SfmlExtensions.Managers;
using SmallHax.SfmlExtensions.Nodes;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace SmallHax.SfmlExtensions.Node.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new ContainerNode();
            var viewportSize = new Vector2u(1280, 720);
            var window = new RenderWindow(new VideoMode(viewportSize.X, viewportSize.Y, 32), "SFML Machina", Styles.Default, new ContextSettings() { AntialiasingLevel = 8 });
            window.Closed += (sender, e) => { window.Close(); };
            window.MouseButtonPressed += (sender, e) =>
            {
                var mousePosition = Mouse.GetPosition(window);
                var sceneBounds = root.GetGlobalBounds();
                var windowScale = new Vector2f
                (
                    (float)viewportSize.X / (float)window.Size.X,
                    (float)viewportSize.Y / (float)window.Size.Y
                );
                if (sceneBounds.Contains(mousePosition))
                {
                    root.InvokeClick(new MouseClickEventArgs(e.Button, new Vector2f(e.X * windowScale.X, e.Y * windowScale.Y)));
                }
            };

            var textureManager = new TextureManager("Data/Images", "png");
            var fontManager = new FontManager("Data/Fonts", "ttf");
            var actors = new List<Actor>()
            {
                new Actor()
                {
                    Image = "slime",
                    Level = 11,
                    MaxHp = 100,
                    Hp = 100,
                    TurnInterval = 100,
                    TurnProgress = 0
                },
                new Actor()
                {
                    Image = "bat",
                    Level = 5,
                    MaxHp = 100,
                    Hp = 100,
                    TurnInterval = 90,
                    TurnProgress = 0
                },
                new Actor()
                {
                    Image = "ghost",
                    Level = 10,
                    MaxHp = 100,
                    Hp = 100,
                    TurnInterval = 75,
                    TurnProgress = 0
                },
                new Actor()
                {
                    Image = "spider-alt",
                    Level = 99,
                    MaxHp = 100,
                    Hp = 100,
                    TurnInterval = 150,
                    TurnProgress = 0
                }
            };
            var enemyContainer = new ItemListNode(128, 4, 16);
            enemyContainer.Position = new Vector2f(64, 64);
            root.Children.Add(enemyContainer);

            foreach (var actor in actors)
            {
                var actorComponent = new ActorComponent(textureManager, fontManager, actor);
                actorComponent.Position = new Vector2f(64, 64);
                enemyContainer.Children.Add(actorComponent);
            }
            var timer = DateTime.UtcNow;

            while (window.IsOpen)
            {
                var mousePosition = Mouse.GetPosition(window);

                var newTimer = DateTime.UtcNow;
                if ((newTimer - timer).TotalMilliseconds >= 10)
                {
                    timer = newTimer;
                    actors.ForEach
                    (
                        actor =>
                        {
                            if (actor.TurnProgress < actor.TurnInterval)
                            {
                                actor.TurnProgress++;
                            }
                            else
                            {
                                actor.TurnProgress = 0;
                            }
                        }
                    );
                }

                window.DispatchEvents();
                window.Clear();
                window.Draw(root);
                window.Display();
            }
        }
    }
}
