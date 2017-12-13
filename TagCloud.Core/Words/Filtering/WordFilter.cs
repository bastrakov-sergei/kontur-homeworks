using System;
using System.Collections.Generic;
using System.Linq;

namespace TagCloud.Core.Words
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