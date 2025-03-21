//ICA-11 Methods Overloading
//Remar Gabriel Bacadon

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA11_Utility;
namespace ICA11_MethodOverloading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iTest;
            double dTest;

            RegUtility.GetValue(out iTest, "Enter an integer: ");
            Console.WriteLine("iTest = {0}", iTest +"\n");

            RegUtility.GetValue(out iTest, "Enter a positive integer: ", 0);

            RegUtility.GetValue(out iTest, "Enter an integer from 0 to 100: ", 0, 100);
            Console.WriteLine("iTest = {0}", iTest + "\n");

            RegUtility.GetValue(out dTest, "Enter a double: ");
            Console.WriteLine("dTest = {0}", dTest + "\n");

            RegUtility.GetValue(out dTest, "Enter a positive double: ", 0.0);
            Console.WriteLine("dTest = {0}", dTest + "\n");

            RegUtility.GetValue(out dTest, "Enter a double from 0.0 to 100.0: ", 0, 100);
            Console.WriteLine("dTest = {0}", dTest + "\n");
        }
    }
}
