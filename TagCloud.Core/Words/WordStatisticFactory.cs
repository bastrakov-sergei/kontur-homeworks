using System.Collections.Generic;
using TagCloud.Core.Words.Contract;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Core.Words
{
    public class WordStatisticFactory
    {
        private readonly IWordsLoader _loader;
        private readonly IWordProcessor _processor;

        public WordStatisticFactory(IWordsLoader loader, IWordProcessor processor)
        {
            _loader = loader;
            _processor = processor;
        }

        public IWordsStatistic CreateFromFile(string file)
        {
            IEnumerable<string> words = _loader.Load(file);
            WordsList wordList = new WordsList(words);
            wordList = wordList.Apply(_processor);
            return wordList.GetStats();
        }
    }
}