using System.Collections.Generic;
using System.Linq;
using NHunspell;

namespace TagCloud.Core.Words
{
    public class PartOfSpeech
    {
        public PartOfSpeech(string name, string countryCode)
        {
            Name = name;
            CountryCode = countryCode;
        }

        public string Name { get; }
        public string CountryCode { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PartOfSpeech) obj);
        }

        protected bool Equals(PartOfSpeech other)
        {
            return string.Equals(Name, other.Name) && string.Equals(CountryCode, other.CountryCode);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (CountryCode != null ? CountryCode.GetHashCode() : 0);
            }
        }
    }

    public class PartOfSpeechFilter : IWordFilter
    {
        public PartOfSpeechFilter()
        {
        }

        public IEnumerable<string> Filter(IEnumerable<string> words)
        {
            return words;
        }
    }

    public class BoringFilter : IWordFilter
    {
        private readonly List<string> _boringWords;

        public BoringFilter(List<string> boringWords)
        {
            _boringWords = boringWords;
        }

        public IEnumerable<string> Filter(IEnumerable<string> words)
        {
            return words.Where(word => _boringWords.Contains(word));
        }
    }
}