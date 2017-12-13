using System.Collections.Generic;

namespace TagCloud.Core.Words.Contract
{
    public interface IWordProcessor
    {
        IEnumerable<string> Process(IEnumerable<string> words);
    }
}