using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Processing
{
    public class InitialFormOfWordProcessor : IWordProcessor
    {
        private readonly IGrammar _grammar;

        public InitialFormOfWordProcessor(IGrammar grammar)
        {
            _grammar = grammar;
        }

        public IEnumerable<string> Process(IEnumerable<string> words)
        {
            return words.Select(_grammar.GetInitialFormOfWord);
        }
    }
}
