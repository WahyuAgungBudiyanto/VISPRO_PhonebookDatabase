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

namespace CRUD_AGUNG
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        Insert forminsert = new Insert();
        Update formupdate = new Update();
        Delete formdelete = new Delete();
        private void button_insert_Click(object sender, EventArgs e)
        {
            
            forminsert.TopLevel = false;
            panel_utama.Controls.Add(forminsert);
            forminsert.BringToFront();
            forminsert.Show();

            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * FROM phonebook.customer ORDER BY customer_name;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                forminsert.dataGridView_all.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_update_Click(object sender, EventArgs e)
        {
            
            formupdate.TopLevel = false;
            panel_utama.Controls.Add(formupdate);
            formupdate.BringToFront();
            formupdate.Show();

            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * FROM phonebook.customer ORDER BY customer_name;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                formupdate.dataGridView_all.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            
            formdelete.TopLevel = false;
            panel_utama.Controls.Add(formdelete);
            formdelete.BringToFront();
            formdelete.Show();

            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand("SELECT * FROM phonebook.customer ORDER BY customer_name;", myConn);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase;
                DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                formdelete.dataGridView_all.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_home_Click(object sender, EventArgs e)
        {
            btn_home.IdleFillColor = Color.LightGray;
            forminsert.Hide();
            formupdate.Hide();
            formdelete.Hide();
            this.BringToFront();
            this.Show();
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
