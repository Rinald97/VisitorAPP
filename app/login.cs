using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace app
{
    public partial class login : Form
    {
        string MyConnection2;
        MySqlConnection CON;
        MySqlDataReader RDR;
        DateTime now;
        MySqlCommand CMD;
        String QUERY, date1, message;
        String date123;


        public login()
        {
            InitializeComponent();
            //This is my connection string i have assigned the database file address path  
            MyConnection2 = "datasource=localhost;port=300;database=visitorapp;username=root;password=mysql";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            CON = new MySqlConnection(MyConnection2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show(" enter all the inputs");
            }

            else
            {
                try
                {

                    String des;
                    QUERY = "select * from login where username='" + textBox1.Text + "'";
                    //This is command class which will handle the query and connection object.  
                    CMD = new MySqlCommand(QUERY, CON);
                    CON.Open();
                    CMD.ExecuteNonQuery();
                    RDR = CMD.ExecuteReader();
                    int i = 0, j = 0, k = 0;
                    while (RDR.Read())
                    {
                        if ((String)RDR["username"] == textBox1.Text)
                        {
                            i = 1;
                            if ((String)RDR["password"] == textBox2.Text)
                            {
                                j = 1;
                                if (comboBox1.Text == (String)RDR["designation"])
                                {
                                    k = 1;
                                }
                            }
                        }
                    }
                    RDR.Close();
                    CON.Close();


                    if (i == 0)
                    {
                        MessageBox.Show("usename does not exist");
                    }

                    else
                    {
                        if (j == 0)
                        {
                            MessageBox.Show("incorrect password");
                        }

                        else
                        {
                            if (k == 0)
                            {
                                MessageBox.Show("invalid designation");
                            }

                           if(k==1)
                            { if (comboBox1.Text == "Security")
                                {
                                    Form1 op = new Form1();
                                    op.Show();
                                    Hide();
                                }
                                //else if (comboBox1.Text == "Employee")
                                //{
                                //    user op = new user();
                                //    op.Show();
                                //    Hide();
                                //}
                                else if (comboBox1.Text == "Receptionist")
                                {
                                    viewform op = new viewform();
                                    op.Show();
                                    Hide();
                                }
                                else
                                {
                                    MessageBox.Show("invalid input option");
                                }
                            }
                        }

                    }
                }
                catch(Exception err)
                {
                    MessageBox.Show(err.Message);
                    CON.Close();
                }
            }
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
