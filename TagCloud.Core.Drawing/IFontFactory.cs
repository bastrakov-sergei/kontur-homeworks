using System.Drawing;

namespace TagCloud.Core.Drawing
{
    public interface IFontFactory
    {
        Font GetFont(int level, int levelAmount);
    }

    public class FontFactory : IFontFactory
    {
        private readonly FontFamily _fontFamily = FontFamily.GenericSansSerif;
        private readonly float minSize = 16;
        private readonly float maxSize = 32;

        public Font GetFont(int level, int levelAmount)
        {
            return new Font(_fontFamily, ((maxSize - minSize) / levelAmount) * level + minSize);
        }
    }
}