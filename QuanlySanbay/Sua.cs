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

namespace QuanlySanbay
{
    public partial class Sua : Form
    {
        string connectstring = @"Data Source=DESKTOP-CO09DFI\MSSQLSERVER01;Initial Catalog=SANBAY;Integrated Security=True;TrustServerCertificate=True";
        SqlCommand cmd;
        SqlConnection con;
        SqlDataReader doc;
        int i = 0;
        string sql;
        public Sua()
        {
            InitializeComponent();
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            this.Hide();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            textBoxMamb.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBoxTenmb.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBoxNamsx.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBoxsogiobay.Text = listView1.SelectedItems[0].SubItems[3].Text;
        }

        private void Sua_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectstring);
            hienthi();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            con.Open();
            sql = @"update maybay set
                    mamb = '"+textBoxMamb.Text+@"',
                    tenmb = '"+textBoxTenmb.Text+@"',
                    namsx = '"+textBoxNamsx.Text+@"',
                    sogiobay = '"+textBoxsogiobay.Text+@"'
                    where mamb = '"+textBoxMamb.Text+@"'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("sua thanh cong");
            hienthi();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            con.Open();
            sql = @"delete from maybay where
                    mamb = '" + textBoxMamb.Text + @"'";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("xoa thanh cong");
            hienthi();
        }
    }
}
