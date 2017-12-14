using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.PreProcessing
{
    public class ToLowerProcessor : IWordProcessor
    {
        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            return words.Select(word => word.ToLower());
        }
    }
}