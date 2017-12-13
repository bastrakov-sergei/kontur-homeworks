namespace TagCloud.Core.Words.Contract
{
    public interface IGrammar
    {
        PartOfSpeech GetPartOfSpeech(string word);
        string GetInitialFormOfWord(string word);
    }
}