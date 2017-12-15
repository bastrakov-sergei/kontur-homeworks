using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Filtering
{
    public class UniqueFilter : IWordProcessor
    {
        public static UniqueFilter Unique(IEnumerable<string> wordList)
        {
            return new UniqueFilter();
        }

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            return words.Distinct();
        }
    }
}