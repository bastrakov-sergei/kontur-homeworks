using System.Collections.Generic;
using System.IO;
using TagCloud.Core.Words.Contract;

namespace TagCloud.Core.Words.Loaders
{
    public class PlainTextLoader : IWordsLoader
    {
        public IEnumerable<string> Load(string file)
        {
            using (StreamReader reader = new StreamReader(file))
            {
                while (!reader.EndOfStream)
                {
                    foreach (var word in reader.ReadLine().Split())
                    {
                        yield return word;
                    }
                }
            }
        }
    }
}