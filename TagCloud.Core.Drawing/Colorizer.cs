using System;
using System.Drawing;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Core.Drawing
{
    public class Colorizer : IColorizer
    {
        private readonly ColorGenerator _colorGenerator = new ColorGenerator(new Random());
        public Color GetColor(Tag tag)
        {
            return _colorGenerator.GetRandomColor();
        }
    }
}