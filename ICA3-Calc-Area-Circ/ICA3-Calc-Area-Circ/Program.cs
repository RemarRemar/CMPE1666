//ICA3 Calculate Area Circle
//Remar Gabriel Espaldon Bacadon
//
//Psuedo Code
//Display assignment and name at the top centered
//skip a line
//Prompt for radius of circle or sphere
//Read for the radius
//Scan for invalid number
//if number is not negative and Real then proceed
//Prompt for a string input for whether they want area or volume
//turn all potential upper case letters into lower case
//Scan for volume and area
//if area and volume is entered then prompt exit
//if volume or area is entered then proceed
//skip a line
//display results for either volume or area from the input radius.
//skip a line
//prompt for key input to exit
//if no area or volume is entered then prompt exit
//if the radius is invalid then prompt exit




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA3_Calc_Area_Circ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variable Declaration!
            double dRadius = 1;//this is the radius, the user will replace this with their own input

            string sTitle = "ICA3-Cal-Area-Volume-Remar";//title
            string sAreaOrVolume = "Area";// this is the string for when the user decides between volume or area
            string sPressExit = "\nPress any key to exit: ";//made this cause I made the assignment more complicated and I don't want to type more

            // Main Body
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;     // moves the title in the middle
            Console.WriteLine(sTitle + "\n");//writes the centered titled and gives an extra space below after the writeline

            // Prompt for Radius
            Console.Write("Enter the radius of a circle or a sphere: ");//just a prompt for radius

            // Read for the Radius
            double.TryParse(Console.ReadLine(), out dRadius);//tryparse so that it doesn't crash but just gives 0

            // Scan for invalid number
            if (dRadius > 0)//if the user actually gave a number above 0, I don't do zero cause it makes more work
            {
                // declaring temp variables
                bool bAreaString = false;//to check if they input area
                bool bVolumeString = false;//^^ but for volume
                bool bBypassYes = false;// for the if at the very bottom, wether to bypass that or not

                // Prompt for a string input for whether they want area or volume
                Console.Write("Please enter the desired calculation ('area' or 'volume'): ");//prompt for area or volume
                sAreaOrVolume = Console.ReadLine();//reads their input for ^^
                sAreaOrVolume = sAreaOrVolume.ToLower();// turn the entire string into lowercase

                // scans if there is an area or a volume
                bAreaString = sAreaOrVolume.Contains("area");//Contains looks if there's an "area" inside string, don't matter if its 8dArea213asd or d Area javdm asd then gives a true or false
                bVolumeString = sAreaOrVolume.Contains("volume");//^^ but for volume

                // if area and volume is entered at the same time, then exit
                if (bAreaString == true && bVolumeString == true)//checks if area and volume is in the input
                {
                    bAreaString = false;//makes it so program doesn't trigger the other if commands after this
                    bVolumeString = false;//^^
                    bBypassYes = true;//^^ but for the if that scans for if area and value is not typed

                    Console.WriteLine("You have entered an invalid value. The program will exit.");//just tells the user they goofed, and peace
                    Console.Write(sPressExit);//I knowing i might be typing this a lot I made it into a variable I can call
                    Console.ReadKey(true);//to look out for any key pressed to exit, true for I don't wanna see what they typed
                }

                //if volume or area is entered then proceed
                Console.WriteLine("");//skip a line
                if (bAreaString == true)//if they are asking for area
                {
                    Console.WriteLine($"The area of a circle with radius of {dRadius} is {Math.PI * dRadius * dRadius:F2} square cm.");//calculates the area and displays it
                    Console.Write(sPressExit);//knowing i might be typing this a lot I made it into a variable I can call
                    Console.ReadKey(true);//to look out for any key pressed to exit, true for I don't wanna see what they typed

                }
                if (bVolumeString == true)//if they asked for volume
                {
                    Console.WriteLine($"The volume of a circle with radius of {dRadius} is {(Math.PI * Math.Pow(dRadius, 3) * 4) / 3:F2} cubic cm.");//calculates volume + displays it
                    Console.Write(sPressExit);//knowing i might be typing this a lot I made it into a variable I can call
                    Console.ReadKey(true);//to look out for any key pressed to exit, true for I don't wanna see what they typed

                }

                //if no area or volume is typed then exit
                if (bAreaString != true && bVolumeString != true && bBypassYes == false)//if the user didn't input area or volume, the bypass is so that this don't run again after the if Area&&Volume is there
                {
                    Console.WriteLine("You have entered an invalid value. The program will exit.");//THEY WULL KNOW, THEY HAVE ERRED
                    Console.Write(sPressExit);//knowing i might be typing this a lot I made it into a variable I can call
                    Console.ReadKey(true);//to look out for any key pressed to exit, true for I don't wanna see what they typed

                }
            }
            // if invalid number is given
            else//so that this don't come out after the running the whole calculation
            {
                Console.WriteLine("\nYou have entered an invalid radius value. The program will exit.");//it tells the user they didn't use positive numbers or Real numbers
                Console.Write(sPressExit);//knowing i might be typing this a lot I made it into a variable I can call
                Console.ReadKey(true);//to look out for any key pressed to exit, true for I don't wanna see what they typed

            }
        }
    }
}
