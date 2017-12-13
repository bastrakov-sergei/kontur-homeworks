using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;
using TagCloud.Core.Words.Filtering;
using TagCloud.Core.Words.Processing;

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

        #region Filtering

        public WordsList ExcludeFrom(IEnumerable<string> wordList)
        {
            return ApplyFilter(new WordFilter(word => !wordList.Contains(word)));
        }

        public WordsList ContainedIn(IEnumerable<string> wordList)
        {
            return ApplyFilter(new WordFilter(wordList.Contains));
        }

        public WordsList ApplyFilter(IWordFilter filter)
        {
            return new WordsList(_grammar, filter.Apply(this));
        }

        public WordsList Is(IEnumerable<PartOfSpeech> partsOfSpeech)
        {
            return ApplyFilter(new PartOfSpeechFilter(_grammar, partsOfSpeech.Contains));
        }

        public WordsList NotIs(IEnumerable<PartOfSpeech> partsOfSpeech)
        {
            return ApplyFilter(new PartOfSpeechFilter(_grammar, word => !partsOfSpeech.Contains(word)));
        }

        #endregion

        #region Processing

        public WordsList ToLower()
        {
            return Process(new ToLowerProcessor());
        }

        public WordsList ToInitialForm()
        {
            return Process(new InitialFormOfWordProcessor(_grammar));
        }

        public WordsList Process(IWordProcessor processor)
        {
            return new WordsList(_grammar, processor.Process(this));
        }

        #endregion
    }
}