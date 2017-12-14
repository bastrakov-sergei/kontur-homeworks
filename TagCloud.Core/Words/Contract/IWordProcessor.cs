using System.Collections.Generic;

namespace TagCloud.Core.Words.Contract
{
    public interface IWordProcessor
    {
        IEnumerable<string> Apply(IEnumerable<string> words);
    }
}