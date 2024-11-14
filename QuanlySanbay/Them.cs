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

namespace QuanlySanbay
{
    public partial class Them : Form
    {
        string connectstring = @"Data Source=DESKTOP-CO09DFI\MSSQLSERVER01;Initial Catalog=SANBAY;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection con;
        SqlDataReader doc;
        SqlCommand cmd;
        string sql;
        int i = 0;
        public Them()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void hienthi()
        {
            listView1.Items.Clear();
            listView1.View = View.Details;
            con.Open();
            i = 0;
            sql = @"select * from maybay";
            cmd = new SqlCommand(sql, con);
            doc = cmd.ExecuteReader();
            while (doc.Read())
            {
                listView1.Items.Add(doc[0].ToString());
                listView1.Items[i].SubItems.Add(doc[1].ToString());
                listView1.Items[i].SubItems.Add(doc[2].ToString());
                listView1.Items[i].SubItems.Add(doc[3].ToString());
                i++;
            }
            con.Close();
        }

        private void Them_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectstring);
            hienthi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            sql = @"insert into maybay (mamb,tenmb,namsx,sogiobay) values
            ('" + textBoxMamb.Text + @"',
            '" + textBoxTenmb.Text + @"',
            " + textBoxNamsx.Text + @",
            " + textBoxsogiobay.Text + @")";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            hienthi();
            MessageBox.Show("them thanh cong");
        }
    }
}
