using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;
using System.Net.Mail;
using System.Text;

namespace app
{
    public partial class checkin : UserControl
    {
        string MyConnection2;
        MySqlConnection CON;
        MySqlDataReader RDR;
        DateTime now;
        MySqlCommand CMD;
        String QUERY,date1,message;
        String date123;
        public checkin()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = " dd/MM/yyyy ";
            

           // now = dateTimePicker1.Value;
            //   date1 = DateTime.Now.ToLongTimeString();
            String date123 = now.ToString("yyyy-MM-dd");
            //now = dateTimePicker1.Value.Date;
            //date1 = now.ToString("yyyy-MM-dd HH:mm:ss");
            //textBox4.Text = Convert.ToString(date1);
            //MessageBox.Show(" "+ DateTime.Now.ToLongDateString()+" "+ DateTime.Now.ToLongTimeString() +" ");
            textBox4.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
            //This is my connection string i have assigned the database file address path  
            MyConnection2 = "datasource=localhost;port=300;database=visitorapp;username=root;password=mysql";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            CON = new MySqlConnection(MyConnection2);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Enter all the details");
                textBox4.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
            }

            else if(textBox3.Text.GetType()== typeof(int))
            {
                MessageBox.Show("enter proper pass id");
                textBox4.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
            }
           
            else
            {
                try
                {
                    now = dateTimePicker1.Value;
                    //   date1 = DateTime.Now.ToLongTimeString();
                    date123 = now.ToString("yyyy-MM-dd");
                    //This is my insert query in which i am taking input from the user through windows forms                 
                    string Query = "INSERT INTO register (`name`, `address`, `person_to_meet`, `category`,`pass_id`, `checkin`,`date`) VALUES ('" + this.textBox1.Text + "','" + this.textBox2.Text + "','" + this.comboBox1.Text + "','" + this.comboBox2.Text + "','" + this.textBox3.Text + "','" + this.textBox4.Text + "','" + date123 + "');";
                    //This is command class which will handle the query and connection object.  
                    CMD = new MySqlCommand(Query, CON);
                    CON.Open();
                    CMD.ExecuteNonQuery();
                    CON.Close();
                    MessageBox.Show("data stored");
                    textBox1.Text = ""; textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    date123 = now.ToString("yyyy-MM-dd");

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    CON.Close();
                }
                textBox4.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
            }
        }

        private void checkin_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(date1);
            //inputs all the person_to_meet names
            QUERY = "SELECT `name` FROM `person_to_meet`";
            CMD = new MySqlCommand(QUERY, CON);
            CON.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox1.Items.Add(RDR["name"]);
            }
            RDR.Close();
            CON.Close();

            //inputs all the different type od category
            QUERY = "SELECT DISTINCT(`types`) FROM `category`";
            CMD = new MySqlCommand(QUERY, CON);
            CON.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox2.Items.Add(RDR["types"]);
            }
            RDR.Close();
            CON.Close();
        }
    }
}
