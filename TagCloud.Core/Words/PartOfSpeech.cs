namespace TagCloud.Core.Words
{
    public class PartOfSpeech
    {
        private const string UnknownKeyword = "Unknown";

        public string Name { get; }

        public static readonly PartOfSpeech Unknown = new PartOfSpeech(UnknownKeyword);

        public PartOfSpeech(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((PartOfSpeech) obj);
        }

        protected bool Equals(PartOfSpeech other)
        {
            if (other.Name == UnknownKeyword) return false;
            if (Name == UnknownKeyword) return false;

            return string.Equals(Name, other.Name);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}