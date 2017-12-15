using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Core.Drawing
{
    public class TagsViewFactory
    {
        private readonly IFontFactory _fontFactory;
        private readonly IColorizer _colorizer;
        private readonly ITextMeasurer _textMeasurer;

        public TagsViewFactory(IFontFactory fontFactory, IColorizer colorizer, ITextMeasurer textMeasurer)
        {
            _fontFactory = fontFactory;
            _colorizer = colorizer;
            _textMeasurer = textMeasurer;
        }

        public IEnumerable<TagView> GetView(IWordsStatistic stats, int maxTags)
        {
            var tags = stats.GetTags().Take(maxTags);
            var tagsAmount = System.Math.Min(stats.Amount, maxTags);
            return tags.Select((t, i) => GetTagView(t, i, tagsAmount));
        }

        private TagView GetTagView(Tag tag, int index, int tagsAmount)
        {
            var font = _fontFactory.GetFont(tagsAmount - index - 1, tagsAmount);
            var color = _colorizer.GetColor(tag);
            var rectangle = _textMeasurer.Measure(tag.Word, font);

            return new TagView(tag.Word, font, color, rectangle);
        }
    }
}