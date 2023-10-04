using System;
using System.Collections.Generic;
using System.Linq;

namespace P03.Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Word> notebook = new List<Word>();
            List<string> input = Console.ReadLine().Split('|').ToList();

            for (int i = 0; i < input.Count; i++)
            {
            List<string> wordNameFromInput = input[0].Split(':'). Select(x => x.Trim()).ToList();
                List<string> definitionsList = new List<string> { wordNameFromInput[1] };
                bool exist = false;
                foreach (var word1 in notebook)
                {
                    if (word1.WordName == wordNameFromInput[0])
                    {
                        exist = true;
                        word1.Definition.AddRange(definitionsList);
                        break;
                    }
                }
                if (!exist)
                {
                Word word = new Word(wordNameFromInput[0], definitionsList);
                notebook.Add(word);
                }
                input.RemoveAt(0);
                i = -1;
            }
            string[] wordTest = Console.ReadLine().Split(" | ");
            string command = Console.ReadLine();
            if (command == "Test")
            {
                foreach (var word1 in notebook)
                {
                    for (int i = 0; i < wordTest.Length; i++)
                    {
                        if (word1.WordName == wordTest[i])
                        {
                            Console.WriteLine($"{word1.WordName}:");
                            foreach (var def in word1.Definition)
                            {
                                Console.WriteLine($"-{def}");
                            }
                            break;
                        }
                    }
                }
            }
            else if (command == "Hand Over")
            {
                foreach (var word1 in notebook)
                {
                    Console.Write($"{word1.WordName} ");
                }
            }
        }

        public class Word
        {
            public Word(string wordName, List<string> definition) 
            {
                WordName = wordName;
                Definition = definition;
            }
            public string WordName { get; set; }
            public List<string> Definition { get; set; }
        }
    }
}
