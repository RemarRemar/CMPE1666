//***********************************************************************************
//Program: ICA01-Linear_Search.cs
//Description: Playing with Methods and Arrays
//Date: 09/05/25
//Author: Remar Gabriel Bacadon
//Course: CMPE1666
//Class: CNTA01
//***********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_Linear_Search
{
    internal class Program
    {
        static int iMin = 1, iMax = 255;// the upper and lower limit for every getvalue
        static void Main(string[] args)
        {
            int ilengthOfArray = GetValue("give a number for the length of array", iMin, iMax);// ask value for array size
            GetRange(out int iLowRange, out int iUpRange);
            Console.WriteLine($"LArray={ilengthOfArray}, DR={iLowRange}, UR={iUpRange}");
        }

        static int GetValue(in string strPrompt, in int iMinV, in int iMaxV)
        {//********************************************************************************************
            //Method: GetValue(in string strPrompt, in int iMin, in int iMax)
            //Purpose: have user give as a number within a range of values.
            //Parameters: Prompt user
            // Read input
            //validate input
            //ask for another input if invalid
            //Returns: the user's value
            //*********************************************************************************************
            
            int iValue = 0; // this is what we'll return
            bool bLoop = true;//boolean for loop
            bool bNumber = false;//boolean to validate if the user gave an integer
            while (bLoop) //loop if yes
            {
                Console.Write($"{strPrompt}, betweeen {iMinV} and {iMaxV}: ");//tell them what numbers they can put
                bNumber = int.TryParse(Console.ReadLine(), out iValue); // they must give an integer
                if (bNumber && iValue >= iMinV && iValue <= iMaxV)//input is integer and within the range
                {
                    bLoop = false; //no longer loop
                }
                else//input not valid
                {
                    Console.WriteLine($"\nEntered an invalid number\n");//tell them its not valid
                }
            }


            return (iValue);

        }

        static void GetRange(out int iMinR, out int iMaxR)
        {//********************************************************************************************
            //Method: GetRange(out int iMinR, out int iMaxR)
            //Purpose: asks for a range from the user
            //Parameters:GetValue()
            // make sure the upper range is actually larger than the Lower Range
            //Returns: the sum
            //*********************************************************************************************

            iMinR = 0;
            iMaxR = 0;
            bool bloop = true;
            while (bloop)
            {
                iMinR = GetValue("\ngive the minimum for the range of random generated numbers", iMin, iMax);
                iMaxR = GetValue("\ngive the maximum for the range of random generated numbers", iMin, iMax);

                while(iMinR == iMax)// lower range given shouldn't be at the max value, because they wont be able to give a valid upper rnge
                {
                    Console.WriteLine($"You cant have the minimum be at {iMax}");
                    iMinR = GetValue("give the minimum for the range of random generated numbers", iMin, iMax);
                }
                while (iMaxR <= iMinR)// maximum given shouldnt be larger or equal to the minimum given, have them fix it!
                {
                    Console.WriteLine($"You cant have the maximum be the same as minimum, it must be larger than the minimum({iMinR}) you input");
                    iMaxR = GetValue("give the maximum for the range of random generated numbers", iMin, iMax);
                }
                if(iMinR != iMax && iMaxR > iMinR)//check if everything is good before leaving, that the upper range is bigger than the lower range.
                {
                    bloop = false;//leave
                }
            }
        }

        static void GenerateArray()
        {//********************************************************************************************
            //Method: GetSum(int[] ArrayOfNumbers)
            //Purpose: adds up all the numbers in the array
            //Parameters:number adder loop
            // print the sum
            //Returns: the sum
            //*********************************************************************************************


        }

        static void DisplayArray()
        {//********************************************************************************************
            //Method: GetSum(int[] ArrayOfNumbers)
            //Purpose: adds up all the numbers in the array
            //Parameters:number adder loop
            // print the sum
            //Returns: the sum
            //*********************************************************************************************


        }

        static void CountOccurences()
        {//********************************************************************************************
            //Method: GetSum(int[] ArrayOfNumbers)
            //Purpose: adds up all the numbers in the array
            //Parameters:number adder loop
            // print the sum
            //Returns: the sum
            //*********************************************************************************************


        }

    }
}
