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
            bool bLoop = true;//if true keep looping
            int ilengthOfArray = GetValue("give a number for the length of array", iMin, iMax);// ask value for array size
            GetRange(out int iLowRange, out int iUpRange);
            int[] iArray = GenerateArray(ilengthOfArray, iLowRange, iUpRange);
            DisplayArray(iArray);
            while (bLoop)// to make them loop if they want to search for diffrent value occurence
            {
                bool bAsking = true;
                CountOccurences(iArray, GetValue("\nEnter the value to be searched", iMin, iMax));
                while (bAsking)//to make them loop if they dont answer y or n
                {
                    Console.Write("Do you want to search for another value (y/n)? ");//asking the q
                    string yesnt = Console.ReadLine();
                    yesnt = yesnt.ToLower();

                    switch (yesnt)//feeling fancy
                    {
                        case "n"://get out of the search value loop thus ending the run
                            Console.WriteLine("bye bye");
                            bLoop = false;
                            bAsking = false;
                            break;

                        case "y"://get out of the search again question loop
                            bAsking = false;
                            break;
                        default://loop again with the question asking if they want to search again
                            break;
                    }
                }
            }
        }

        //********************************************************************************************
        //Method: GetValue(in string strPrompt, in int iMin, in int iMax)
        //Purpose: have user give as a number within a range of values.
        //Parameters: Prompt user
        // Read input
        //validate input
        //ask for another input if invalid
        //Returns: the user's value
        //*********************************************************************************************
        static int GetValue(in string strPrompt, in int iMinV, in int iMaxV)
        {
            
            int iValue = 0; // this is what we'll return
            bool bLoop = true;//boolean for loop
            bool bNumber = false;//boolean to validate if the user gave an integer
            while (bLoop) //loop if yes
            {
                Console.Write($"\n{strPrompt}, betweeen {iMinV} and {iMaxV}: ");//tell them what numbers they can put
                bNumber = int.TryParse(Console.ReadLine(), out iValue); // they must give an integer
                if (bNumber && iValue >= iMinV && iValue <= iMaxV)//input is integer and within the range
                {
                    bLoop = false; //no longer loop
                }
                else//input not valid
                {
                    Console.WriteLine($"Entered an invalid number");//tell them its not valid
                }
            }


            return (iValue);

        }

        //********************************************************************************************
        //Method: GetRange(out int iMinR, out int iMaxR)
        //Purpose: asks for a range from the user
        //Parameters:GetValue()
        // make sure the upper range is actually larger than the Lower Range
        //Returns: range from user
        //*********************************************************************************************
        static void GetRange(out int iMinR, out int iMaxR)
        {
            iMinR = 0;
            iMaxR = 0;
            bool bloop = true;
            while (bloop)
            {
                iMinR = GetValue("give the minimum for the range of random generated numbers", iMin, iMax);
                iMaxR = GetValue("give the maximum for the range of random generated numbers", iMin, iMax);

                while(iMinR == iMax)// lower range given shouldn't be at the max value, because they wont be able to give a valid upper rnge
                {
                    Console.WriteLine($"\nYou cant have the minimum be at {iMax}");
                    iMinR = GetValue("give the minimum for the range of random generated numbers", iMin, iMax);
                }
                while (iMaxR <= iMinR)// maximum given shouldnt be larger or equal to the minimum given, have them fix it!
                {
                    Console.WriteLine($"\nMaximum must be larger than the minimum({iMinR})");
                    iMaxR = GetValue("give the maximum for the range of random generated numbers", iMin, iMax);
                }
                if(iMinR != iMax && iMaxR > iMinR)//check if everything is good before leaving, that the upper range is bigger than the lower range.
                {
                    bloop = false;//leave
                }
            }
        }

        //********************************************************************************************
        //Method: GenerateArray(int iArraySize, int iMinA, int iMaxA)
        //Purpose: creates an array
        //Parameters:value for array size, lower range, upper range
        //Generate the array
        //Returns: Generated array
        //*********************************************************************************************
        static int[] GenerateArray(int iArraySize, int iMinA, int iMaxA)
        {
            int[] iNewArray = new int[iArraySize];//create the array
            Random rand = new Random();//random generator
            for(int i = 0; i < iArraySize; i++)//loop for the size of the array
            {
                iNewArray[i] = rand.Next(iMinA, iMaxA + 1);//put a random number within the range given by user in each index of the array
            }//+1 cause rand.Next max is -1 of given

            return (iNewArray);
        }

        //********************************************************************************************
        //Method: DisplayArray(int[] iArrayToDisplay)
        //Purpose: displays the array/print
        //Parameters:the array
        //display array in an inefficient way
        //Returns: nothing
        //*********************************************************************************************
        static void DisplayArray(int[] iArrayToDisplay)
        {
            Console.Write("\nthe generated values are: ");
            for (int i = 0; i < iArrayToDisplay.Length; i++)//prints/displays the array
            {
                Console.Write($"{iArrayToDisplay[i]}, ");


            }
        }

        //********************************************************************************************
        //Method: CountOccurences(int[] iArrayToSift, int iOccurence)
        //Purpose: find a specific value in the array
        //Parameters:array
        //loop and compare values to find the Occurence
        //Returns: the Occurences
        //*********************************************************************************************
        static void CountOccurences(int[] iArrayToSift, int iOccurence)
        {
            int tempj = 0;//for counting
            for (int i = 0; i < iArrayToSift.Length; i++)
            {
                if (iOccurence == iArrayToSift[i])//counts up if a value matching required is found
                {
                    tempj++;
                }
            }
            if (tempj > 0)
            {
                Console.WriteLine($"{iOccurence} occurs {tempj} times in the array.");
            }
            else
            {
                Console.WriteLine($"{iOccurence} cannot be found");
            }


        }

    }
}
