using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBForm1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\DBForm1\DBForm1\Book.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand getAll = new SqlCommand(
                "SELECT Title, Pages FROM Books",
                con
                );
            SqlDataAdapter adapt = new SqlDataAdapter(getAll);
            DataTable dt = new DataTable();
            con.Open();
            adapt.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int pages = Convert.ToInt32( numericUpDown1.Value);
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\DBForm1\DBForm1\Book.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand getAll = new SqlCommand(
                "SELECT * FROM Books WHERE Pages >= @Pages",
                con
                );
            getAll.Parameters.AddWithValue("Pages", pages);
            SqlDataAdapter adapt = new SqlDataAdapter(getAll);
            DataTable dt = new DataTable();
            con.Open();
            adapt.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            int pages = Convert.ToInt32(numericUpDown2.Value);
            string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Projects\DBForm1\DBForm1\Book.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            SqlCommand insert = new SqlCommand(
                "INSERT INTO Books (Title, Pages) VALUES (@Title, @Pages)",
                con
            );
            insert.Parameters.AddWithValue("Title", title);
            insert.Parameters.AddWithValue("Pages", pages);
            con.Open();
            insert.ExecuteNonQuery();
            SqlCommand getAll = new SqlCommand(
                "SELECT Title, Pages FROM Books",
                con
                );
            SqlDataAdapter adapt = new SqlDataAdapter(getAll);
            DataTable dt = new DataTable();
            adapt.Fill(dt);
            con.Close();

            dataGridView1.DataSource = dt;

        }
    }
}
