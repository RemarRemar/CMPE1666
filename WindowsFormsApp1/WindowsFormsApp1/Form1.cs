using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Print("call Shown");
                }

        private void Form1_Load(object sender, EventArgs e)
        {
            Print("call load");
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Print("call paint");
        }
        static void Print(string sPrint)
        {
            System.Diagnostics.Trace.WriteLine(sPrint);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Print("call FormClosing");
            MessageBox.Show("do you want to save le work");
        }
    }
}
