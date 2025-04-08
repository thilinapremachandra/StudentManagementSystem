using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StudentManagementSystem
{
    public partial class mainform : Form
    {
        private string connectionString = @"Data Source=(localdb)\ProjectModels;Initial Catalog=student;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public mainform()
        {
            InitializeComponent();
            LoadStudentData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void LoadStudentData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM students";
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable; // Bind the DataTable to the DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Get values from the textboxes
            string name = txtname.Text.Trim();      // Assuming textBox1 is for Name
            string address = txtaddress.Text.Trim();   // Assuming textBox2 is for Address
            string email = txtemails.Text.Trim();     // Assuming textBox3 is for Email

            // Validate input
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter all details (Name, Address, and Email).");
                return;
            }

            // SQL query to insert data into the students table
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "INSERT INTO students (Name, Address, Email) VALUES (@Name, @Address, @Email)";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student details added successfully!");
                        LoadStudentData();
                    }
                    else
                    {
                        MessageBox.Show("Failed to add student details.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the values from the clicked row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Populate the textboxes with the values of the selected row
               txtname.Text = row.Cells["Name"].Value.ToString();
               txtregisterno.Text = row.Cells["RegNo"].Value.ToString();
                txtaddress.Text = row.Cells["Address"].Value.ToString();
                txtemails.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void mainform_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            // Ensure that a student is selected
            if (dataGridView1.CurrentRow != null)
            {
                // Get the RegNo of the selected row
                int regNo = Convert.ToInt32(dataGridView1.CurrentRow.Cells["RegNo"].Value);

                // Ask for confirmation before deletion
                var confirmResult = MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            string query = "DELETE FROM students WHERE RegNo = @RegNo";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@RegNo", regNo);

                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Student deleted successfully!");
                                LoadStudentData(); // Refresh DataGridView after deletion
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete student.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a student to delete.");
            }
        }

    }
}
