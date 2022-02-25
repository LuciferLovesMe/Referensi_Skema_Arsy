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

namespace Referensi_Skema_Arsy
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=asmodeus;Initial Catalog=ref_arsy;Integrated Security=True");
        SqlCommand command;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            command = new SqlCommand("select * from vaksinasi where nik = " + textBox1.Text, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                Utils.nik = reader.GetInt32(0);
                Utils.name = reader.GetString(1);
                Done done = new Done();
                this.Hide();
                done.ShowDialog();
            }
            else
            {
                Undone undone = new Undone();
                this.Hide();
                undone.ShowDialog();
            }
        }
    }
}
