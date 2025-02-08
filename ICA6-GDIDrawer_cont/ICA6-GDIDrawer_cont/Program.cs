using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using GDIDrawer;

namespace ICA6_GDIDrawer_cont
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable declaration
            CDrawer canvas = new CDrawer(800, 600, false); // create window
            Random random = new Random();
            string sTitle = "Remar-ICA6";
            int iSquareLength;
            int iNumSquares;
            int iX;
            int iY;

            bool bAgain = true;
            bool bSquareLength = true;
            bool bNumSquares = true;
            //main body program
            Console.ForegroundColor = ConsoleColor.Green;
            Console.CursorLeft = Console.WindowWidth - sTitle.Length / 2;
            Console.WriteLine(sTitle);
            Console.ForegroundColor = ConsoleColor.White;
            while (bAgain == true)
            {
                while (bSquareLength == true)
                {
                    Console.Write("\nEnter the size of the squares: ");
                    if (int.TryParse(Console.ReadLine(), out iSquareLength) && iSquareLength > 0)//takes the input for sqquare length and checks it for shenanigans
                    {
                        bSquareLength = false;
                        if (iSquareLength >= 10 || iSquareLength <= 200 && bSquareLength == false)
                        {
                            while (bNumSquares == true)
                            {
                                Console.Write("\nEnter the number of the squares to display: ");
                                if (int.TryParse(Console.ReadLine(), out iNumSquares) && iNumSquares > 0)//takes the input for sqquare length and checks it for shenanigans
                                {
                                    bNumSquares = false;
                                    int iSquaresDrawn = 0;//I wanna do a for loop!!!!
                                    while (iSquaresDrawn != iNumSquares)
                                    {
                                        // Position on X
                                        iX = random.Next(0, 800); // locate square between 0 - 799
                                        iX = (iX <= 0 + iSquareLength) ? iSquareLength : iX; // check if on screen on left
                                        iX = (iX >= 799 - iSquareLength) ? 799 - iSquareLength : iX; // check if on screen on right
                                              
                                        // Position ball on Y
                                        iY = random.Next(0, 599); // locate square between 0 - 599
                                        iY = (iY <= 0 + iSquareLength) ? iSquareLength : iY; // check if on screen on top
                                        iY = (iY >= 599 - iSquareLength) ? 599 - iSquareLength : iY; // check if on screen on bottom
                                        canvas.AddRectangle(iX, iY, iSquareLength, iSquareLength, RandColor.GetColor());//Color.FromArgb(random.Next())
                                    }
                                    Console.Write("Run program again? (y/n): ");
                                    
                                }
                                else
                                {
                                    Console.WriteLine("You have entered an invalid input!");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have entered an invalid input!");
                    }
                }
            }
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
