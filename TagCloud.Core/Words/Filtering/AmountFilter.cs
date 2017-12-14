using System.Collections.Generic;
using System.Linq;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Filtering
{
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