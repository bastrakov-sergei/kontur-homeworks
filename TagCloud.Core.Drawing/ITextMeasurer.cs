using System.Drawing;

namespace TagCloud.Core.Drawing
{
    public interface ITextMeasurer
    {
        Size Measure(string word, Font font);
    }
}