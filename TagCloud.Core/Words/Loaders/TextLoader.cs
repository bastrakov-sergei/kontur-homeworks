using System.Collections.Generic;
using System.IO;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Loaders
{
    public class TextLoader : IWordsLoader
    {
        public IEnumerable<string> Load(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}
