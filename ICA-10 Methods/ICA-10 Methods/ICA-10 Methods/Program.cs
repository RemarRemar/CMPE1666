// ICA 10 Methods
// Remar Gabriel Bacadon
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using GDIDrawer;
using System.CodeDom;

namespace ICA_10_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sTitle = "ICA 10 Remar Gabriel Bacadon\n";

            int iStarSpace;
            int iLengthLine;
            int iLimit = 256;//didn't say what the limit was
            int iXCenter;
            int iYCenter;

            double dAngleIncrement;

            bool bRunProgramAgain = true;

            CDrawer canvas = new CDrawer(800, 600);

            while (bRunProgramAgain)
            {
                Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
                Console.WriteLine(sTitle);

                GetInt("Enter the line length in pixels: ", 1, iLimit, out iLengthLine);

                GetDouble("Enter the angle increment in degrees: ", 1, 90, out dAngleIncrement);

                GetInt("Enter the spacing for the stars in the pixels: ", iLengthLine, 256, out iStarSpace);
                for (iXCenter = 0; iXCenter <= 800; iXCenter+= iStarSpace)
                {
                    int iSpaceHolder = iStarSpace;
                    
                    for (iYCenter = 0; iYCenter <= 600; iYCenter+= iStarSpace)
                    {
                        DrawStar(canvas, iXCenter, iYCenter, (double)iLengthLine, dAngleIncrement);
                    }

                }
                
                AgainQuestion(canvas, bRunProgramAgain);
            }

        }

        static private bool AgainQuestion(CDrawer canvas5, bool bAgain5)
        {
            char cCheck;
            string sCheck;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Run program again? (y/n)");
                cCheck = Console.ReadKey().KeyChar;
                sCheck = cCheck.ToString();
                sCheck = sCheck.ToLower();
                switch (sCheck)
                {
                    case "y":
                        Console.Clear();
                        canvas5.Clear();
                        bAgain5 = true;
                        i = 3;
                        break;

                    case "n":
                        Console.Clear();
                        canvas5.Clear();
                        bAgain5 = false;
                        i = 3;
                        break;
                    default:
                        i--;
                        break;
                }
            }
            return (bAgain5);

        }
        static private int GetInt(string sPrompt1, int iLow1, int iHigh1, out int iInput1)
        {
            bool bGaveAValidAnswer = false;
            bool bIsAnInt;
            iInput1 = 69;
            while(bGaveAValidAnswer == false)
            {
                bool bAnswer;
                Console.Write(sPrompt1);
                bIsAnInt = int.TryParse(Console.ReadLine(), out iInput1);
                if(bIsAnInt == true && iInput1 <= iHigh1 && iInput1 >= iLow1)
                {
                    bAnswer = true;
                }
                else if( bIsAnInt == true && (iInput1  >= iHigh1 || iInput1 <= iLow1))
                {
                    Console.WriteLine($"Keep the input between {iLow1} and {iHigh1}");
                    bAnswer = false;
                }
                else
                {
                    Console.WriteLine("Keep the input an integer value, no letters and symbols, and only whole numbers");
                    bAnswer = false;
                }
                bGaveAValidAnswer = bAnswer;

            }
            return (iInput1);
            

            

        }
        static private double GetDouble(string sPrompt2, double dLow2, double dHigh2, out double dInput2)
        {
            bool bGaveAValidAnswer = false;
            bool bThisWorksForSomeReason;
            bool bIsADouble;

            dInput2 = 42.0;
            while (bGaveAValidAnswer == false)
            {
                Console.Write(sPrompt2);
                bIsADouble = double.TryParse(Console.ReadLine(), out dInput2);
                if (bIsADouble == true && dInput2 <= dHigh2 && dInput2 >= dLow2)
                {
                    bThisWorksForSomeReason = true;
                }
                else if (bIsADouble == true && (dInput2 >= dHigh2 || dInput2 <= dLow2))
                {
                    Console.WriteLine($"Keep the input between{dLow2} and {dHigh2}");
                    bThisWorksForSomeReason = false;
                }
                else
                {
                    Console.WriteLine("No letters and symbols");
                    bThisWorksForSomeReason = false;
                }

                bGaveAValidAnswer = bThisWorksForSomeReason;
            } 
            return (dInput2);



        }
        static private double Deg2Rad(double dDeg4, out double dRad4)
        {
            dRad4 = (dDeg4*Math.PI)/ 180;
            return (dRad4);
        }
        static private void DrawStar(CDrawer canvas3, int iXCenter3, int iYCenter3, double dLengthLine3, double dAngleIncrement3)
        {
            Random random = new Random();
            var color = Color.White;

            double dRadHolder = 0;
            double dXEnd, dYEnd;


            bool bStarNotDrawn = true;
            bool bDoWhileDidNotWork;
            Deg2Rad(dAngleIncrement3, out dAngleIncrement3);

            while (bStarNotDrawn == true) 
            {
                color = RandColor.GetColor();
                dXEnd = iXCenter3 + (dLengthLine3 * Math.Cos(dRadHolder));
                dYEnd = iYCenter3 + (dLengthLine3 * Math.Sin(dRadHolder));
                canvas3.AddLine(iXCenter3, iYCenter3, (int)dXEnd, (int)dYEnd, color);
                
                dRadHolder = dRadHolder + dAngleIncrement3;
                if(dRadHolder >= (2*Math.PI))
                {
                    bDoWhileDidNotWork = false;
                }
                else
                {
                    bDoWhileDidNotWork = true;
                }
                
                bStarNotDrawn = bDoWhileDidNotWork;

            } 
        }
    }
}
