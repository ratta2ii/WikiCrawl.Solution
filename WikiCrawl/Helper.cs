using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WikiCrawl
{
    class Helper
    {
        public static string MasterString { get; set; } = "";
        public int WordCount { get; set; }
        public List<string> ExcludeWords { get; set; }
        public void AddNodesToMasterString(HtmlNode currentParentNode)
        {
            // I did not add the parent nodes because none of them are text nodes
            HtmlNodeCollection childNodes = currentParentNode.ChildNodes;
            foreach (var node in childNodes)
            {
                MasterString = MasterString += $" {node.GetDirectInnerText()}";
            }
        }

        private string RemoveWords(string str)
        {
            foreach (string word in this.ExcludeWords)
                str = str.Replace(word, "");
            return str;
        }

        private static string SanitizeString(string dirtyString)
        {
            HashSet<char> removeChars = new HashSet<char>($"\"0123456789.?&^$%#@!()[]/+=,:;<>*");
            StringBuilder result = new StringBuilder(dirtyString.Length);
            foreach (char c in dirtyString)
                if (!removeChars.Contains(c))
                    result.Append(c);
                else result.Append(" ");
            return result.ToString();
        }

        private static Dictionary<string, int> CreateOrderedDictionary(string[] arr)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (string word in arr)
            {
                if (word.Length >= 1 && Regex.IsMatch(word, @"^[a-zA-Z]+$"))
                {
                    if (dictionary.ContainsKey(word))
                        dictionary[word] = dictionary[word] + 1;
                    else
                        dictionary[word] = 1;
                }
            }
            // Sorts and then changes type back to dictionary after "OrderByDescending" changes type to IOrderedEnumerable
            var sortedDic = dictionary.OrderByDescending(key => key.Value)
                .ToDictionary<KeyValuePair<string, int>, string, int>(pair => pair.Key, pair => pair.Value);
            return sortedDic;
        }

        public void PrintFinalOutput()
        {
            string wordsRemoved = RemoveWords(MasterString);
            string[] sanitizedStrArr = SanitizeString(wordsRemoved).Split(" ");
            Dictionary<string, int> orderedDictionary = CreateOrderedDictionary(sanitizedStrArr);

            for (int i = 0; i < WordCount; i++)
            {
                var item = orderedDictionary.ElementAt(i);
                // //! Prints FINAL word entries here
                Console.WriteLine(item);
            }
        }
    }
}
