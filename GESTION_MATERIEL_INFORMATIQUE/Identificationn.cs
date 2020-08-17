using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GESTION_MATERIEL_INFORMATIQUE
{
    public partial class Identificationn : Form
    {
        SqlConnection cnx = new SqlConnection("Data Source=(local);Initial Catalog=Materiel;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        public Identificationn()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = GESTION_MATERIEL_INFORMATIQUE.Properties.Settings.Default.userName;
            textBox2.Text = GESTION_MATERIEL_INFORMATIQUE.Properties.Settings.Default.passUser;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {

                Properties.Settings.Default.userName = textBox1.Text;
                Properties.Settings.Default.passUser = textBox2.Text;
                Properties.Settings.Default.Save();
            }
            String username = textBox1.Text;
            cnx.Open();

            cmd = new SqlCommand("select * from Authen where Compte='" + textBox1.Text + "' and Motdepasse='" + textBox2.Text + "'", cnx);

            da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                globals.username = dt.Rows[0]["Compte"].ToString();
                this.Hide();
                Menu f = new Menu();
                f.Show();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Compte vide !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Motdepass vide !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(" Nom de compte ou mot de passe incorrect", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            cnx.Close();
        }
    }
}
