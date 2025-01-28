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

            double dGBCost = 0.0;
            double dMBCost = 0.0;
            double dKBCost = 0.0;
            double dBCost = 0.0;

            string sTitle = "Lab1 - Cell Phone Data Cost Calulator";
            Console.CursorLeft = (Console.WindowWidth - sTitle.Length) / 2;
            Console.Write(sTitle);

            Console.Write("\nEnter the number of bytes used: ");
            long.TryParse(Console.ReadLine(), out lB);

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

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("\n"+lGB);
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
            Console.Write($"{(lB * 0.01 + lKB * 0.02 + lMB * 0.25 + lGB * 12.00):C2}\n");
            Console.ReadKey();

        }
    }
}
