using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ICA11_Utility
{
    public class RegUtility
    {
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
    }
}
