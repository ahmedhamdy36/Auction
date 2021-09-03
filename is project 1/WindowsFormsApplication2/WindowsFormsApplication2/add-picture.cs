using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;


namespace WindowsFormsApplication2
{
    public partial class add_picture : Form
    {
        public add_picture()
        {
            InitializeComponent();
            DataGridViewImageColumn ima = new DataGridViewImageColumn();
            ima.HeaderText = "more image data base";
            ima.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.Columns.Add(ima);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 120;
            dataGridView1.AllowUserToAddRows = false;
           
        }
        string x;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ope = new OpenFileDialog();
            ope.Filter = "JPG Files(*.jpg)|*.jpg|Png Files(*.png)|*.png|All files(*.*) |*.*";
            if (ope.ShowDialog() == DialogResult.OK)
            {
                x = ope.FileName.ToString();
                pictureBox1.ImageLocation = x;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream strea = new FileStream(x, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(strea);
            byte[] image = br.ReadBytes((int)strea.Length);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            SqlCommand read = new SqlCommand("SELECT TOP 1 [product-id] FROM [product1] ORDER BY [product-id] DESC", con);
            var count = (int)read.ExecuteScalar();
            SqlCommand command;
            string sql = "Insert Into image (picture,[product-id])  values(@image,@count ) ";
            command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@image", image);
            command.Parameters.AddWithValue("@count", count);
            command.ExecuteScalar();
            command.Dispose();
            con.Close();
            pictureBox1.Image = null;
          
            dataGridView1.Rows.Add(image);
            
        }

      


        private void button17_Click(object sender, EventArgs e)
        {
            Form1 bn = new Form1();
            this.Hide();
            bn.Show();


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

       
    }
}
