using System.Collections.Generic;
using TagCloud.Core.Words.Contract;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Core.Words
{
    public class WordStatisticFactory
    {
        private readonly IWordsLoader _loader;
        private readonly IWordsListFactory _wordsListFactory;
        private readonly IWordProcessor _processor;

        public WordStatisticFactory(IWordsLoader loader, IWordsListFactory wordsListFactory, IWordProcessor processor)
        {
            _loader = loader;
            _wordsListFactory = wordsListFactory;
            _processor = processor;
        }

        public IWordsStatistic CreateFromFile(string file)
        {
            IEnumerable<string> words = _loader.Load(file);
            WordsList wordList = _wordsListFactory.Create(words);
            wordList = wordList.Apply(_processor);
            return wordList.GetStats();
        }
    }
}