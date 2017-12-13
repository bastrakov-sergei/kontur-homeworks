using System.Collections.Generic;

namespace TagCloud.Core.Words
{
    public interface IWordProcessor
    {
        IEnumerable<string> Process(IEnumerable<string> words);
    }
}