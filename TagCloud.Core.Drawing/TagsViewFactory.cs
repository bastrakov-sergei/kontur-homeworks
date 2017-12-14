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

        public IEnumerable<TagView> GetView(IWordsStatistic stats)
        {
            var tags = stats.GetTags();
            var tagsAmount = stats.Amount;
            return tags.Select((t, i) => GetTagView(t, i, tagsAmount));
        }

        private TagView GetTagView(Tag tag, int index, int tagsAmount)
        {
            var font = _fontFactory.GetFont(index, tagsAmount);
            var color = _colorizer.GetColor(tag);
            var rectangle = _textMeasurer.Measure(tag.Word, font);

            return new TagView(tag.Word, font, color, rectangle);
        }
    }
}