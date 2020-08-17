using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace GESTION_MATERIEL_INFORMATIQUE
{
    public partial class Marque : Form
    {
        public Marque()
        {
            InitializeComponent();
        }
        SqlConnection cnx = new SqlConnection("Data Source=(local);Initial Catalog=Materiel;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataReader dr;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                if (txt_marque.Text == "")
                {
                    MessageBox.Show("Le champ marque et vide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO [Materiel].[dbo].[Marque]([Marque])VALUES('" + txt_marque.Text + "')", cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajouté avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_marque.Text = "";
                    Loader();
                }
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void Loader()
        {
            DGV2.ReadOnly = true;
            if (ds.Tables["MAT"] != null)
            {
                ds.Tables["MAT"].Clear();
            }

            da = new SqlDataAdapter("SELECT TOP 1000 [ID],[Marque]FROM [Materiel].[dbo].[Marque]", cnx);
            da.Fill(ds, "MAT");
            DGV2.DataSource = ds.Tables["MAT"];
        }
       

        private void Marque2_Load_1(object sender, EventArgs e)
        {
            da = new SqlDataAdapter("SELECT TOP 1000 [ID],[Marque]FROM [Materiel].[dbo].[Marque] ", cnx);
            da.Fill(dt);
            DGV2.DataSource = dt;
            foreach (DataGridViewColumn column in DGV2.Columns)
            {
                column.Width = 257;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                if (txt_marque.Text == "")
                {
                    MessageBox.Show("Veuillez Remplire le champ marque", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmd = new SqlCommand("update Marque set [Marque] = '" + txt_marque.Text + "' where ID ='" + DGV2.SelectedCells[0].Value.ToString() + "'", cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modifié avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_marque.Text = "";
                    Loader();
                }

                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Voulez-vous supprimer ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                // DGV1.Rows.RemoveAt(DGV1.SelectedRows[0].Index);
                cnx.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Materiel].[dbo].[Marque]WHERE ID ='" + DGV2.SelectedCells[0].Value.ToString() + "'", cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                MessageBox.Show("Données bien supprimer!", "Suppression", MessageBoxButtons.OK);
                Loader();

            }
        }

        private void DGV2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (DGV2.Rows[e.RowIndex].Selected == true)
                    {
                        // DGV1.Rows[e.RowIndex].Selected = true;
                        // Index = e.RowIndex;
                        DGV2.CurrentCell = DGV2.Rows[e.RowIndex].Cells[1];
                        //contextMenuStrip1.Show(DGV1, e.Location);
                       
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Btn_Annuler_Click(object sender, EventArgs e)
        {
            txt_marque.Text = "";
           // DGV2.DataSource = "";
        }

        private void DGV2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cnx.Open();
            cmd = new SqlCommand("SELECT * FROM [Marque] where Marque='" + DGV2.SelectedCells[1].Value.ToString() + "'", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                txt_marque.Text = dr[1].ToString();
            }
            cnx.Close();
        }
    }
}
