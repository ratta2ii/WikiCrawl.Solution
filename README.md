# Crawler Coding Challenge

The goal of this challenge is to implement a console application that displays the most common words used in a portion of a webpage.

# Important Notes

1. It is worth noting that Wikipedia is dynamic, so this count can always be changing.
2. "Example of the expected result" is NOT intended to be accurate. If you "command F", and count manually; you can confirm this. 
3. The project calls for the "history section", but this is a bit ambiguous in that it is only a "section" on the UI. Regardless,
    my approach was to find the first node (the "History" title), and last node (the "Corporate Affairs" title), of what could be
    considered the "history section". Please forgive me if I am mistaken about this approach.
4. The project description did not specify if the ads were to be included in the "history section".

# Requirements

The code should be written in C#, Python, or Java.

The code should return the most common words used and the number of times they are used. The following should be configurable:

- The number of words to return (default: 10)
- Words to exclude from the search

Your code (only the source code, no binaries) should be returned as a zip directly to my email. The code should build into an executable console application.

# Page to crawl

[https://en.wikipedia.org/wiki/Microsoft](https://en.wikipedia.org/wiki/Microsoft)

Only words from the section &quot;history&quot; should be accounted for.

# Example of the expected result

| (WORDS) | # of occurrences |
| --- | --- |
| The | 205 |
| Microsoft | 113 |
| in | 110 |
| of | 88 |
| and | 88 |
| a | 81 |
| to | 79 |
| on | 59 |
| Windows | 55 |
| for | 50 |

# Setup and Run Application
1. git clone https://github.com/ratta2ii/WikiCrawl.Solution.git
2. cd WikiCrawl
3. dotnet build
4. dotnet run