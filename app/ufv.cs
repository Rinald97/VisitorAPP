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
    public partial class ufv : UserControl
    {
        string MyConnection2;
        MySqlConnection CON;
        MySqlDataReader RDR;
        DateTime now;
        MySqlCommand CMD;
        String QUERY, date1, d1;
        MySqlDataAdapter da;
        DataSet d;

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

            else if (comboBox2.Text == "") // if category is empty
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

        public ufv()
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

        private void ufv_Load(object sender, EventArgs e)
        {
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
