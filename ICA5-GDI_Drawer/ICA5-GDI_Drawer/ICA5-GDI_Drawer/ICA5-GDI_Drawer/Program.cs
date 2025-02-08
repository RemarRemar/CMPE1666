/*Remar Gabriel Espaldon Bacadon  
 *GDI Drawer
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;//needed for GDI Drawer
using GDIDrawer;
using System.Runtime.InteropServices;

namespace ICA5_GDI_Drawer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variables
            int iDiameter;
            int iX = 0;
            int iY = 0;

            bool bExitCorrectly = false;//tired of copy pasting cwrite, pres key cont, readkey...
            bool bDiameter = false;//checks if diameter code checks out
            bool bX = false;//checks for x code
            bool bY = false;//checks for y code

            CDrawer Canvas = new CDrawer(300, 300, false);//makes the canvas, renders it though even though I put in false.
            //main body program

            //Title
            Console.ForegroundColor = ConsoleColor.Green;//make it fancy to distiguish it from the common rabble
            Console.WriteLine("ICA5-Remar Gabriel Bacadon\n");//didn't say I have to center it
            Console.ForegroundColor = ConsoleColor.White;//green is only for the title

            //ask for user input for ball diameter
            Console.Write("How big would you like the ball to be in pixels? ");//is prompt for diameter
            if (int.TryParse(Console.ReadLine(), out iDiameter) && iDiameter > 0)//takes the input for diameter and checks it for shenanigans
            {
                iDiameter = (iDiameter <= 10) ? 10 : iDiameter;// if diameter is less than or equal to 10, make diameter equal to ten.
                iDiameter = (iDiameter >= 100) ? 100 : iDiameter;//if diameter is more than or equal to 100, make diameter equal to one hundo.

                //ask user for x circle 'center' value
                Console.Write("\nInput where you like the ball to be horizontally in a 300x300: ");//prompt for where ball is in X axis
                if(int.TryParse(Console.ReadLine(), out iX) && iX > 0)//takes the input for x axis and checks it for shenanigans
                {
                    iX = (iX <= (iDiameter / 2)) ? (iDiameter / 2) + 1 : iX;//if ball is overlapping or way past the left side wall, move it in.
                    iX = (iX >= (300 - (iDiameter / 2))) ? (300 - (iDiameter / 2)) - 1 : iX;//if ball is overlapping or way past the right side wall, move it in.
                    bX = true;//it checks out
                             
                    //ask user for y circle 'center' value
                    Console.Write("\nInput where you like the ball to be vertically in a 300x300: ");//prompt for where bal is in Y axis
                    if (int.TryParse(Console.ReadLine(), out iY) && iY > 0)//takes the input for y axis and checks it for shenanigans
                    {
                        iY = (iY <= (iDiameter / 2)) ? (iDiameter / 2) + 1 : iY;//if ball is overlapping or way past the top side wall, move it in.
                        iY = (iY >= (300 - (iDiameter / 2))) ? (300 - (iDiameter / 2)) - 1 : iY;//if ball is overlapping or way past the bottom side wall, move it in.
                        bY = true;//it checks out
                    }
                }
                bDiameter = true;//diameter checks out
            }
            if(bDiameter == true && bX == true && bY == true)//all three checks out! move on to render
            {
                Canvas.AddCenteredEllipse(iX, iY, iDiameter, iDiameter, Color.Red);
                Canvas.Render();
                bExitCorrectly = true;
            }
            if(bExitCorrectly == false)//one of em never checked out, they get the invalid hammer
            {
                Console.WriteLine("\nYou have entered an invalid value.\n");
                Console.Write("Press any key to exit");
                Console.ReadKey();
            }
            else//everything checked out
            {
                Console.Write("\nPress any key to exit");
                Console.ReadKey();
            }

        }
    }
}
