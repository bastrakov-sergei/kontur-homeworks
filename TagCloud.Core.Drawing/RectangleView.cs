using System.Drawing;
using TagCloud.Core.Words;

namespace TagCloud.Core.Drawing
{
    public struct RectangleView
    {
        public readonly Rectangle Rectangle;
        public readonly TagView TagView;
        public readonly Color BackgroundColor;

        public RectangleView(Rectangle rectangle, TagView tagView, Color backgroundColor)
        {
            Rectangle = rectangle;
            TagView = tagView;
            BackgroundColor = backgroundColor;
        }
    }
}