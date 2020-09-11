using System;
using System.Linq;

namespace CasuallyCoding.Interview.BookAnalyser.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileParser fileParser = new TextFileParser(@"C:\Users\Dave\source\repos\CasuallyCoding.InterviewTasks\AliceInWonderLand.txt");

            foreach (var val in fileParser.GetMostCommonWords().ToList())
            {
                Console.WriteLine($"{val.Key} {val.Value}");
            }

           
        }
    }
}
