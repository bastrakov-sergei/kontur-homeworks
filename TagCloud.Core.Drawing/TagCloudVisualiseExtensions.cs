﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagCloud.Core.Math;
using Rectangle = System.Drawing.Rectangle;

namespace TagCloud.Core.Drawing
{
    public static class TagCloudVisualiseExtensions
    {
        public static Bitmap ToBitmap(this IEnumerable<RectangleView> rectanglesViews, Rectangle bounds, Color backgroundColor)
        {
            List<RectangleView> views = rectanglesViews.ToList();

            if (views.Count <= 0)
            {
                return new Bitmap(10, 10);
            }

            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(new SolidBrush(backgroundColor), 0, 0, bounds.Width, bounds.Height);

            foreach (RectangleView view in views)
            {
                Rectangle rectangle = view.Rectangle;
                rectangle.X -= bounds.X;
                rectangle.Y -= bounds.Y;
                graphics.FillRectangle(new SolidBrush(view.BackgroundColor), rectangle);
                graphics.DrawRectangle(new Pen(Color.Black, 1), rectangle);
            }

            return bitmap;
        }

        public static Bitmap ToBitmap(this IEnumerable<RectangleView> rectanglesViews, Rectangle bounds)
        {
            return ToBitmap(rectanglesViews, bounds, Color.Black);
        }

        public static IEnumerable<RectangleView> Colorize(this IEnumerable<Rectangle> rectangles, Func<Color> getColorFunc)
        {
            return rectangles.Select(rectangle => new RectangleView(rectangle, null, getColorFunc()));
        }

        public static IEnumerable<RectangleView> Colorize(this IEnumerable<Rectangle> rectangles)
        {
            ColorGenerator colorGenerator = new ColorGenerator(new Random(DateTime.Now.Millisecond));
            return Colorize(rectangles, () => colorGenerator.GetRandomColor());
        }
    }
}
