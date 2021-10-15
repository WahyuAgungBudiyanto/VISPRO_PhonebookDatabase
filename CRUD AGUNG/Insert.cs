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
    public partial class Insert : Form
    {
        DataTable dbdataset = new DataTable();
        public Insert()
        {
            InitializeComponent();
        }

        private void dataGridView_all_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.dataGridView_all.Rows[e.RowIndex];

            textBox_id.Text = row.Cells["customer_ID"].Value.ToString();
            textBox_name.Text = row.Cells["customer_name"].Value.ToString();
            textBox_phone.Text = row.Cells["customer_phone"].Value.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
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
                dataGridView_all.DataSource = bSource;
                sda.Update(dbdataset);

                DataView DV = new DataView(dbdataset);
                DV.RowFilter = string.Format("customer_name LIKE '%{0}%'", textBox1.Text);
                dataGridView_all.DataSource = DV;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_insert_Click(object sender, EventArgs e)
        {
            //connection 
            string myConnection = "datasource=localhost;port=3306;username=root;password=";
            string Query = "insert into phonebook.customer (customer_ID, customer_name,customer_phone) values('','" + this.textBox_name.Text + " ',' " + this.textBox_phone.Text + "');";
            MySqlConnection myConn = new MySqlConnection(myConnection);
            MySqlCommand cmdDatabase = new MySqlCommand(Query, myConn);
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myReader = cmdDatabase.ExecuteReader();
                MessageBox.Show("Data Inserted Successfuly");
                btn_reset_Click(sender, e);
                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //connection 
            string myConnection1 = "datasource=localhost;port=3306;username=root;password=";
            MySqlConnection myConn1 = new MySqlConnection(myConnection1);
            MySqlCommand cmdDatabase1 = new MySqlCommand("SELECT * FROM phonebook.customer ORDER BY customer_name;", myConn1);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmdDatabase1;
                //DataTable dbdataset = new DataTable();
                sda.Fill(dbdataset);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdataset;
                dataGridView_all.DataSource = bSource;
                sda.Update(dbdataset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            textBox_id.Text = "";
            textBox_name.Text = "";
            textBox_phone.Text = "";
            textBox1.Text = "";
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
