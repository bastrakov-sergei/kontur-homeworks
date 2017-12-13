using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Processing
{
    public class ToLowerProcessor : IWordProcessor
    {
        public IEnumerable<string> Process(IEnumerable<string> words)
        {
            return words.Select(word => word.ToLower());
        }
    }
}