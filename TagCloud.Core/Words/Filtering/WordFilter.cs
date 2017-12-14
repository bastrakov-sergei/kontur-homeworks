using System;
using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Filtering
{
    public class WordFilter : IWordProcessor
    {
        private readonly Func<string, bool> _predicate;

        public WordFilter(Func<string, bool> predicate)
        {
            _predicate = predicate;
        }

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            return words.Where(_predicate);
        }

        public static WordFilter ExcludeFrom(IEnumerable<string> wordList)
        {
            return new WordFilter(word => !wordList.Contains(word));
        }

        public static WordFilter ContainedIn(IEnumerable<string> wordList)
        {
            return new WordFilter(wordList.Contains);
        }
    }
}