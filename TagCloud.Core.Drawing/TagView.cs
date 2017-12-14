using System.Drawing;

namespace TagCloud.Core.Drawing
{
    public class TagView
    {
        public readonly string Word;
        public readonly Font Font;
        public readonly Color Color;
        public readonly Size Size;

        public TagView(string word, Font font, Color color, Size size)
        {
            Word = word;
            Font = font;
            Color = color;
            Size = size;
        }
    }
}