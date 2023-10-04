using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            

            List<char> pswdToCharArray = password.ToList();
            
            string[] command = Console.ReadLine().Split(" ");
            while (command[0] != "Complete") 
            {
                if (command[0] == "Insert")
                {
                    if (pswdToCharArray.Count >= int.Parse(command[1])+1 && int.Parse(command[1]) >= 0)
                    {
                        int count = pswdToCharArray.Count;
                        pswdToCharArray.Insert(int.Parse(command[1]), command[2][0]);
                        Console.WriteLine(string.Join(null, pswdToCharArray));
                    }
                    
                }//gotovo
                else if (command[0] == "Replace")
                {
                    if (pswdToCharArray.Contains(command[1][0]))
                    {
                        int asciiValueOfChar = (int)command[1][0];
                        int givenValue = int.Parse(command[2]);
                        int total = asciiValueOfChar + givenValue;
                        for (int i = 0; i < pswdToCharArray.Count; i++)
                        {
                            if (pswdToCharArray[i] == command[1][0])
                            {
                                pswdToCharArray[i] = (char)total;
                            }
                        }
                        Console.WriteLine(string.Join(null, pswdToCharArray));
                    }
                    
                }//gotovo
                else if (command[0] == "Validation")
                {
                    bool length = Length(pswdToCharArray);
                    bool symbols = Symbols(pswdToCharArray);
                    bool upperCase = UpperCase(pswdToCharArray);
                    bool lowerCase = LowerCase(pswdToCharArray);
                    bool digit = Digit(pswdToCharArray);

                    if (!length)
                    {
                        Console.WriteLine("Password must be at least 8 characters long!");
                    }
                    if (!symbols) 
                    { 
                        Console.WriteLine("Password must consist only of letters, digits and _!");
                    }
                    if (!upperCase)
                    {
                        Console.WriteLine("Password must consist at least one uppercase letter!");
                    }
                    if (!lowerCase)
                    {
                        Console.WriteLine("Password must consist at least one lowercase letter!");
                    }
                    if (!digit)
                    {
                        Console.WriteLine("Password must consist at least one digit!");
                    }
                }//gotovo
                else if (command[1] == "Upper" && int.Parse(command[2]) < pswdToCharArray.Count)
                {
                    int index = int.Parse(command[2]);
                    pswdToCharArray[index] = char.ToUpper(pswdToCharArray[index]);
                    Console.WriteLine(string.Join(null, pswdToCharArray));
                }
                else if (command[1] == "Lower")
                {
                    int index = int.Parse(command[2]);
                    pswdToCharArray[index] = char.ToLower(pswdToCharArray[index]);
                    Console.WriteLine(string.Join(null, pswdToCharArray));
                }
                
                command = Console.ReadLine().Split(" ");
            }
        }
        static bool Length (List<char> pswdToCharArray)
        {
            if (pswdToCharArray.Count >= 8)
            {
                return true;
            }
            else
            {

            return false;
            }
        }
        static bool Symbols(List<char> pswdToCharArray)
        {
            bool consistance = true;
            for (int i = 0; i < pswdToCharArray.Count; i++)
            {
                if (!char.IsDigit(pswdToCharArray[i]) && !char.IsLetter(pswdToCharArray[i]) && pswdToCharArray[i] != '_')
                {
                    consistance = false;
                    break;
                }
            }
            return consistance;
        }
        static bool UpperCase(List<char> pswdToCharArray)
        {
            bool upperCase = false;
            for (int i = 0; i < pswdToCharArray.Count; i++)
            {
                if ((int)pswdToCharArray[i] >= 65 && (int)pswdToCharArray[i] <= 90)
                {
                    upperCase = true;
                    break;
                }
            }
            return upperCase;
        }
        static bool LowerCase(List<char> pswdToCharArray)
        {
            bool lowerCase = false;
            for (int i = 0; i < pswdToCharArray.Count; i++)
            {
                if ((int)pswdToCharArray[i] >= 97 && (int)pswdToCharArray[i] <= 122)
                {
                    lowerCase = true;
                    break;
                }
            }
            return lowerCase;
        }
        static bool Digit(List<char> pswdToCharArray)
        {
            bool digit = false;
            for (int i = 0; i < pswdToCharArray.Count; i++)
            {
                if (char.IsDigit(pswdToCharArray[i]))
                {
                    digit = true;
                    break;
                }
            }
            return digit;
        }
    }
}
