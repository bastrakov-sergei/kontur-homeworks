using System;
using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Filtering
{
    public class PartOfSpeechFilter : IWordFilter
    {
        private readonly IGrammar _grammar;
        private readonly Func<PartOfSpeech, bool> _predicate;

        public PartOfSpeechFilter(IGrammar grammar, Func<PartOfSpeech, bool> predicate)
        {
            _grammar = grammar;
            _predicate = predicate;
        }

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            return words.Where(word => _predicate(_grammar.GetPartOfSpeech(word)));
        }
    }
}