using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SidePanel.Height = button1.Height;
            checkin1.BringToFront();

            //hover tool notes init
            //this.button1.MouseHover += button3_MouseHover;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            checkin1.BringToFront();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button2.Height;
            SidePanel.Top = button2.Top;
            checkout1.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login op = new login();
            op.Show();
            Hide();
        }

        private void checkout1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button6.Height;
            SidePanel.Top = button6.Top;
            ufv1.BringToFront();
        }
    }
}
