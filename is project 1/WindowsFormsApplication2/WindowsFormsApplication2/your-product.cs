using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.ComponentModel;
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
    public partial class your_product : Form
    {
        public your_product(string name,string po,Image im,string a,string f)
        {
           InitializeComponent();
            textBox1.Text = name;
            textBox2.Text = po;
            label5.Text = a;
            pictureBox1.Image = im;
            textBox3.Text = f;
        }
        public your_product()
        {
            InitializeComponent();

        }
        private void your_product_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            int x ;
            int.TryParse(label5.Text, out x);
            SqlCommand comm = new SqlCommand(" declare @w as int set @w=' " + x + "' select COUNT(* ) from image where [product-id]=@w;", con);
            var qw = (int)comm.ExecuteScalar();
            comm.Dispose();
            SqlDataAdapter comman = new SqlDataAdapter("  declare @w as int set @w=' " + x + "' select picture from image where [product-id]=@w ", con);
            DataTable t = new DataTable();
            comman.Fill(t);
            dataGridView1.DataSource = t;
            con.Close();
            dataGridView1.Columns[0].Width = 180;
   int rowcoubt = dataGridView1.Rows.Count;
            for (int i = 0; i < rowcoubt; i++)
            {
                dataGridView1.Rows[i].Height = 180;
            }
            DataGridViewImageColumn img = (DataGridViewImageColumn)dataGridView1.Columns[0];
            img.ImageLayout = DataGridViewImageCellLayout.Stretch;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int cou;
            int.TryParse(label5.Text, out cou);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            SqlCommand comamnd = new SqlCommand("select flag from product1 where [product-id] ='"+cou+"'",con);
            string gk = comamnd.ExecuteScalar().ToString();
            int z;
            int.TryParse(gk, out z);
        //    label4.Text = gk;
            if (z== 0)
            {
                string s = label5.Text;
                buyer g = new buyer(s);
                this.Hide();
                g.Show();
            }
            else if(z==1)
                MessageBox.Show("sorry this product sold");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
