using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder pswd = new StringBuilder(input);

            string[] commands = Console.ReadLine().Split(" ");
            while (commands[0] != "Complete")
            {
                if (commands[0] == "Validation")
                {
                    if (!Length(pswd))
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }
                    else if (!Symbols(pswd))
                    {
                        Console.WriteLine("Password must consist only of letters, digits and _!");
                    }
                    else if (!UpperCase(pswd))
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }
                    else if (!LowerCase(pswd))
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }
                    else if (!Digit(pswd))
                    {
                        Console.WriteLine("Password must consist at least one digit!");
                    }
                }
                else if (commands[0] == "Replace")
                {
                    char[] chars = pswd.ToString().ToCharArray();
                    if (chars.Contains(commands[1][0]))
                    {
                    int valueOfCharInPswd = (int)commands[1][0];
                    int givenValue = int.Parse(commands[2]);
                    int total = valueOfCharInPswd + givenValue;
                        pswd.Replace(commands[1][0], (char)total);
                        Console.WriteLine(pswd);
                    }
                }
                else if (commands[0] == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    if (index < pswd.Length && index > 0)
                    {
                        pswd.Insert(index, commands[2][0]);
                        Console.WriteLine(pswd);
                    }
                }
                else if (commands[1] == "Upper")
                {
                    int indexChar = int.Parse(commands[2]);
                    string upper = pswd[indexChar].ToString().ToUpper();
                    char upperChar = upper[0];
                    for (int i = int.Parse(commands[2]); i < int.Parse(commands[2])+1; i++)
                    {
                        pswd[i] = upperChar;
                    }
                    Console.WriteLine(pswd);
                }
                else if (commands[1] == "Lower")
                {
                    int indexChar = int.Parse(commands[2]);
                    string upper = pswd[indexChar].ToString().ToLower();
                    char upperChar = upper[0];
                    for (int i = int.Parse(commands[2]); i < int.Parse(commands[2])+1; i++)
                    {
                        pswd[i] = upperChar;
                    }
                    Console.WriteLine(pswd);
                }
                commands = Console.ReadLine().Split(" ");
            }
        }
        static bool Length(StringBuilder pswd)
        {
            if (pswd.Length >= 8)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
        static bool Symbols(StringBuilder pswd)
        {
            bool consistance = true;
            for (int i = 0; i < pswd.Length; i++)
            {
                if (!char.IsDigit(pswd[i]) && !char.IsLetter(pswd[i]) && pswd[i] != '_')
                {
                    consistance = false;
                    break;
                }
            }
            return consistance;
        }
        static bool UpperCase(StringBuilder pswd)
        {
            bool upperCase = false;
            for (int i = 0; i < pswd.Length; i++)
            {
                if ((int)pswd[i] >= 65 && (int)pswd[i] <= 90)
                {
                    upperCase = true;
                    break;
                }
            }
            return upperCase;
        }
        static bool LowerCase(StringBuilder pswd)
        {
            bool lowerCase = false;
            for (int i = 0; i < pswd.Length; i++)
            {
                if ((int)pswd[i] >= 97 && (int)pswd[i] <= 122)
                {
                    lowerCase = true;
                    break;
                }
            }
            return lowerCase;
        }
        static bool Digit(StringBuilder pswd)
        {
            bool digit = false;
            for (int i = 0; i < pswd.Length; i++)
            {
                if (char.IsDigit(pswd[i]))
                {
                    digit = true;
                    break;
                }
            }
            return digit;
        }
    }
}
