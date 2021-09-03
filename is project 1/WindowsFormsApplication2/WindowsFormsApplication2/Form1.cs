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
using System.Drawing.Imaging;
namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            SqlDataAdapter adabter = new SqlDataAdapter("SELECT[product-id], [product-description1],[product-price1],[product-image] FROM product1 ", con);
            DataTable ta = new DataTable();
            adabter.Fill(ta);
            dataGridView2.DataSource = ta;
            dataGridView2.Columns[3].Width = 180;
            int rowcoubt = dataGridView2.Rows.Count;
            for (int i = 0; i < rowcoubt; i++)
            {
                dataGridView2.Rows[i].Height = 180;
            }

            DataGridViewImageColumn img = (DataGridViewImageColumn)dataGridView2.Columns[3];
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
            con.Close();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            seller a = new seller();
            this.Hide();
            a.Show();
        }
       
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string op = dataGridView2.SelectedRows[0].Cells["product-id"].Value.ToString();
            int dg = Convert.ToInt32(op);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            string sql = "declare @df as int set @df= '"+dg+"'select MAX([auction-price]) from auction1 where [product-id]=@df;";
            SqlCommand command = new SqlCommand(sql, con);
            string sd = command.ExecuteScalar().ToString();
            command.Dispose();
            con.Close();
            string name = dataGridView2.SelectedRows[0].Cells["product-description1"].Value.ToString();
            string des = dataGridView2.SelectedRows[0].Cells["product-price1"].Value.ToString();
            string id = dataGridView2.SelectedRows[0].Cells["product-id"].Value.ToString();
            var data = (Byte[])(dataGridView2.SelectedRows[0].Cells["product-image"].Value);
            var stream = new MemoryStream(data);
          
            
            your_product f = new your_product(name,des,Image.FromStream(stream),id,sd);
            this.Hide();
            f.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int qw;
            int.TryParse(textBox1.Text, out qw);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            string re = "Select [seller-name], password1 from seller1 where [seller-id]='" + qw+ "' and password1='" + textBox2.Text.Trim() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(re, con);
            DataTable ds = new DataTable();
            sda.Fill(ds);
            if (ds.Rows.Count == 1)
            {
                SqlCommand p = new SqlCommand(" select [seller-id] from seller1 where [seller-id]='" +qw + "'", con);
                string gf = p.ExecuteScalar().ToString();
                int f;
                int.TryParse(gf, out f);
                Form2 d = new Form2(f);
                this.Hide();
                d.Show();
            }
            else
                MessageBox.Show("incorrect");
            con.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
