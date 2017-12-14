using System.Collections.Generic;

namespace TagCloud.Core.Words.Statistics
{
    public interface IWordsStatistic
    {
        int Amount { get; }
        IEnumerable<string> Words { get; }

        IEnumerable<Tag> GetTags();
        int GetWeight(string word);
    }
}