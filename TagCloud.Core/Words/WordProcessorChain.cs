using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words
{
    public class WordProcessorChain : IWordProcessor
    {
        private readonly IWordProcessor[] _processors;

        public WordProcessorChain(IWordProcessor[] processors)
        {
            _processors = processors;
        }

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            return _processors.Aggregate(words, (current, wordProcessor) => wordProcessor.Apply(current));
        }
    }
}