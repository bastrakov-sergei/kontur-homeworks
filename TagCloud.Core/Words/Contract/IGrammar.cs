namespace TagCloud.Core.Words
{
    public interface IGrammar
    {
        PartOfSpeech GetPartOfSpeech(string word);
    }
}