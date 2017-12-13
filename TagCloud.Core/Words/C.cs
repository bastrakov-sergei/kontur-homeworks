using System.Collections.Generic;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words
{
    public class C
    {
        public void M(IWordsLoader loader, IWordsListFactory wordsListFactory)
        {
            IEnumerable<string> words = loader.Load("example.txt");

            IEnumerable<string> stopList = new List<string>();
            IEnumerable<PartOfSpeech> partsOfSpeech = new List<PartOfSpeech>
            {
                new PartOfSpeech("Noun")
            };

            WordsList wordList = wordsListFactory.Create(words);

            wordList.ToLower().ToInitialForm().ExcludeFrom(stopList).Is(partsOfSpeech);
        }
    }
}