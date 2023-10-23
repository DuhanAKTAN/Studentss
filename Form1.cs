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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Studentss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=duhan;Initial Catalog=duhandb;Integrated Security=True");

        private void listBut_Click(object sender, EventArgs e)
        {
            this.tbl_studentTableAdapter.Fill(this.duhandbDataSet.tbl_student);
        }

        private void saveBut_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand query = new SqlCommand("insert into tbl_student (Name,Surname,City,Department,Year) values (@s1,@s2,@s3,@s4,@s5) ", conn);
            query.Parameters.AddWithValue("@s1", nameBox.Text);
            query.Parameters.AddWithValue("@s2", surnameBox.Text);
            query.Parameters.AddWithValue("@s3", cityBox.Text);
            query.Parameters.AddWithValue("@s4", departmentBox.Text);
            query.Parameters.AddWithValue("@s5", yearBox.Text);
            query.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("It is OK...");
            clear();
        }

        private void deleteBut_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand query = new SqlCommand("Delete from tbl_student where id = @d1", conn);
            query.Parameters.AddWithValue("@d1",idBox.Text);
            query.ExecuteNonQuery ();
            conn.Close();
            MessageBox.Show("It is Ok...");
            clear();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int choosen = dataGridView1.SelectedCells[0].RowIndex;
            idBox.Text = dataGridView1.Rows[choosen].Cells[0].Value.ToString();
            nameBox.Text = dataGridView1.Rows[choosen].Cells[1].Value.ToString();
            surnameBox.Text = dataGridView1.Rows[choosen].Cells[2].Value.ToString();    
            cityBox.Text = dataGridView1.Rows[choosen].Cells[3].Value.ToString();
            departmentBox.Text = dataGridView1.Rows[choosen].Cells[4].Value.ToString();
            yearBox.Text = dataGridView1.Rows[choosen].Cells[5].Value.ToString();
        }

        private void clearBut_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            idBox.Text= string.Empty; nameBox.Text= string.Empty; surnameBox.Text=string.Empty; cityBox.Text= string.Empty; 
            departmentBox.Text= string.Empty; yearBox.Text= string.Empty;
        }

        private void updateBut_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand query = new SqlCommand("Update tbl_student set Name=@u1,Surname=@u2,City=@u3,Department=@u4,Year=@u5 where id=@u6",conn);
            query.Parameters.AddWithValue("@u1", nameBox.Text);
            query.Parameters.AddWithValue("@u2", surnameBox.Text);
            query.Parameters.AddWithValue("@u3", cityBox.Text);
            query.Parameters.AddWithValue("@u4", departmentBox.Text);
            query.Parameters.AddWithValue("@u5", yearBox.Text);
            query.Parameters.AddWithValue("@u6", idBox.Text);
            query.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("It is OK...");
            clear();
        }
    }
}
















