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

    public partial class Menu : Form
    {
        string connectstring = @"Data Source=DESKTOP-CO09DFI\MSSQLSERVER01;Initial Catalog=SANBAY;Integrated Security=True;TrustServerCertificate=True";
        SqlConnection con;
        SqlDataReader doc;
        SqlCommand cmd;
        string sql;
        int i = 0;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(connectstring);
            hienthi();
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

        private void buttonHienthi_Click(object sender, EventArgs e)
        {
            hienthi();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            Them addform = new Them();
            addform.Show();
            this.Hide();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            Sua fixform = new Sua();
            fixform.Show();
            this.Hide();
        }

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
