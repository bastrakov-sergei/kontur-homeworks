using System.Collections.Generic;

namespace TagCloud.Core.Words
{
    public interface IWordFilter
    {
        IEnumerable<string> Filter(IEnumerable<string> words);
    }
}