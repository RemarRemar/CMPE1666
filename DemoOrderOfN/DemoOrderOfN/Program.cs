//***********************************************************************************
//Program: OrderOfN.cs
//Description: Calculates sum of given numbers
//Date: Today
//Author: Remar Bacadon
//Course: CMPE1300
//Class: CNTA01
//***********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoOrderOfN
{
    internal class Program
    {
         static void Main(string[] args)
        {
            int[] ArrayOfN;

            Console.WriteLine("How many Numbers would you like to generate?");
            int.TryParse(Console.ReadLine(), out int NumInArray);
            ArrayOfN = new int[NumInArray];

            PopulateArray(ArrayOfN);
            GetSum(ArrayOfN);
            Console.ReadKey();
        }
        static void PopulateArray(int[] ArrayOfNumbers)
        {
            //********************************************************************************************
            //Method: PopulateArray(int[] Array)
            //Purpose: generates random numbers to populate an array
            //Parameters:Random number generator
            // Assign numbers to Array
            //Returns: populated Array
            //*********************************************************************************************

            Random random = new Random();

            for (int i = 0; i <= ArrayOfNumbers.Length; i++)
            {
                ArrayOfNumbers[i] = random.Next(1, 9);
                Console.Write($"{ArrayOfNumbers[i]}, ");
            }
            return;
        }
        static int GetSum(int[] ArrayOfNumbers)
        {
            //********************************************************************************************
            //Method: GetSum(int[] ArrayOfNumbers)
            //Purpose: adds up all the numbers in the array
            //Parameters:number adder loop
            // print the sum
            //Returns: the sum
            //*********************************************************************************************

            int sum = 0;
            for (int i = 0; i < ArrayOfNumbers.Length; i++)
            {
                sum += ArrayOfNumbers[i];
            }

            Console.WriteLine($"The sum of all the generated numbers is {sum}");
            return (sum);
        }
    }
}
