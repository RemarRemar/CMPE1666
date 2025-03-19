//ICA-11 Methods Overloading
//Remar Gabriel Bacadon

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using GDIDrawer;

namespace ICA11_MethodOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iTest;
            double dTest;

            GetValue(out iTest, "Enter an integer: ");
            Console.WriteLine("iTest = {0}", iTest +"\n");

            GetValue(out iTest, "Enter a positive integer: ", 0);
            Console.WriteLine("iTest = {0}", iTest + "\n");

            GetValue(out iTest, "Enter an integer from 0 to 100: ", 0, 100);
            Console.WriteLine("iTest = {0}", iTest + "\n");

            GetValue(out dTest, "Enter a double: ");
            Console.WriteLine("dTest = {0}", dTest + "\n");

            GetValue(out dTest, "Enter a positive double: ", 0.0);
            Console.WriteLine("dTest = {0}", dTest + "\n");

            GetValue(out dTest, "Enter a double from 0.0 to 100.0: ", 0, 100);
            Console.WriteLine("dTest = {0}", dTest + "\n");
        }
        static private void GetValue(out int iOut, string sIn)
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
        static private void GetValue(out int iOut, string sIn, int iMin)
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
        static private void GetValue(out int iOut, string sIn, int iMin, int iMax)
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
        static private void GetValue(out double dOut, string sIn)
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
        static private void GetValue(out double dOut, string sIn, double dMin)
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
        static private void GetValue(out double dOut, string sIn, double dMin, double dMax)
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
