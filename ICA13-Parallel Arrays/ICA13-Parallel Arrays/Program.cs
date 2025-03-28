//Remar Gabriel Bacadon
//ICA 13 Parallel Arrays
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMPECommons;
namespace ICA13_Parallel_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int iArraySize = 0;

            string[] sArrayNames;
            double[] dArrayMarks;
            CMPE.Title("ICA13-Parallel Arrays");
            CMPE.GetValue(out iArraySize, "Enter the number of students in the class: ",4,10);
            MakeRecords(out sArrayNames, out dArrayMarks, iArraySize);
            Show(sArrayNames, dArrayMarks);
            Average(sArrayNames, dArrayMarks);
            Console.ReadKey();

        }
       
        static private void Average(string[] sArray, double[] dArray)
        {
            double[] dArrayClosest = new double[dArray.Length]; 
            double dAverage = 0;
            double tempd;
            int tempi = 9090999;
            for (int i = 0; i < dArrayClosest.Length; i++)
            {
                dAverage += dArray[i];
                
            }
            dAverage /= dArray.Length;
            tempd = Math.Abs(dArray[0] - dAverage);
            tempi = 0;
            for (int i = 1; i < dArrayClosest.Length; i++)
            {
                if (tempd > Math.Abs(dArray[i] - dAverage))
                {
                    tempi = i;
                    tempd = Math.Abs(dArray[i] - dAverage);
                }
               
            }

            Console.WriteLine($"\nThe average of the marks is {dAverage:f1} percent.");
            Console.WriteLine($"{sArray[tempi]} with {dArray[tempi]} is closest to the average");
        }
        static private void Show(string[] sArray1, double[] dArray2)
        {
            Console.WriteLine($"{"Name",15}   Mark");
            Console.WriteLine($"{"----",15}   ----");
            for (int i = 0; i<sArray1.Length; i++)
            {
                Console.WriteLine($"{sArray1[i],15} : {dArray2[i]:f1}");
            }
        }
        static private void MakeRecords(out string[] sArray1, out double[] dArray2, int iArraySize)
        {
            Random random = new Random();

            sArray1 = new string[iArraySize];
            dArray2 = new double[iArraySize];


            for (int i = 0; i < iArraySize; i++)
            {
                dArray2[i] = random.Next(0, 101);
                int iNameLength = random.Next(4, 12);//i'm adding the first and second leter at the same time
                for (int j = 0; j < iNameLength; j++)
                {
                    if (j == 0)
                    {
                        sArray1[i] = sArray1[i] + (char)random.Next(65, 91);//A to Z
                    }
                    sArray1[i] = sArray1[i] + (char)random.Next(97, 123);//a to z
                }
            }
        }
    }
}
