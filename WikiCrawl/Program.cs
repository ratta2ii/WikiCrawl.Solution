using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace WikiCrawl
{
    class Program
    {
        static void Main(string[] args)
        {
            //! IMPORTANT: Please see my notes down below (will include in email response as well)
            //* GitHub Repo: https://github.com/ratta2ii/WikiCrawl.Solution

            // Create HTML document using url
            var html = @"https://en.wikipedia.org/wiki/Microsoft";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            // Beginning and ending nodes with XPath (traversal section in DOM)
            HtmlNode startNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"mw-content-text\"]/div[1]/h2[1]");
            HtmlNode endNode = htmlDoc.DocumentNode.SelectSingleNode("//*[@id=\"mw-content-text\"]/div[1]/h2[2]");

            // Bring in helper methods by instantiating Helper class
            Helper helper = new Helper();

            // Dynamic data according to project specifications (Add word count to return, and words to exclude here)
            int defaultWordCount = 10;
            helper.WordCount = defaultWordCount; // Change "defaultWordCount" to any number of your choosing
            helper.ExcludeWords = new List<string>(){}; // Add words here (Example: new List<string> {"Windows", "the", "Microsoft"} )

            try
            {
                // Traverses the DOM, adding all nodes in the given section to a "MasterString"
                HtmlNode currentNode = startNode;
                while (currentNode != endNode)
                {
                    helper.AddNodesToMasterString(currentNode);
                    currentNode = currentNode.NextSibling;
                }
                //! This is the final answer
                helper.PrintFinalOutput();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

/*
1. It is worth noting that Wikipedia is dynamic, so this count can always be changing.
2. Not sure if the "Example of the expected result" is intended to be accurate; If you "command F", and count manually; you can confirm it is not though. 
3. The project calls for the "history section", but this is a bit ambiguous in that it is only a "section" on the UI. Regardless,
    my approach was to find the first node (the "History" title), and last node (the "Corporate Affairs" title), of what could be
    considered the "history section". Please forgive me if I am mistaken about this approach.
4. The project description did not specify if the ads were to be included in the "history section".
5. And lastly, thank you for some great fun! I am definitely excited about this opportunity and looking forward to hearing back.
*/