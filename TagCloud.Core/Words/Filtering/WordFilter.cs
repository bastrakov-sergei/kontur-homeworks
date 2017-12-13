using System;
using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Filtering
{
    public class WordFilter : IWordFilter
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
    }
}