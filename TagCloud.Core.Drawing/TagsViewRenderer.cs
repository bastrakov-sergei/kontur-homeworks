using System.Collections.Generic;
using System.Drawing;
using TagCloud.Core.Layouters.Contract;

namespace TagCloud.Core.Drawing
{


    public class TagsViewRenderer
    {
        private readonly IRectangleLayouter _rectangleLayouter;
        private readonly Color _backgroundColor;

        public TagsViewRenderer(IRectangleLayouter rectangleLayouter) : this(rectangleLayouter, Color.Black)
        {
        }

        public TagsViewRenderer(IRectangleLayouter rectangleLayouter, Color backgroundColor)
        {
            _rectangleLayouter = rectangleLayouter;
            _backgroundColor = backgroundColor;
        }

        public Image Render(IEnumerable<TagView> tagsViews)
        {
            Rectangle bounds;
            var rectanglesViews = PlaceTags(tagsViews, out bounds);
            
            var bitmap = new Bitmap(bounds.Width, bounds.Height);
            var graphics = Graphics.FromImage(bitmap);

            FillBackground(graphics, bounds);

            foreach (var rectangleView in rectanglesViews)
            {
                var rectangle = rectangleView.Rectangle;
                rectangle.X -= bounds.X;
                rectangle.Y -= bounds.Y;

                graphics.FillRectangle(new SolidBrush(rectangleView.BackgroundColor), rectangle);
                DrawTagView(graphics, rectangle, rectangleView.TagView);
            }

            return bitmap;
        }

        private void DrawTagView(Graphics graphics, Rectangle rectangle, TagView tagView)
        {
            graphics.DrawString(tagView.Word, tagView.Font, new SolidBrush(tagView.Color), rectangle);
        }

        private void FillBackground(Graphics graphics, Rectangle bounds)
        {
            graphics.FillRectangle(new SolidBrush(_backgroundColor), 0, 0, bounds.Width, bounds.Height);
        }
        
        private List<RectangleView> PlaceTags(IEnumerable<TagView> tagsViews, out Rectangle bounds)
        {
            var tmpBounds = new Math.Rectangle();
            var rectangles = new List<RectangleView>();
            foreach (var tagView in tagsViews)
            {
                var size = tagView.Size.ToVector();
                var rectangle = _rectangleLayouter.Place(size);

                tmpBounds.Encapsulate(rectangle);

                rectangles.Add(new RectangleView(rectangle.ToSystemRectangle(), tagView, Color.Transparent));
            }

            bounds = tmpBounds.ToSystemRectangle();
            return rectangles;
        }
    }
}