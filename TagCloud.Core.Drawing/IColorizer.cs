using System.Drawing;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Core.Drawing
{
    public interface IColorizer
    {
        Color GetColor(Tag tag);
    }
}