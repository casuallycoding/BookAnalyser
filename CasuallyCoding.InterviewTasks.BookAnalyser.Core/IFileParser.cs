using System.Collections.Generic;
using System.Linq;

namespace CasuallyCoding.Interview.BookAnalyser.Core
{
    internal interface IFileParser
    {

        public IOrderedEnumerable<KeyValuePair<string, int>> GetMostCommonWords();

    }
}