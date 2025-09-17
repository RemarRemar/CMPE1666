//***********************************************************************************
//Program: ICA02_Application_Lifecycle__Timeline.cs
//Description: Windows Forms Apps first look
//Date: 09/09/25
//Author: Remar Gabriel Bacadon
//Course: CMPE1666
//Class: CNTA01
//***********************************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICA02_Application_Lifecycle__Timeline
{
    public partial class Form1 : Form
    {
        public Form1()//form constructior(a function with the same name as the class)
        {
            InitializeComponent();
            System.Diagnostics.Trace.WriteLine($"Calling Form Constructor");//this is how to Println/WriteLine here
        }

        private void Form1_Load(object sender, EventArgs e)//form load
        {
            System.Diagnostics.Trace.WriteLine($"Calling Form Load Event");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)//form closing
        {
            System.Diagnostics.Trace.WriteLine($"Calling Form Closing Event");
        }

        private void Form1_Activated(object sender, EventArgs e) //form activated
        {
            System.Diagnostics.Trace.WriteLine($"Calling Form Activated Event");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)// form Paint
        {
            System.Diagnostics.Trace.WriteLine($"Calling Form Paint Event");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)//form Closed
        {
            System.Diagnostics.Trace.WriteLine($"Calling Form Closed Event");
        }

        private void Form1_Deactivate(object sender, EventArgs e)//form Deactivate
        {
            System.Diagnostics.Trace.WriteLine($"Calling Form Deactivate Event");
        }

        private void Form1_Shown(object sender, EventArgs e)//form Shown
        {
            System.Diagnostics.Trace.WriteLine($"Calling Form Shown Event");
        }
    }
}
