namespace TagCloud.Core.Words.Statistics
{
    public struct Tag
    {
        public readonly string Word;
        public readonly int Weight;

        public Tag(string word, int weight)
        {
            Word = word;
            Weight = weight;
        }
    }
}