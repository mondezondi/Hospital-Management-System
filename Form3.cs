using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospital_Management_System
{

public partial class Form3 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-766BLG6;Initial Catalog=HOSPITALMS;Integrated Security=True;TrustServerCertificate=True");
        SqlCommand command = new SqlCommand();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            displayData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "INSERT INTO Patient VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Entry Added Successfully");
            displayData();
        }

        public void displayData()
        {
            connection.Open();
            string query = "SELECT * FROM Patient";
            command = new SqlCommand(query, connection);

            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            connection.Close();

            dataGridView1.DataSource = dt;

            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Add any additional logic if needed
        }
        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            string query = "DELETE FROM Patient";
            command = new SqlCommand(query, connection);
            command.ExecuteNonQuery();

            // No need to fill DataTable when performing a DELETE operation

            MessageBox.Show("Records Deleted Successfully");

            connection.Close();
            displayData(); // Assuming you have a method like displayData to refresh the DataGridView
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }
    }


}
   
    
