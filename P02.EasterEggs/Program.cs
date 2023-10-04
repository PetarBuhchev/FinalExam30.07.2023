using System;
using System.Text.RegularExpressions;

namespace P02.EasterEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\@|\#)+(?<color>[a-z]{3,})(\@|\#)+[^a-zA-Z\d]*(\/)+(?<amount>\d+)\3";
            string input = Console.ReadLine();

            MatchCollection valid = Regex.Matches(input, pattern);

            foreach (Match match in valid) 
            {
                Console.WriteLine($"You found {match.Groups["amount"].Value} {match.Groups["color"].Value} eggs!");
            }
        }
    }
}
