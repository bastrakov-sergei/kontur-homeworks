using System.Collections.Generic;
using System.Linq;

namespace TagCloud.Core.Words.Statistics
{
    public class WordsStatistic : IWordsStatistic
    {
        private readonly Dictionary<string, int> _words = new Dictionary<string, int>();

        public IEnumerable<string> Words => _words.Keys;
        public int Amount => _words.Count;

        public WordsStatistic(IEnumerable<string> words)
        {
            foreach (var word in words)
            {
                AddOrUpdate(word);
            }
        }

        public int GetWeight(string word)
        {
            if (_words.ContainsKey(word))
            {
                return _words[word];
            }

            return -1;
        }

        public IEnumerable<Tag> GetTags()
        {
            return _words.Select(pair => new Tag(pair.Key, pair.Value)).OrderByDescending(tag => tag.Weight);
        }

        private void AddOrUpdate(string word)
        {
            if (!_words.ContainsKey(word))
            {
                _words.Add(word, 1);
                return;
            }

            _words[word]++;
        }
    }
}
