//Remar Gabriel Espaldon Bacadon
//ICA 09 For Each Loop
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sPassword;
            string sCheck;
            char cCheck = ' ';
            int iNum = 0;
            bool bAgain = true;
            bool bAll = false;
            bool bUpper = true;
            bool bLower = true;
            bool bSymbol = true;
            bool bDigit = true;
            bool bSpace = false;
            bool bDuplicateNum = false;

            while (bAgain)
            {
                do
                {
                    Console.Write("Write a password and I'll give you feedback: ");
                    sPassword = Console.ReadLine();

                    bUpper = false;
                    bLower = false;
                    bDigit = false;
                    bSymbol = false;
                    bSpace = false;
                    
                    foreach (char c in sPassword)
                    {
                        if (Char.IsUpper(c) == true)
                        {
                            bUpper = true;
                        }
                        if (Char.IsLower(c) == true)
                        {
                            bLower = true;
                        }
                        if (Char.IsDigit(c) == true)
                        {
                            int iDup1 = 0;
                            int iDup2 = 0;

                            iDup1++;
                            foreach (char c2 in sPassword)
                            {
                                
                                if (Char.IsDigit(c) == true && c2 == c)
                                {
                                    iDup2++;
                                    if (iDup1 != iDup2)
                                    {
                                        bDuplicateNum = true;
                                    }
                                }

                                bDigit = true;
                            }
                            iNum++;
                        }
                        if (Char.IsDigit(c) == false && Char.IsLetter(c) == false && Char.IsWhiteSpace(c) == false)
                        {
                            bSymbol = true;
                        }
                        if (Char.IsWhiteSpace(c) == true)
                        {
                            bSpace = true;
                            
                        }
                    }
                    if (sPassword.Length < 8)
                    {
                        Console.WriteLine("Password must have 8 or more characters!");
                    }
                    if (bUpper != true)
                    {
                        Console.WriteLine("Password must have a uppercase letter!");
                    }
                    if (bLower != true)
                    {
                        Console.WriteLine("Password must have a lowercase letter!");
                    }
                    if (bDigit != true)
                    {
                        Console.WriteLine("Password must have a number!");
                    }
                    if (bSymbol != true)
                    {
                        Console.WriteLine("Password must have a symbol!");
                    }
                    if (bSpace == true)
                    {
                        Console.WriteLine("Password must not have space or tab!");
                    }
                    if (bDuplicateNum == true)
                    {
                        Console.WriteLine("Cannot have duplicate numbers!");
                    }
                    if (bUpper == true && bLower == true && bDigit == true && bSymbol == true && bSpace != true && bDuplicateNum != true && iNum >= 2)
                    {
                        Console.WriteLine("Stand proud, your password is good.");
                        bAll = true;
                    }
                }
                while (!bAll);
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("\nRun program again? (y/n)");
                    cCheck = Console.ReadKey().KeyChar;
                    sCheck = cCheck.ToString();
                    sCheck = sCheck.ToLower();
                    switch (sCheck)
                    {
                        case "y":
                            Console.Clear();
                            cCheck = ' ';
                            iNum = 0;
                            bAgain = true;
                            bAll = false;
                            bUpper = true;
                            bLower = true;
                            bSymbol = true;
                            bDigit = true;
                            bSpace = false;
                            bDuplicateNum = false;
                            i = 3;
                            break;

                        case "n":
                            Console.Clear();
                            bAgain = false;
                            i = 3;
                            break;
                        default:
                            i--;
                            break;
                    }
                }
            }
        }
    }
}
