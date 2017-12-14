using System;
using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Filtering
{
    public class PartOfSpeechFilter : IWordProcessor
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

        public static PartOfSpeechFilter Is(IEnumerable<PartOfSpeech> partsOfSpeech, IGrammar grammar)
        {
            return new PartOfSpeechFilter(grammar, partsOfSpeech.Contains);
        }

        public static PartOfSpeechFilter NotIs(IEnumerable<PartOfSpeech> partsOfSpeech, IGrammar grammar)
        {
            return new PartOfSpeechFilter(grammar, word => !partsOfSpeech.Contains(word));
        }
    }
}