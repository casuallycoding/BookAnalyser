using System;
using System.Linq;

namespace CasuallyCoding.Interview.BookAnalyser.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileParser fileParser = new TextFileParser(@".\AliceInWonderLand.txt");

            foreach (var val in fileParser.GetMostCommonWords().ToList().Take(10))
            {
                Console.WriteLine($"{val.Key} {val.Value}");
            }

           
        }
    }
}
