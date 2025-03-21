using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_3___Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dX = 0, dA, dB, dC, dXLow, dXHigh, dFunctionOfX;
            Title("Lab 3 methods");
            GetCoefficients(out dA, out dB, out dC);
            GetRange(out dXLow, out dXHigh);
            Quadratic(dA, dB, dC, dX, out dFunctionOfX);

            Console.ReadKey();
        }
        static private void GetCoefficients(out double dA, out double dB, out double dC)
        {
            //int a, b, c;

            GetValue(out dA, "Enter a value for a: ");
            GetValue(out dB, "Enter a value for b: ");
            GetValue(out dC, "Enter a value for c: ");
            
        }
        static private void GetRange(out double dXLow, out double dXHigh)
        {
            GetValue(out dXLow, " Enter the lower limit: ");
            GetValue(out dXHigh, " Enter the higher limit: ", dXLow);
        }
        static private void Quadratic(double dA, double dB, double dC, double dX, out double dFofX)
        {

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
                if (bDouble == true && dOut > dMin)
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
        static private void Title(string sTitle)
        {
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.WriteLine(sTitle);
        }
    }
}
