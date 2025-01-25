//ICA3 Calculate Area Circle
//Remar Gabriel Espaldon Bacadon

//Psuedo Code
//Display assignment and name at the top centered
//skip a line
//Prompt for radius of circle or sphere
//Read for the radius
//Scan for invalid number
//Prompt for a string input for whether they want area or volume
//turn all potential upper case letters into lower case
//Scan for volume or area
//if area and volume is entered then exit
//if no area or volume is entered then exit
//if volume or area is entered then proceed
//skip a line
//display results for either volume or area from the input radius.
//skip a line
//prompt for key input to exit



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
            double dRadius = 1;

            string sTitle = "ICA3-Cal-Area-Volume-Remar";
            string sAreaOrVolume = "Area";
            string sPressExit = "\nPress any key to exit: ";

            // Main Body
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;     // display the title in the middle
            Console.WriteLine(sTitle + "\n");

            // Prompt for Radius
            Console.Write("Enter the radius of a circle or a sphere: ");

            // Read for the Radius
            double.TryParse(Console.ReadLine(), out dRadius);

            // Scan for invalid number
            if(dRadius > 0)
            {
                //declaring temp variables
                bool bAreaString = false;
                bool bVolumeString = false;

                //Prompt for a string input for whether they want area or volume
                Console.Write("Please enter the desired calculation ('area' or 'volume'): ");
                sAreaOrVolume = Console.ReadLine();
                sAreaOrVolume = sAreaOrVolume.ToLower();

                // scans if there is an area or a volume
                bAreaString = sAreaOrVolume.Contains("area");
                bVolumeString = sAreaOrVolume.Contains("volume");

                // if area and volume is entered then exit
                if (bAreaString == true && bVolumeString == true)
                {
                    Console.WriteLine("You have entered an invalid value. The program will exit.");
                    Console.Write(sPressExit);
                    Console.ReadKey();
                }

                //if volume or area is entered then proceed
                Console.WriteLine("");//skip a line
                if(bAreaString == true)
                {
                    Console.WriteLine($"The are of a circle with radius of {dRadius} is {Math.PI*dRadius*dRadius:F2} square cm.");
                    Console.Write(sPressExit);
                    Console.ReadKey();

                }
                if (bVolumeString == true)
                {
                    Console.WriteLine($"The are of a circle with radius of {dRadius} is {(Math.PI * Math.Pow(dRadius, 3) * 4)/3:F2} cubic cm.");
                    Console.Write(sPressExit);
                    Console.ReadKey();

                }

                //if no area or volume is entered then exit
                if (bAreaString != true && bVolumeString != true)
                {
                    Console.WriteLine("You have entered an invalid value. The program will exit.");
                    Console.Write(sPressExit);
                    Console.ReadKey();

                }
            }
            // if invalid number is given
            else
            {
                Console.WriteLine("You have entered an invalid radius value. The program will exit.");
                Console.Write(sPressExit);
                Console.ReadKey();

            }
        }
    }
}
