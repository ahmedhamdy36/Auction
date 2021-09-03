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

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2(int gh)
        {
            InitializeComponent();
            string g = Convert.ToString(gh);
            label1.Text = g;
            int c;
            int.TryParse(g, out c);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            SqlCommand command = new SqlCommand("select [product-description1] from product1 where [seller-id]='" + gh + "'", con);
            string a = command.ExecuteScalar().ToString();
            textBox1.Text = a;
            SqlCommand comman = new SqlCommand("select [product-price1] from product1 where [seller-id]='" + gh + "'", con);
            string b = comman.ExecuteScalar().ToString();
            textBox2.Text = b;
            SqlCommand fh = new SqlCommand("   select [product-id] from product1 where [seller-id]='" + c + "'", con);
            string tr = fh.ExecuteScalar().ToString();
            int ep;
            int.TryParse(tr, out ep);
            SqlCommand comm = new SqlCommand("select max([auction-price]) from auction1 where [product-id]='" + tr + "'", con);
            string d = comm.ExecuteScalar().ToString();
            textBox3.Text = d;
            if (textBox3.Text != "")
            {

                SqlCommand cv = new SqlCommand("  select [buyer-id] from auction1 where [auction-price]='" + d + "' and [product-id]='" + ep + "'   ", con);
                string cv2 = cv.ExecuteScalar().ToString();
                label5.Text = cv2;
                int cv3;
                int.TryParse(cv2, out cv3);
                SqlCommand sqlcom = new SqlCommand("select [buyer-name] from buyer1 where [buyer-id]='" + cv3 + "'", con);
                string h = sqlcom.ExecuteScalar().ToString();
                textBox6.Text = h;
                SqlCommand sqlco = new SqlCommand("select [buyer-phone] from buyer1 where [buyer-id]='" + cv3 + "'", con);
                string i = sqlco.ExecuteScalar().ToString();
                textBox7.Text = i;
                SqlCommand sqlc = new SqlCommand("select [buyer-adress] from buyer1 where [buyer-id]='" + cv3 + "'", con);
                textBox8.Text = sqlc.ExecuteScalar().ToString();
                SqlCommand sql = new SqlCommand("select [buyer-email] from buyer1 where [buyer-id]='" + cv3 + "'", con);
                textBox9.Text = sql.ExecuteScalar().ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int f;
            int.TryParse(label1.Text, out f);
            DialogResult result = MessageBox.Show("sure","are you sure",MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
                con.Open();
                SqlCommand adabter = new SqlCommand("update product1 Set flag='" + 1 + "'  where [seller-id]='" + f + "'  ", con);
                adabter.ExecuteScalar();
                con.Close();
            }
            else
                return;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Show();
        }
    }
}
