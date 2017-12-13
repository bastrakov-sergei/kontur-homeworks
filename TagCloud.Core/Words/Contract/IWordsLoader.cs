using System.Collections.Generic;

namespace TagCloud.Core.Words.Contract
{
    public interface IWordsLoader
    {
        IEnumerable<string> Load(string file);
    }
}