using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Filtering
{
    public class CleanUpWords : IWordProcessor
    {
        private readonly char[] _excludedChars = {'.', ',', '-', ' ', ':', ';', '"', '\'', '«', '»', '–' };

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                var tmpWord = _excludedChars.Aggregate(word, (current, excludedChar) => current.Replace(excludedChar.ToString(), ""));
                if (tmpWord.Length == 0 || tmpWord.Any(c => _excludedChars.Contains(c)))
                {
                    continue;
                }
                yield return tmpWord;
            }
        }
    }

    public class AmountFilter : IWordProcessor
    {
        private readonly int _amount;

        public AmountFilter(int amount)
        {
            _amount = amount;
        }

        public IEnumerable<string> Apply(IEnumerable<string> words)
        {
            return words.Take(_amount);
        }
    }
}