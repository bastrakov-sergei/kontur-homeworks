using System.Drawing;
using System.Windows.Forms;

namespace TagCloud.Core.Drawing
{
    public class TextMeasurer : ITextMeasurer
    {
        public Size Measure(string word, Font font)
        {
            return TextRenderer.MeasureText(word, font);
        }
    }
}