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
        int iClickCounter = 0;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            Text = "Mouse is in :)";
            BackColor = Color.Green;
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            Text = "Mouse Left :(";
            iClickCounter = 0;
            BackColor = Color.Red;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //Text = $"MOUSE CLICKED :{++iClickCounter}";
           //Random rand = new Random();
            //BackColor = Color.FromArgb(rand.Next(50, 200), rand.Next(50, 200), rand.Next(50, 200));
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            if((++iClickCounter % 2) == 0)
            {
                Text = "Nice Form";
            }
            else
            {
                Text = $"MOUSE CLICKED :{iClickCounter}";
            }
        }
    }
}
