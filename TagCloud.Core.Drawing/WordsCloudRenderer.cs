using System.Collections.Generic;
using System.Drawing;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Core.Drawing
{
    public class WordsCloudRenderer
    {
        private readonly TagsViewFactory _tagsViewFactory;
        private readonly TagsViewRenderer _tagsViewRenderer;

        public WordsCloudRenderer(TagsViewFactory tagsViewFactory, TagsViewRenderer tagsViewRenderer)
        {
            _tagsViewFactory = tagsViewFactory;
            _tagsViewRenderer = tagsViewRenderer;
        }

        public Image Render(IWordsStatistic wordsStatistic, int maxTags)
        {
            IEnumerable<TagView> views = _tagsViewFactory.GetView(wordsStatistic, maxTags);
            return _tagsViewRenderer.Render(views);
        }
    }
}