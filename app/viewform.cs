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
    public partial class viewform : Form
    {
        string MyConnection2;
        MySqlConnection CON;
        MySqlDataReader RDR;
        DateTime now;
        MySqlCommand CMD;
        String QUERY,date1,d1;
        MySqlDataAdapter da;
        DataSet d;

        public viewform()
        {
            InitializeComponent();

             dateTimePicker1.Format = DateTimePickerFormat.Custom;
             dateTimePicker1.CustomFormat = "dd/MM/yyyy  ";
            

            // now = DateTime.Now;
            //   now = dateTimePicker1.Value;
            //date1 = now.ToString("yyyy-MM-dd");
            //date1 = now.ToString("yyyy-MM-dd");
            // textBox4.Text = Convert.ToString(now);
            //textBox1.Text = date1;
            

            // MessageBox.Show(textBox4.Text);
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

        private void button1_Click(object sender, EventArgs e)
        {
            login op = new login();
            op.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login op = new login();
            op.Show();
            Hide();
        }



        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //table content
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                QUERY = "SELECT * FROM register where person_to_meet='" + comboBox1.Text + "' and category='" + comboBox2.Text + "' and date>='" + dateTimePicker1.Text + "'";
                CMD = new MySqlCommand(QUERY, CON);

                try
                {
                    CON.Open();
                    da = new MySqlDataAdapter(QUERY, CON);
                    d = new DataSet();
                    da.Fill(d, "register");
                    dataGridView1.DataSource = d.Tables[0];
                    CON.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                finally
                {
                    CON.Close();
                }
            }

            else if(comboBox2.Text =="") // if category is empty
            {
                QUERY = "SELECT * FROM register where person_to_meet='" + comboBox1.Text + "'and date>='" + dateTimePicker1.Text + "'";
                CMD = new MySqlCommand(QUERY, CON);

                try
                {
                    CON.Open();
                    da = new MySqlDataAdapter(QUERY, CON);
                    d = new DataSet();
                    da.Fill(d, "register");
                    dataGridView1.DataSource = d.Tables[0];
                    CON.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                finally
                {
                    CON.Close();
                }
            }

            else if (comboBox1.Text == "") // if person to meet is empty
            {
                QUERY = "SELECT * FROM register where category='" + comboBox2.Text + "' and date>='" + dateTimePicker1.Text + "'";
                CMD = new MySqlCommand(QUERY, CON);

                try
                {
                    CON.Open();
                    da = new MySqlDataAdapter(QUERY, CON);
                    d = new DataSet();
                    da.Fill(d, "register");
                    dataGridView1.DataSource = d.Tables[0];
                    CON.Close();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                finally
                {
                    CON.Close();
                }
            }



        }

        
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void viewform_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'visitorappDataSet.register' table. You can move, or remove it, as needed.
            //this.registerTableAdapter.Fill(this.visitorappDataSet.register);


            //inputs all the person
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

            //inputs all the different type of category
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


            //table content

            QUERY = "SELECT * FROM register";
            CMD = new MySqlCommand(QUERY, CON);

            try
            {
                CON.Open();
                da = new MySqlDataAdapter(QUERY, CON);
                d = new DataSet();
                da.Fill(d, "register");
                dataGridView1.DataSource = d.Tables[0];
                CON.Close();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            finally
            {
                CON.Close();
            }
        }



       
    }
}
