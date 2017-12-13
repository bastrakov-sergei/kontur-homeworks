using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace TagCloud.Core.Words
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
