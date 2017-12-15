using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TagCloud.Core.Drawing;
using TagCloud.Core.Words;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Client.Forms
{
    public partial class Form1 : Form
    {
        private readonly Image _layout;

        public Form1(WordsCloudRenderer cloudRenderer, IWordsStatistic wordsStatistic, int maxWords)
        {
            InitializeComponent();
            DoubleBuffered = true;
            Size = new Size(1920, 1080);

            _layout = cloudRenderer.Render(wordsStatistic, maxWords);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(_layout, 0, 0, 1920, 1080);
        }
    }
}
