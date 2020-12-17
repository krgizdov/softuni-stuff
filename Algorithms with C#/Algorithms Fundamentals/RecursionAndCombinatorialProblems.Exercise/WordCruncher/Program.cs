using System;
using System.Collections.Generic;

namespace WordCruncher
{
    class Program
    {
        private static string wordToFind;
        private static string current;
        private static readonly Dictionary<int, List<string>> wordsByLength = new Dictionary<int, List<string>>();
        private static readonly Dictionary<string, int> occurrences = new Dictionary<string, int>();
        private static readonly List<string> selectedWords = new List<string>();
        private static readonly HashSet<string> results = new HashSet<string>();

        static void Main()
        {
            var words = Console.ReadLine().Split(", ");
            wordToFind = Console.ReadLine();

            foreach (var word in words)
            {
                if (!wordToFind.Contains(word))
                {
                    continue;
                }

                var len = word.Length;

                if (!wordsByLength.ContainsKey(len))
                {
                    wordsByLength[len] = new List<string>();
                }

                if (occurrences.ContainsKey(word))
                {
                    occurrences[word]++;
                }
                else
                {
                    occurrences[word] = 1;
                }

                wordsByLength[len].Add(word);
            }

            GenSolutions(wordToFind.Length);

            Console.WriteLine(string.Join(Environment.NewLine, results));
        }

        private static void GenSolutions(int len)
        {
            if (len == 0)
            {
                if (current == wordToFind)
                {
                    results.Add(string.Join(" ", selectedWords));
                }

                return;
            }

            foreach (var kvp in wordsByLength)
            {
                if (kvp.Key > len)
                {
                    continue;
                }

                foreach (var word in kvp.Value)
                {
                    if (occurrences[word] > 0)
                    {
                        current += word;

                        if (IsMatching(wordToFind, current))
                        {
                            occurrences[word]--;
                            selectedWords.Add(word);
                            GenSolutions(len - word.Length);
                            occurrences[word]++;
                            selectedWords.RemoveAt(selectedWords.Count - 1);
                        }

                        current = current.Remove(current.Length - word.Length, word.Length);
                    }
                }
            }
        }

        private static bool IsMatching(string expected, string actual)
        {
            for (int i = 0; i < actual.Length; i++)
            {
                if (expected[i] != actual[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
