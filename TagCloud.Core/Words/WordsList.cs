using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;
using TagCloud.Core.Words.Filtering;

namespace TagCloud.Core.Words
{
    public class WordsList : IEnumerable<string>
    {
        private readonly IGrammar _grammar;
        private readonly IEnumerable<string> _words;

        public WordsList(IGrammar grammar, IEnumerable<string> words)
        {
            _grammar = grammar;
            _words = words;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _words.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public WordsList ExcludeFrom(IEnumerable<string> wordList)
        {
            return Apply(new WordFilter(word => !wordList.Contains(word)));
        }

        public WordsList ContainedIn(IEnumerable<string> wordList)
        {
            return Apply(new WordFilter(wordList.Contains));
        }

        public WordsList Apply(IWordFilter filter)
        {
            return new WordsList(_grammar, filter.Apply(this));
        }

        public WordsList Is(IEnumerable<PartOfSpeech> partsOfSpeech)
        {
            return Apply(new PartOfSpeechFilter(_grammar, partsOfSpeech.Contains));
        }
    }
}