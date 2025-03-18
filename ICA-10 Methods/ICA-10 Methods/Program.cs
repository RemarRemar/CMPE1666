using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using GDIDrawer;

namespace ICA_10_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iLengthLine;
            int iLimit = (int)(Math.Sqrt(Math.Pow(Console.WindowWidth, 2) + Math.Pow(Console.WindowHeight, 2))/3);//didn't say what the limit was
            int iXCenter = 256;
            int iYCenter = 256;

            double dAngleIncrement;

            CDrawer canvas = new CDrawer(512, 512);

            GetInt("Enter the line length in pixels: ", 1, iLimit, out iLengthLine);

            GetDouble("Enter the angle increment in degrees: ", 1, 359, out dAngleIncrement); 

            DrawStar(canvas, iXCenter, iYCenter, (double) iLengthLine, dAngleIncrement);

        }
        static private int GetInt(string sPrompt, int iLow, int iHigh, out int iInput)
        {
            bool bGaveAValidAnswer = false;
            bool bIsAnInt;
            do
            {
                Console.WriteLine(sPrompt);
                bIsAnInt = int.TryParse(Console.ReadLine(), out iInput);
                if(bIsAnInt == true && iInput <= iHigh && iInput >= iLow)
                {
                    bGaveAValidAnswer = true;
                }
                if( bIsAnInt == true && (iInput  >= iHigh || iInput <= iLow))
                {
                    Console.WriteLine($"Keep the input between{iLow} and {iHigh}");
                }
                if ( bIsAnInt == false)
                {
                    Console.WriteLine("Keep the input an integer value, no letters and symbols, and only whole numbers");
                }


            }while(bGaveAValidAnswer);
            return (iInput);

            

        }
        static private double GetDouble(string sPrompt, double dLow, double dHigh, out double dInput)
        {
            bool bGaveAValidAnswer = false;
            bool bIsADouble;
            do
            {
                Console.WriteLine(sPrompt);
                bIsADouble = double.TryParse(Console.ReadLine(), out dInput);
                if (bIsADouble == true && dInput <= dHigh && dInput >= dLow)
                {
                    bGaveAValidAnswer = true;
                }
                if (bIsADouble == true && (dInput >= dHigh || dInput <= dLow))
                {
                    Console.WriteLine($"Keep the input between{dLow} and {dHigh}");
                }
                if (bIsADouble == false)
                {
                    Console.WriteLine("No letters and symbols");
                }


            } while (bGaveAValidAnswer);
            return (dInput);



        }
        static private double Deg2Rad(double dDeg, out double dRad)
        {
            dRad = (dDeg*Math.PI)/ 180;
            return (dRad);
        }
        static private void DrawStar(CDrawer canvas, int iXCenter, int iYCenter, double dLengthLine, double dAngleIncrement)
        {
            Random random = new Random();
            var color = Color.White;

            double dXEnd, dYEnd;


            bool bStarDrawn = false;
            Deg2Rad(dAngleIncrement, out dAngleIncrement);
            do
            {
                dXEnd = iXCenter + dLengthLine * Math.Cos(dAngleIncrement);
                dYEnd = iYCenter + dLengthLine * Math.Sin(dAngleIncrement);
                canvas.AddLine(iXCenter, iYCenter, (int)dXEnd, (int)dYEnd);

            }
        }
    }
}
