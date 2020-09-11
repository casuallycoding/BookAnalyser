using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CasuallyCoding.Interview.BookAnalyser.Core
{
    class TextFileParser : IFileParser
    {
        private readonly string _filePath;

        /// <summary>
        /// Parses the text file from the filepath selected.
        /// </summary>
        /// <param name="filePath"></param>
        public TextFileParser(String filePath)
        {
            _filePath = filePath;
        }


        /// <summary>
        /// Loads the content from a file path and then identifies commonly occurring words weithin the text.
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public IOrderedEnumerable<KeyValuePair<string, int>> GetMostCommonWords()
        {

            Regex reg = new Regex("[*\",_&#^@]"); 
            var data = File.ReadAllText(_filePath);

            var cleanedWords = data.Split(' ')
                .ToList().Select(p => cleanString(p))              
                .Where(r => !r.Equals(String.Empty)); //Remove any empty occurrences
            
            var groupedWords = cleanedWords.GroupBy(p => p).ToDictionary(b => b.Key ,b => b.Count());   
            var wordsByPopularity = groupedWords.OrderByDescending(p => p.Value);
            return wordsByPopularity;
        }

        /// <summary>
        /// Cleans a string of any special characters except  "' adn -" as its considered a valid char in a word.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string cleanString(String value)
        {
            Regex reg = new Regex("[*\",_&#^@]");
            var cleanedWord = reg.Replace(value, string.Empty);
            return cleanedWord;
        }


    }

}
