using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA15_Working_WithStructs
{
    
    internal class Program
    {
        private struct Employee
        {
            public int id;
            public double salary;
            public int age;
        }
        static void Main(string[] args)
        {
            Employee[] member = new Employee[15];
            member = MakeEmployee( member);

            Console.ReadKey();
        }
        private static void DisplayEmployees(Employee[] EmpArray, double threshold)
        {
            Employee[] something = new Employee[EmpArray.Length];
            int[] capitalistChain = new int[EmpArray.Length];
            for(int i = 0; i< capitalistChain.Length;i++)
            {
                capitalistChain[i] = member[i].salary;
            }

            for (int i = 0; i < EmpArray.Length - 1; i++)
            {
                Console.WriteLine($"Employee Id {EmpArray[i].id,2}: {EmpArray[i].age} years ${EmpArray[i].salary}");//dpesnt look like they used :c2
            }
        }
        private static void DisplayEmployees(Employee[] EmpArray)
        {
            for (int i = 0; i < EmpArray.Length - 1; i++)
            {
                Console.WriteLine($"Employee Id {EmpArray[i].id,2}: {EmpArray[i].age} years ${EmpArray[i].salary}");//dpesnt look like they used :c2
            }
        }
        private static Employee[] MakeEmployee(Employee[] member)//abomination
        {
            Employee[] members = new Employee[member.Length];
            
            members[0].id = 28;
            members[0].salary = 4500;
            members[0].age = 21;

            members[1].id = 53;
            members[1].salary = 2800;
            members[1].age = 33;

            members[2].id = 12;
            members[2].salary = 1900;
            members[2].age = 24;

            members[3].id = 18;
            members[3].salary = 3100;
            members[3].age = 58;

            members[4].id = 8;
            members[4].salary = 7000;
            members[4].age = 54;

            members[5].id = 2;
            members[5].salary = 3500;
            members[5].age = 36;

            members[6].id = 19;
            members[6].salary = 2200;
            members[6].age = 41;

            members[7].id = 57;
            members[7].salary = 2800;
            members[7].age = 44;

            members[8].id = 62;
            members[8].salary = 2850;
            members[8].age = 33;

            members[9].id = 34;
            members[9].salary = 3150;
            members[9].age = 36;

            members[10].id = 23;
            members[10].salary = 4000;
            members[10].age = 40;

            members[11].id = 14;
            members[11].salary = 4500;
            members[11].age = 33;

            members[12].id = 48;
            members[12].salary = 6000;
            members[12].age = 45;

            members[13].id = 35;
            members[13].salary = 7200;
            members[13].age = 46;

            members[14].id = 26;
            members[14].salary = 3800;
            members[14].age = 35;
            
            return members;
            
        }
    }
}
