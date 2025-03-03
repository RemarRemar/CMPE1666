//Remar Bacadon
//Lab 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using GDIDrawer;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CDrawer canvas = new CDrawer(160, 100);
            Random random = new Random();

            canvas.ContinuousUpdate = false;


            canvas.Scale = 5;
        }
    }
}
