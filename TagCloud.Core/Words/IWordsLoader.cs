using System.Collections.Generic;

namespace TagCloud.Core.Words
{
    public interface IWordsLoader
    {
        IEnumerable<string> Load(string file);
    }
}