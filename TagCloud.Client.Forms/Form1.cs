using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagCloud.Core;
using TagCloud.Core.Drawing;
using TagCloud.Core.Layouters;
using TagCloud.Core.Layouters.Contract;
using TagCloud.Core.Math;
using Rectangle = TagCloud.Core.Math.Rectangle;

namespace TagCloud.Client.Forms
{
    public partial class Form1 : Form
    {
        private readonly List<Rectangle> _rectangles = new List<Rectangle>();
        private IRectangleLayouter _cloudLayouter = new PositionedLayouter(new CircularCloudLayouter(200, 32, 0.1), new Vector(860, 540));

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            Size = new Size(1920, 1080);

            Generate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            Bitmap bitmap = _rectangles.Select(r => r.ToSystemRectangle()).Colorize().ToBitmap(new System.Drawing.Rectangle(0, 0, 1920, 1080));

            g.DrawImage(bitmap, new Point(0, 0));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Generate();
        }

        private void Generate()
        {
            _cloudLayouter = new PositionedLayouter(new CircularCloudLayouter(200, 32, 0.1), new Vector(860, 540));
            _rectangles.Clear();

            for (int i = 0; i < 97; i++)
            {
                Rectangle rect = _cloudLayouter.Place(new Vector(120, 40));
                _rectangles.Add(rect);
            }

            Invalidate();
        }
    }
}
