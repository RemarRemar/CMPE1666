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
            string sYN;
            int iSquareLength;
            int iNumSquares;
            int iX;
            int iY;

            bool bAgain = true;
            bool bNotAgain = true;
            bool bRunAgain = true;
            bool bSquareLength = true;
            bool bNumSquares = true;

            //main body program
            while (bAgain == true)//so that it loops for run again == y
            {
                //title, I don't want it to dissapear when canvas and console is cleared
                Console.ForegroundColor = ConsoleColor.Green;
                Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
                Console.WriteLine(sTitle);
                Console.ForegroundColor = ConsoleColor.White;
                
                //loops and checks and cals and draws
                while (bSquareLength == true)//loops if user errored
                {
                    Console.Write("\nEnter the size of the squares: ");//prompt
                    if (int.TryParse(Console.ReadLine(), out iSquareLength))//takes the input for square length and checks it for shenanigans
                    {
                        if (iSquareLength >= 10 && iSquareLength <= 200)// if 10 <= iSquareLength <= 200
                        {
                            while (bNumSquares == true)//loops if user errored
                            {
                                Console.Write("Enter the number of the squares to display: ");
                                if (int.TryParse(Console.ReadLine(), out iNumSquares))//takes the input for number of squares and checks it for shenanigans
                                {
                                    if (iNumSquares > 0)// if number of sqaures to be drawn is a positive number
                                    {
                                        int iSquaresDrawn = 0;//I wanna do a for loop!!!!
                                        while (iSquaresDrawn < iNumSquares)//loops while the number of squares drawn does not equal what the user input
                                        {
                                            // Position on X
                                            iX = random.Next(0, 800); // locate square between 0 - 799
                                            iX = (iX <= 0 + iSquareLength) ? random.Next(1, 15) : iX; // check if on screen on left,random to make it look natural
                                            iX = (iX >= 799 - iSquareLength) ? random.Next(784 - iSquareLength, 799 - iSquareLength) : iX; // check if on screen on right

                                            // Position ball on Y
                                            iY = random.Next(0, 599); // locate square between 0 - 599
                                            iY = (iY <= 0 + iSquareLength) ? random.Next(1, 15) : iY; // check if on screen on top, random to make it look natural
                                            iY = (iY >= 599 - iSquareLength) ? random.Next(584 - iSquareLength, 599 - iSquareLength) : iY; // check if on screen on bottom
                                            canvas.AddRectangle(iX, iY, iSquareLength, iSquareLength, RandColor.GetColor());//Color.FromArgb(random.Next())
                                            
                                            iSquaresDrawn++;//keeps count of how many squares and loops been done
                                        }
                                        canvas.Render();//renders everythang

                                        //ask if they want to run again
                                        Console.Write("Run program again? (y/n): ");
                                        while (bRunAgain == true)//loops while bRunAgain is true
                                        {
                                            sYN = Console.ReadLine();//input for y or n
                                            sYN.ToLower();//lowers it so that user can use capital too
                                            if (sYN == "y")//if user wants to run it back, then ends the bRunAgain loop
                                            {
                                                bRunAgain = false;
                                            }
                                            if (sYN == "n")//if user wants to not run it back, then bNotAgain is set to false, and ends the bRunAgain loop
                                            {
                                                bNotAgain = false;
                                                bRunAgain = false;
                                            }
                                            else//user doesn't know what they want, ask again
                                            {
                                                Console.Write("Run program again? (y/n): ");
                                            }
                                        }
                                        bNumSquares = false;// number of squares checked out, they shouldn't loop again
                                    }
                                }
                                if(iSquareLength < 10 && iSquareLength > 200)
                                {
                                    Console.WriteLine("Input out of range! keep it between 10 and 200.");
                                }
                                else
                                {
                                    Console.WriteLine("You have entered an invalid input!");
                                }
                            }
                            bSquareLength = false;//square length input checked out, dont loop again
                        }
                    }
                    else
                    {
                        Console.WriteLine("You have entered an invalid input!");
                    }
                }
                if(bAgain == true)//set every loops back to true, so they can do their job again, clears the console and canvas too
                {
                    bRunAgain = true;
                    bSquareLength = true;
                    bNumSquares = true;
                    Console.Clear();
                    canvas.Clear();
                }
                if (bNotAgain == false)//they dont want to run it back, set bAgain to false and keep the others in false
                {
                    bAgain = false;

                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                }
            }
        }
    }
}
