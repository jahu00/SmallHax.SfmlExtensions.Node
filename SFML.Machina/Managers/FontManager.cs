using SFML.Graphics;
using SFML.Machina.Nodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFML.Machina.Managers
{
    public class FontManager : AResourceManager<Font>
    {
        public FontManager(string resourcePath, string fileExtension, string defaultResourceName = null) : base(resourcePath, fileExtension, defaultResourceName)
        {
        }

        protected override Font LoadResource(string filePath)
        {
            var font = new Font(filePath);
            return font;
        }

        public Font GetFont(string systemName) => GetResource(systemName);

        public TextNode GetTextNode(string fontName, string textStr, uint characterSize, Color color)
        {
            var font = GetFont(fontName);
            var text = new TextNode(textStr, font, characterSize);
            text.FillColor = color;
            return text;
        }
    }
}
