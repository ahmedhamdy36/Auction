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
using System.IO;
namespace WindowsFormsApplication2
{
    public partial class seller : Form
    {
        public seller()
        {
            InitializeComponent();
        }
        
        string pi;
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ope = new OpenFileDialog();
            ope.Filter = "JPG Files(*.jpg)|*.jpg|Png Files(*.png)|*.png|All files(*.*) |*.*";
            if (ope.ShowDialog() == DialogResult.OK)
            {
                pi = ope.FileName.ToString();
                textBox1.Text = pi;
                picture.ImageLocation = pi;
            }
        }
         private void button1_Click(object sender, EventArgs e)
        {
            FileStream stream = new FileStream(pi, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(stream);
            byte[] image = br.ReadBytes((int)stream.Length);
            string nam = name.Text;
            string emai = email.Text;
            string adres = adress.Text;
            string phon = phone.Text;
            string des = description.Text;
            string q = textBox1.Text;
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            SqlCommand command;
            string sql = "Insert Into seller1 ([seller-name],[seller-email],[seller-adress],[seller-phone],password1)values(@nam,@emi,@adres,@phon,@q) ";
            command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@nam", name.Text);
            command.Parameters.AddWithValue("@emi", email.Text);
            command.Parameters.AddWithValue("@adres", adress.Text);
            command.Parameters.AddWithValue("@phon", phone.Text);
            command.Parameters.AddWithValue("@q", textBox2.Text);
            command.ExecuteNonQuery();
            command.Dispose();
             SqlCommand com = new SqlCommand("  select top 1 [seller-id] from seller1   ORDER BY  [seller-id] DESC", con);
             string x = Convert.ToString(com.ExecuteScalar());
             int y;
             int.TryParse(x,out y);
             com.Dispose();
             SqlCommand sq = new SqlCommand("Insert Into product1([product-description1],[product-price1],[product-image],[seller-id],flag)values(@des,@rt,@image,@y,'"+0+"') ", con);
             sq.Parameters.AddWithValue("@des", description.Text);
             sq.Parameters.AddWithValue("@image", image);
             sq.Parameters.AddWithValue("@rt", price1.Text);
             sq.Parameters.AddWithValue("@y", y);
             sq.ExecuteScalar();
             com.ExecuteScalar();
             com.Dispose();
             con.Close();
             MessageBox.Show("   your ID is  " + y);
            add_picture s = new add_picture();
            this.Hide();
            s.Show(); 
        }
        private void seller_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'myprojectDataSet.seller' table. You can move, or remove it, as needed.
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.Show();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        
            }
    }
