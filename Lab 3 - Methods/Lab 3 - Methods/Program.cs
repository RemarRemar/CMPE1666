using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GDIDrawer;
namespace Lab_3___Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dX = 0, dA, dB, dC, dYLow, dYHigh, dY;

            CDrawer Canvas = new CDrawer(960, 1080);

            bool bKeepGoing = true;

            do
            {
                Title("Lab 3 methods");
                GetCoefficients(out dA, out dB, out dC);
                GetRange(out dYLow, out dYHigh);
                DrawGraph(dA, dB, dC, dYLow, dYHigh, Canvas); 
                

            } while (YesNo("\nRun again? yes or no: "));
            Console.ReadKey();
        }
        static private void DrawGraph(double dA, double dB, double dC, double dYLow, double dYHigh, CDrawer Canvas)
        {
            double dY, dX = 0;

            if (dYLow >= 0)
            {
                dYLow = 400 + (dYLow * 50);
            }
            else
            {
                dYLow = 400 - (dYLow * 50);
            }

            bool bDrawNo = false, bDrawRight = true, bDrawleft = true;
            do
            {
                double dY1 = 0, dY2 = 0, dX1 = 0, dX2 = 0;

                if (bDrawRight)
                {
                    Quadratic(dA, dB, dC, dX, out dY);

                    
                    if (dA > 0)
                    {
                        dY = 400 - dY;
                    }
                    else
                    {
                        dY += 400;
                    }

                    Quadratic(dA, dB, dC, dX1, out dY1);

                    if (dY >= dYLow && dY <= dYHigh)
                    {

                    }
                }


            } while (!bDrawNo);

        }
        static private bool YesNo(in string sMessage)
        {
            bool bYesnt = true, bOut = true;
            do
            {
                Console.WriteLine(sMessage);
                string sYesnt = Console.ReadLine();
                sYesnt = sYesnt.ToLower();
                switch (sYesnt)
                {
                    case "yes":
                        bYesnt = true;
                        bOut = true;
                        break;
                    case "no":
                        bYesnt = false;
                        bOut = true;
                        break;
                    default:
                        bOut = false;
                        break;
                }
            } while (!bOut);

            return (bYesnt);
        }
        static private void GetCoefficients(out double dA, out double dB, out double dC)
        {
            //int a, b, c;

            GetValue(out dA, "Enter a value for a: ");
            GetValue(out dB, "Enter a value for b: ");
            GetValue(out dC, "Enter a value for c: ");
            
        }
        static private void GetRange(out double dYLow, out double dYHigh)
        {
            GetValue(out dYLow, " Enter the lower limit: ");
            GetValue(out dYHigh, " Enter the higher limit: ", dYLow);
        }
        static private void Quadratic(double dA, double dB, double dC, double dX, out double dFofX)
        {
            dFofX = (dA * Math.Pow(dX, 2)) + (dB * dX) + dC;
            
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
