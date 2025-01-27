using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA4_Paper_Rock_Scissor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //variable declaration
            string sTitle = "ICA4-Paper Rock Scissor\n";
            string sChoice = "rock";

            Random randRPS = new Random();

            int iPC = 0;

            //Main program body
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.Write(sTitle);

            //Prompt
            Console.Write("Please select your play from the folowwing choices...\n\n");
            Console.WriteLine(" Paper");
            Console.WriteLine(" Rock");
            Console.WriteLine(" Scissors");
            Console.Write("Your selection: ");
            sChoice = Console.ReadLine().ToLower();
            //no fuckying IFS OR ELSES
            if(sChoice == "rock" || sChoice == "paper" || sChoice == "Scissors")
            {
                iPC = randRPS.Next(0, 3);
                switch (iPC)
                {
                    case 1:
                        Console.WriteLine("Computer played paper and you played " + sChoice + ".");

                        break;
                    case 2:
                        Console.WriteLine("Computer played scissors and you played " + sChoice + ".");

                        break;
                    default:
                        Console.WriteLine("Computer played rock and you played " + sChoice + ".");
                        break;
                }
                
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("You have entered an invalid word or atleast misspelled it");
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
            
        }
    }
}
