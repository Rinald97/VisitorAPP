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

namespace app
{
    public partial class checkout : UserControl
    {
        string MyConnection2;
        MySqlConnection CON;
        MySqlDataReader RDR;
        DateTime now;
        MySqlCommand CMD;
        String QUERY;

        public checkout()
        {
            InitializeComponent();
            

            now = DateTime.Now;
            textBox2.Text = Convert.ToString(DateTime.Now.ToLongTimeString());

            // MessageBox.Show(textBox4.Text);
            //This is my connection string i have assigned the database file address path  
            MyConnection2 = "datasource=localhost;port=300;database=visitorapp;username=root;password=mysql";
            //This is  MySqlConnection here i have created the object and pass my connection string.  
            CON = new MySqlConnection(MyConnection2);
        }

        private void checkout_Load(object sender, EventArgs e)
        {
            

            //inputs all the different type od category
            QUERY = "SELECT DISTINCT(`types`) FROM `category`";
            CMD = new MySqlCommand(QUERY, CON);
            CON.Open();
            RDR = CMD.ExecuteReader();
            while (RDR.Read())
            {
                comboBox1.Items.Add(RDR["types"]);
            }
            RDR.Close();
            CON.Close();

           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QUERY = "Update register Set checkout='" + textBox2.Text + "' Where pass_id='" + comboBox1.Text + "' and category='"+comboBox1.Text+"'";

            CMD = new MySqlCommand(QUERY, CON);
            CMD.CommandType = CommandType.Text;
            CON.Open();
            CMD.ExecuteNonQuery();
            // can do the error checking as above codes
            MessageBox.Show("Record updated successfully", "MESSAGE");

            CON.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Enter all the details");
            }
            else
            {
                QUERY = "Update register Set checkout='" + textBox2.Text + "' Where pass_id='" + textBox1.Text + "'and category='" + comboBox1.Text + "'";
                CMD = new MySqlCommand(QUERY, CON);
                CMD.CommandType = CommandType.Text;
                CON.Open();
                CMD.ExecuteNonQuery();
                // can do the error checking as above codes
                MessageBox.Show("Record updated successfully", "MESSAGE");
                CON.Close();
                textBox1.Text = "";              
                comboBox1.Text = "";
            }
            textBox2.Text = Convert.ToString(DateTime.Now.ToLongTimeString());

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
