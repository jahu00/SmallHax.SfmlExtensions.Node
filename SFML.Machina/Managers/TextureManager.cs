using SFML.Graphics;
using SFML.Machina.Nodes;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFML.Machina.Managers
{
    public class TextureManager : AResourceManager<Texture>
    {
        public TextureManager(string resourcePath, string fileExtension, string defaultResourceName = null) : base(resourcePath, fileExtension, defaultResourceName)
        {
        }

        public Texture GetTexture(string systemName) => GetResource(systemName);

        public SpriteNode GetSpriteNode(string systemName, float width, float height)
        {
            var sprite = GetSpriteNode(systemName);
            sprite.Scale = new Vector2f(width / sprite.TextureRect.Width, height / sprite.TextureRect.Height);
            return sprite;
        }

        public SpriteNode GetSpriteNode(string systemName)
        {
            var texture = GetTexture(systemName);
            var sprite = new SpriteNode(texture);
            return sprite;
        }

        protected override Texture LoadResource(string filePath)
        {
            return new Texture(filePath);
        }
    }
}
