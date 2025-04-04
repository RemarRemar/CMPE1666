using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using GDIDrawer;
using System.Drawing;
namespace Lab_3___Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double dX = 0, dA, dB, dC, dXLow, dXHigh, dY;

            CDrawer Canvas = new CDrawer(960, 1080,false);

            bool bKeepGoing = true;


            DrawBackground(Canvas);
            do
            {
                Title("Lab 3 methods");
                GetCoefficients(out dA, out dB, out dC);
                GetDomain(out dXLow, out dXHigh);
                DrawGraph(dA, dB, dC, dXLow, dXHigh, Canvas);
                YesNo(out bKeepGoing, "\nRun again? yes or no: ");
                Canvas.Clear();
            } while (bKeepGoing);
            Console.ReadKey();
        }
        static private void DrawBackground(CDrawer Canvas)
        {
            //horizontal axis
            for (int i = 0; i < 960; i++)//drawing the horizontal line
            {
                Canvas.SetBBScaledPixel(i, 540, Color.Red);
            }
            for (int i = 530; i < 960; i+= 50)//drawing the notches on the right side
            {
                for(int j = (-10 + 540); j < (10 + 540); j++)
                {
                    Canvas.SetBBScaledPixel(i, j, Color.Red);
                }
            }
            for (int i = 430; i > 0; i -= 50)//drawing the notches on the Left side
            {
                for (int j = (-10 + 540); j < (10 + 540); j++)
                {
                    Canvas.SetBBScaledPixel(i, j, Color.Red);
                }
            }
            // vertical axis
            for (int i = 0; i < 1080; i++)//drawing the vertical line
            {
                Canvas.SetBBScaledPixel(480, i, Color.Red);
            }
            for (int i = 590; i < 1080; i += 50)//drawing the notches on the top side
            {
                for (int j = (-10 + 480); j < (10 + 480); j++)
                {
                    Canvas.SetBBScaledPixel(j, i, Color.Red);
                }
            }
            for (int i = 490; i > 0; i -= 50)//drawing the notches on the bottom side
            {
                for (int j = (-10 + 480); j < (10 + 480); j++)
                {
                    Canvas.SetBBScaledPixel(j, i, Color.Red);
                }
            }
            Canvas.Render();
        }
        static private void DrawGraph(double dA, double dB, double dC, double dXLow, double dXHigh, CDrawer Canvas)
        {
            double dY, dX = 480, dY1, dX1 = 480, dY2, dX2;

            bool bDrawNo = false, bDrawRight = true, bDrawLeft = true;


            dXLow = 480 + (dXLow * 50);
            dXHigh = 480 + (dXHigh * 50);

            do
            {
                int iX1, iX2;

                if (bDrawRight)
                {
                    Quadratic(dA, dB, dC, dX, out dY);

                    dX2 = dX + 1;
                    Quadratic(dA, dB, dC, dX2, out dY2);

                    if (dA > 0)
                    {
                        dY = 540 - dY;
                        dY2 = 540 - dY2;
                    }
                    else
                    {
                        dY = dY + 540;
                        dY2 = dY2 + 540;
                    }
                    iX1 = (int)(dX + 480);
                    iX2 = (int)(dX2 + 480);

                    if (dX >= dXLow && dX <= dXHigh && dX2 >= dXLow && dX2 <= dXHigh)//PRoBlem here!!!1
                    {

                        Canvas.AddLine(iX1, (int)dY, iX2, (int)dY2, Color.Blue);
                        Thread.Sleep(1);
                        dX++;
                    }
                    if (dX >= dXLow && dX <= dXHigh && dX2 < dXLow && bDrawRight == true)
                    {
                        iX1 = (int)(dX + 480);
                        iX2 = (int)(dXLow);

                        Canvas.AddLine(iX1, (int)dY, iX2, (int)dY2, Color.Blue);
                        Thread.Sleep(1);
                        bDrawRight = false;
                    }
                }
                if (bDrawLeft)
                {
                    Quadratic(dA, dB, dC, dX1, out dY1);

                    dX2 = dX1 - 1;
                    Quadratic(dA, dB, dC, dX2, out dY2);

                    if (dA > 0)
                    {
                        dY1 = 540 - dY1;
                        dY2 = 540 - dY2;
                    }
                    else
                    {
                        dY1 = dY1 + 540;
                        dY2 = dY2 + 540;
                    }

                    iX1 = (int)(dX1 + 480);
                    iX2 = (int)(dX2 + 480);

                    if (dX1 >= dXLow && dX2 <= dXHigh && dX2 >= dXLow && dX1 <= dXHigh)
                    {

                        Canvas.AddLine(iX1, (int)dY1, iX2, (int)dY2, Color.Blue);
                        Thread.Sleep(1);
                        dX1--;
                    }
                    if (dX1 >= dXLow && dX1 <= dXHigh && dX2 < dXLow && bDrawLeft == true)
                    {
                        iX1 = (int)(dX1 + 480);
                        iX2 = (int)(dXLow);

                        Canvas.AddLine(iX1, (int)dY1, iX2, (int)dY2, Color.Blue);
                        Thread.Sleep(1);
                        bDrawLeft = false;
                    }
                }

                if (bDrawRight == false && bDrawLeft == false)
                {
                    bDrawNo = true;
                }
                Canvas.Render();
            } while (!bDrawNo);

        }
        static private void YesNo(out bool bVar, in string sMessage)
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
            bVar = bYesnt;
        }
        static private void GetCoefficients(out double dA, out double dB, out double dC)
        {
            //int a, b, c;

            GetValue(out dA, "Enter a value for a: ");
            GetValue(out dB, "Enter a value for b: ");
            GetValue(out dC, "Enter a value for c: ");
            
        }
        static private void GetDomain(out double dXLow, out double dXHigh)
        {
            GetValue(out dXLow, " Enter the lower limit: ");
            GetValue(out dXHigh, " Enter the higher limit: ", dXLow);
        }
        static private void Quadratic(double dA, double dB, double dC, double dX, out double dFofX)
        {
            dX *= 0.02;
            dFofX = ((dA * Math.Pow(dX, 2)) + (dB * dX) + dC)*50;
            
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
