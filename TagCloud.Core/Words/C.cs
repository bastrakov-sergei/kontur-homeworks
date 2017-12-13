using System.Collections.Generic;

namespace TagCloud.Core.Words
{
    public class C
    {
        public void M()
        {
            WordsList words = new WordsList(new List<string>());

            words.ExcludeFrom(new[] {"123", "321"}).ContainedIn(new[] {"123"}).Is();
        }
    }
}