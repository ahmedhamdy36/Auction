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
    public partial class buyer : Form
    {
        public buyer(string a)
        {
            InitializeComponent();

            label6.Text = a;


        }
        public buyer()
        {
            InitializeComponent();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string w = label6.Text;
            string nam = name.Text;
            string pho = phone.Text;
            string mail = email.Text;
            string adr = adress.Text;
            string ine = price.Text;
            int rt;
            int.TryParse(ine, out rt);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IEEUB86;Initial Catalog=isproject;Integrated Security=True");
            con.Open();
            string sql=null;
            sql = "Insert into buyer1([buyer-name],[buyer-phone],[buyer-email],[buyer-adress]) Values(@nam,@pho,@mail,@adr)  ";
            SqlCommand command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@nam", name.Text);
            command.Parameters.AddWithValue("@pho", phone.Text);
            command.Parameters.AddWithValue("@mail", email.Text);
            command.Parameters.AddWithValue("@adr", adress.Text);
            command.ExecuteNonQuery();
            command.Dispose();
            SqlCommand comm = new SqlCommand("select top 1 [buyer-id] from buyer1 order by [buyer-id] desc", con);
            string ids = comm.ExecuteScalar().ToString();
            int it;
            int.TryParse(ids, out it);
            SqlCommand sl = new SqlCommand("Insert into auction1([auction-price],[product-id],[buyer-id]) Values(@rt,@w,'"+it+"')  ", con);
            sl.Parameters.AddWithValue("@rt", price.Text);
            sl.Parameters.AddWithValue("@w", label6.Text);
            sl.ExecuteScalar();
            MessageBox.Show("connection do");
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 s = new Form1();
            this.Hide();
            s.Show();
        }

        private void buyer_Load(object sender, EventArgs e)
        {

        }
    }
}
