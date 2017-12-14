using System.Collections.Generic;

namespace TagCloud.Core.Words.Statistics
{
    public interface IWordsStatisticFactory
    {
        IWordsStatistic Create(IEnumerable<string> words);
    }
}