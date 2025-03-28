using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPECommons
{
    public class CMPE
    {
        //Title
        //RunAgain

        //GetValue

        //MakeArray
        //Show
        //ShowReverse
        //Average
        //Largest
        static public void Title(string sTitle)
        {
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.WriteLine(sTitle);
        }
        static public void RunAgain(out bool bAgain)
        {
            bAgain = true;
            char cCheck;
            string sCheck;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\nRun program again? (y/n)");
                cCheck = Console.ReadKey(true).KeyChar;
                sCheck = cCheck.ToString();
                sCheck = sCheck.ToLower();
                switch (sCheck)
                {
                    case "y":
                        Console.Clear();
                        bAgain = true;
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
        static public void GetValue(out int iOut, string sIn)
        {
            iOut = 0;
            bool bNaur = false;
            bool bInt = false;
            while (bNaur == false)
            {
                Console.Write(sIn);
                bInt = int.TryParse(Console.ReadLine(), out iOut);
                if (bInt == false)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                }
                else
                {
                    bNaur = bInt;
                }

            }
        }
        static public void GetValue(out int iOut, string sIn, int iMin)
        {
            iOut = 0;
            bool bInt = false;
            bool bNaur = false;
            while (bNaur == false)
            {
                Console.Write(sIn);
                bInt = int.TryParse(Console.ReadLine(), out iOut);
                if (bInt == true && iOut >= iMin)
                {
                    bNaur = bInt;
                }
                if (bInt == true && iOut < iMin)
                {
                    Console.WriteLine("The value entered is below the minimum accepted.");
                }
                if (bInt != true)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                }

            }
        }
        static public void GetValue(out int iOut, string sIn, int iMin, int iMax)
        {
            iOut = 0;
            bool bInt = false;
            bool bNaur = false;
            while (bNaur == false)
            {
                Console.Write(sIn);
                bInt = int.TryParse(Console.ReadLine(), out iOut);
                if (bInt == true && iOut >= iMin && iOut <= iMax)
                {
                    bNaur = bInt;
                }
                if (bInt == true && (iOut < iMin || iOut > iMax))
                {
                    Console.WriteLine("The value entered is outside the range accepted.");
                }
                if (bInt != true)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                }

            }
        }
        static public void GetValue(out double dOut, string sIn)
        {
            dOut = 0;
            bool bDouble = false;
            bool bNaur = false;
            while (bNaur == false)
            {
                Console.Write(sIn);
                bDouble = double.TryParse(Console.ReadLine(), out dOut);
                if (bDouble == true)
                {
                    bNaur = bDouble;
                }
                if (bDouble != true)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                }

            }
        }
        static public void GetValue(out double dOut, string sIn, double dMin)
        {
            dOut = 0;
            bool bDouble = false;
            bool bNaur = false;
            while (bNaur == false)
            {
                Console.Write(sIn);
                bDouble = double.TryParse(Console.ReadLine(), out dOut);
                if (bDouble == true && dOut >= dMin)
                {
                    bNaur = bDouble;
                }
                if (bDouble == true && dOut < dMin)
                {
                    Console.WriteLine("The value entered is below the minimum accepted.");
                }
                if (bDouble != true)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                }
            }
        }
        static public void GetValue(out double dOut, string sIn, double dMin, double dMax)
        {
            dOut = 0;
            bool bDouble = false;
            bool bNaur = false;
            while (bNaur == false)
            {
                Console.Write(sIn);
                bDouble = double.TryParse(Console.ReadLine(), out dOut);
                if (bDouble == true && dOut >= dMin && dOut <= dMax)
                {
                    bNaur = bDouble;
                }
                if (bDouble == true && (dOut < dMin || dOut > dMax))
                {
                    Console.WriteLine("The value entered is outside the range accepted.");
                }
                if (bDouble != true)
                {
                    Console.WriteLine("An invalid number was entered. Please try again.");
                }
            }
        }
        static public void MakeArray(out int[] iArray, int iArraySize)
        {
            Random arrayRandom = new Random();
            iArray = new int[iArraySize];
            for (int i = 0; i < iArraySize; i++)
            {
                iArray[i] = arrayRandom.Next(0, 101);
            }
        }
        static public void Show(int[] iArray)
        {
            Console.WriteLine("\nThe array contents...");
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine($"array[{i}] = {iArray[i]}");
            }
        }
        static public void ShowReverse(int[] iArray)
        {
            Console.WriteLine("\nThe array in reverse...");
            for (int i = (iArray.Length - 1); i > -1; i--)
            {
                Console.WriteLine($"array[{i}] = {iArray[i]}");
            }
        }
        static public void Average(int[] iArray)
        {
            double dAverage = 0;
            for (int i = 0; i < iArray.Length; i++)
            {
                dAverage += iArray[i];
            }
            dAverage /= iArray.Length;
            Console.WriteLine($"\nThe average is {dAverage}\n");
        }
        static public void Largest(int[] iArray)
        {
            int iMax = 0;
            int iIndex = 0;
            for (int i = 0; i < (iArray.Length - 1); i++)
            {
                if (iMax < iArray[i])
                {
                    iMax = iArray[i];
                    iIndex = i;
                }
            }
            Console.WriteLine($"the Largest Value is {iMax} at location {iIndex}.");
        }
    }
}
