using System.Collections;
using System.Collections.Generic;
using TagCloud.Core.Words.Contract;
using TagCloud.Core.Words.Filtering;
using TagCloud.Core.Words.Statistics;

namespace TagCloud.Core.Words
{
    public class WordsList : IEnumerable<string>
    {
        private readonly IEnumerable<string> _words;

        public WordsList(IEnumerable<string> words)
        {
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

        public WordsList Apply(IWordProcessor processor)
        {
            return new WordsList(processor.Apply(this));
        }

        public WordsList Take(int amount)
        {
            return Apply(new AmountFilter(amount));
        }

        #endregion

        #region Processing

        //public WordsList ToLower()
        //{
        //    return Apply(new ToLowerProcessor());
        //}

        //public WordsList ToInitialForm()
        //{
        //    return Apply(new InitialFormOfWordProcessor(_grammar));
        //}

        #endregion

        #region Statistics

        public WordsStatistic GetStats()
        {
            return new WordsStatistic(this);
        }

        public IEnumerable<Tag> ToTags()
        {
            return GetStats().GetTags();
        }

        #endregion
    }
}