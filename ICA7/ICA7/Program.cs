using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace ICA7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string sNumGrades;
            string sKey;
            char cKey;
            int iNumGrades;
            int iNumLoop = 0;
            int iFailingGrades = 0;
            double dGrade;
            double dAverageGrade = 0;
            bool bValidNum;
            bool bRepeat = true;
            bool bValid = false;
            bool bValidKey = false;

            do
            {
                do
                {
                    Console.CursorLeft = (Console.WindowWidth - 27) / 2;
                    Console.WriteLine("ICA7 Remar Gabriel Bacadon\n");//this is 27 spaces i checked.

                    Console.Write("Enter the number of grades to generate: ");
                    sNumGrades = Console.ReadLine();
                    bValidNum =  int.TryParse(sNumGrades, out iNumGrades);
                    if (iNumGrades >= 5 && iNumGrades <= 10)
                    {
                        Console.WriteLine("\nHere are the generated grades...\n");
                        do
                        {
                            dGrade = random.NextDouble();
                            dGrade *= 100;
                            if(dGrade < 50)
                            {
                                iFailingGrades++;
                            }
                            dAverageGrade += (dGrade);
                            Math.Round(dGrade, 1);
                            Console.Write($"{dGrade:f1} ");
                            iNumLoop++;
                        }
                        while (iNumLoop < iNumGrades);
                        Console.WriteLine($"\n\nThe average grade was {(dAverageGrade/iNumGrades):f1}%.");
                        Console.WriteLine($"There were {iFailingGrades} failures");
                        bValid = true;
                    }
                    if(bValidNum != true)
                    {
                        Console.WriteLine("You have entered an invalid number.");
                    }
                    if(iNumGrades < 5 && bValidNum == true)
                    {
                        Console.WriteLine("You have entered a value that is too low");
                    }
                    if(iNumGrades > 10)
                    {
                        Console.WriteLine("You have entered a value that is too high");
                    }
                }
                while (bValid != true);

                Console.WriteLine("\nRun the program again? (y/n)");
                do
                {
                    cKey = Console.ReadKey(true).KeyChar;
                    sKey = cKey.ToString(); 
                    sKey = sKey.ToLower();
                    Console.WriteLine(cKey);
                    if (sKey == "n")
                    {
                        bRepeat = false;
                        bValidKey = true;
                    }
                    if (sKey == "y")
                    {
                        Console.Clear();
                        bValidKey = true;
                        bRepeat = true;
                        bValid = false;
                    }
                }
                while(bValidKey != true);
            }
            while (bRepeat == true);
        }
    }
}
