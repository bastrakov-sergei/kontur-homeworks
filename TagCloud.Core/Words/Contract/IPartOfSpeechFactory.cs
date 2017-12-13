using TagCloud.Core.Words.Filtering;

namespace TagCloud.Core.Words.Contract
{
    public interface IPartOfSpeechFactory
    {
        PartOfSpeechFilter Create();
    }
}