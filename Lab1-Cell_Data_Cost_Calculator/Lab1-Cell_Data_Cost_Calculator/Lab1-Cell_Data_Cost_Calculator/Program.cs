/* Lab1 Cell Data Cost Calculator
 * Remar Gabriel Espaldon Bacadon
 * 
 * Psuedocode
 * Declare variables
 * Display Centered Title
 * Prompt for bytes used
 * Read for bytes used
 * check if user input is a valid number
 * if not, them display error and prompt for exit
 * check if the input is a negative number
 * if negative, then display error and prompt for exit
 * if positive then continue
 * display yellow colored title names for the values, Amount, Unit, Cost/unit, Total, make sure they are in a column
 * calculate how many whole gigabytes in the input, deduct from bytes
 * calculate how many whole megabytes, deduct
 * calculate how many kilobytes, deduct
 * calculate subtotal in dollars
 * in the columns, display how many GB, display "GB", display cost per/unit in numbers, repeat for MB, KB, and bytes
 * make a line on the total column
 * Display "Subtotal" on the Amount Column, and display the actual calculated subtotal in dollars
 * if GB is more or equal to 50, give 10% discount on the GB cost per/unit
 * ^continued, below subtotal display 10% discount, and below  New Subtotal on the amount column
 * ^continued, on the Total column display costs in dollars
 * below on the amount column 911 Access Fee, then below System Access Fee, then below Total before GST, then below GST
 * ^same for their respective costs on the total column, in dollars
 * make a line on the total column
 * on the amount column "Total for Data:", then the absolute total value(in dollars) on the Total Column
 * prompt exit with any key
 * read to exit
 */
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_Cell_Data_Cost_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long lB = 0;
            long lKB = 0;
            long lMB = 0;
            long lGB = 0;

            double dSubTotal = 0;

            string sTitle = "Lab1 - Cell Phone Data Cost Calulator";
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.Write(sTitle);

            Console.Write("\nEnter the number of bytes used: ");
            if (long.TryParse(Console.ReadLine(), out lB))
            {
                if (lB >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nAmount");
                    Console.CursorLeft = 15;
                    Console.Write("Unit");
                    Console.CursorLeft = 30;
                    Console.Write("Cost/unit");
                    Console.CursorLeft = 45;
                    Console.Write("Total");

                    lGB = lB / 1073741824;
                    lB %= 1073741824;
                    lMB = lB / 1048576;
                    lB %= 1048576;
                    lKB = lB / 1024;
                    lB %= 1024;
                    dSubTotal = lB * 0.01 + lKB * 0.02 + lMB * 0.25 + lGB * 12.00;

                    

                    Console.ForegroundColor = ConsoleColor.White;

                    Console.Write("\n" + lGB);
                    Console.CursorLeft = 15;
                    Console.Write("GB");
                    Console.CursorLeft = 30;
                    Console.Write("$12.00");
                    Console.CursorLeft = 45;
                    Console.WriteLine($"{lGB * 12.00:C2}");

                    Console.Write(lMB);
                    Console.CursorLeft = 15;
                    Console.Write("MB");
                    Console.CursorLeft = 30;
                    Console.Write("$0.25");
                    Console.CursorLeft = 45;
                    Console.WriteLine($"{lMB * 0.25:C2}");

                    Console.Write(lKB);
                    Console.CursorLeft = 15;
                    Console.Write("KB");
                    Console.CursorLeft = 30;
                    Console.Write("$0.02");
                    Console.CursorLeft = 45;
                    Console.WriteLine($"{lKB * 0.02:C2}");

                    Console.Write(lB);
                    Console.CursorLeft = 15;
                    Console.Write("Bytes");
                    Console.CursorLeft = 30;
                    Console.Write("$0.01");
                    Console.CursorLeft = 45;
                    Console.WriteLine($"{lB * 0.01:C2}");

                    Console.CursorLeft = 45;
                    Console.WriteLine("-------------------");

                    Console.Write("\nSubTotal");
                    Console.CursorLeft = 45;
                    Console.WriteLine($"{dSubTotal:C2}");

                    if(lGB >= 50) 
                    {
                        Console.Write("\n10% Discount");
                        Console.CursorLeft = 44;
                        Console.WriteLine($"-{(lGB * 12.00) * 0.1:C2}");
                        dSubTotal = lB * 0.01 + lKB * 0.02 + lMB * 0.25 + lGB * 12.00 * 0.9;

                        Console.Write("\nNew SubTotal");
                        Console.CursorLeft = 45;
                        Console.WriteLine($"{dSubTotal:C2}");
                    }

                    Console.Write("\n911 Access Fee");
                    Console.CursorLeft = 45;
                    Console.WriteLine("$0.95");

                    Console.Write("\nSystem Access Fee");
                    Console.CursorLeft = 45;
                    Console.WriteLine("$6.95");

                    Console.Write("\nTotal before GST");
                    Console.CursorLeft = 45;
                    Console.WriteLine($"{(dSubTotal + 0.95 + 6.95):C2}");

                    Console.Write("\nGST");
                    Console.CursorLeft = 45;
                    Console.WriteLine($"{((dSubTotal + 0.95 + 6.95) * 0.05):C2}");

                    Console.CursorLeft = 45;
                    Console.WriteLine("-------------------");

                    Console.Write("Total for Data:");
                    Console.CursorLeft = 45;
                    Console.WriteLine($"{((dSubTotal + 0.95 + 6.95) * 1.05):C2}");

                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                }
                if (lB < 0)
                {
                    Console.Write("\nyou have entered a negative value, which is invalid.");

                    Console.WriteLine("\nPress any key to exit.");
                    Console.ReadKey();
                }
               
            }
            else
            {
                Console.Write("\nyou have entered an invalid value.");

                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
