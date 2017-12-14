using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.PreProcessing
{
    public class InitialFormOfWordProcessor : IWordProcessor
    {
        private readonly IGrammar _grammar;

        public InitialFormOfWordProcessor(IGrammar grammar)
        {
            _grammar = grammar;
        }

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            return words.Select(_grammar.GetInitialFormOfWord);
        }
    }
}
