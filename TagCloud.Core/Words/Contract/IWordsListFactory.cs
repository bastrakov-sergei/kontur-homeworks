using System.Collections.Generic;

namespace TagCloud.Core.Words.Contract
{
    public interface IWordsListFactory
    {
        WordsList Create(IEnumerable<string> word);
    }
}