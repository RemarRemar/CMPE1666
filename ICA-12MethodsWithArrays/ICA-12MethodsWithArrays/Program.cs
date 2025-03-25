using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMPECommons;//I renamed it
namespace ICA_12MethodsWithArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bAgain = true;
            int iArraySize;
            while (bAgain)
            {
                Console.Clear();
                CMPE.Title("ICA - 12 Methods with Arrays\n");// I renamed CUtilities to CMPE its jsut shorter
                CMPE.GetValue(out iArraySize, "Enter the size of the array: ", 4, 15);
                MakeArray(out int[] iArray, iArraySize);
                Show(iArray);
                ShowReverse(iArray);
                Average(iArray);
                Largest(iArray);
                RunAgain(out bAgain);
            }
        }
       
        static private void MakeArray(out int[] iArray, int iArraySize)
        {
            Random arrayRandom = new Random();
            iArray = new int[iArraySize];
            for (int i = 0; i<iArraySize; i++)
            {
                iArray[i] = arrayRandom.Next(0, 101);
            }
        }
        static private void Show(int[] iArray)
        {
            Console.WriteLine("\nThe array contents...");
            for (int i = 0; i < iArray.Length; i++)
            {
                Console.WriteLine($"array[{i}] = {iArray[i]}");
            }
        }
        static private void ShowReverse(int[] iArray)
        {
            Console.WriteLine("\nThe array in reverse...");
            for (int i = (iArray.Length - 1); i > -1; i--)
            {
                Console.WriteLine($"array[{i}] = {iArray[i]}");
            }
        }
        static private void Average(int[] iArray)
        {
            double dAverage = 0;
            for (int i = 0; i < iArray.Length; i++)
            {
                dAverage += iArray[i];
            }
            dAverage /= iArray.Length;
            Console.WriteLine($"\nThe average is {dAverage}\n");
        }
        static private void Largest(int[] iArray)
        {
            int iMax = 0;
            int iIndex = 0;
            for (int i = 0; i < (iArray.Length - 1); i++)
            {
                if (iMax < iArray[i])
                {
                    iMax = iArray[i];
                    iIndex = i;
                }
            }
            Console.WriteLine($"the Largest Value is {iMax} at location {iIndex}.");
        }
        static private void RunAgain(out bool bAgain)
        {
            bAgain = true;
            char cCheck;
            string sCheck;
            for (int i = 0; i < 3; i++)
            {
                Console.Write("\nRun program again? (y/n)");
                while (Console.KeyAvailable)  // checks if key in kb buffer
                {
                    Console.ReadKey(intercept: true); // clears keyboard buffer if any unread are there
                }
                cCheck = Console.ReadKey(true).KeyChar;
                sCheck = cCheck.ToString();
                sCheck = sCheck.ToLower();
                switch (sCheck)
                {
                    case "y":
                        Console.Clear();
                        bAgain = true;
                        i = 3;
                        break;

                    case "n":
                        Console.Clear();
                        bAgain = false;
                        i = 3;
                        break;
                    default:
                        i--;
                        break;
                }
            }
        }
    }
}
