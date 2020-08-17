using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace GESTION_MATERIEL_INFORMATIQUE
{
    public partial class Consultation_Modele : Form
    {
        SqlConnection cnx = new SqlConnection("Data Source=(local);Initial Catalog=Materiel;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        Modele MM = new Modele();
        public Consultation_Modele()
        {
            InitializeComponent();
        }

        private void Consultation_Modele_Load(object sender, EventArgs e)
        {

            DGV1_model.ReadOnly = true;
            da = new SqlDataAdapter("SELECT DISTINCT [TYPE_MATERIEL]FROM [TYPE_MATERIEL] ", cnx);
            da.Fill(ds, "Ma");
            cmb_ty.DataSource = ds.Tables["Ma"];
            cmb_ty.DisplayMember = "TYPE_MATERIEL";
            cmb_ty.ValueMember = "TYPE_MATERIEL";

            DataSet dss = new DataSet();
            da = new SqlDataAdapter("SELECT DISTINCT [Marque]FROM [modele] ", cnx);
            da.Fill(dss, "Ma");
            cmb_ma.DataSource = dss.Tables["Ma"];
            cmb_ma.DisplayMember = "Marque";
            cmb_ma.ValueMember = "Marque";

            da = new SqlDataAdapter("SELECT [ID_modele],[Type],[Marque],[Modele],[caractéristique1],[caractéristique2],[caractéristique3],[caractéristique4],[caractéristique5],[caractéristique6],[caractéristique7],[caractéristique8],[caractéristique9],[Creer_par],[Date_de_creation],[Modifier_par],[Data_de_modification]FROM [modele]", cnx);
            da.Fill(dt);
            DGV1_model.DataSource = dt;
            nbr.Text = (DGV1_model.Rows.Count).ToString();
            nbr.TextAlign = HorizontalAlignment.Center;
            
            cmb_ty.SelectedIndex = -1;
            cmb_ma.SelectedIndex = -1;
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DGV1_model.ReadOnly = true;
            if (ds.Tables["MAT"] != null)
            {
                ds.Tables["MAT"].Clear();
            }
          
            if (cmb_ty.SelectedIndex == -1 && cmb_ma.SelectedIndex == -1)
            {
                da = new SqlDataAdapter("SELECT [ID_modele],[Type],[Marque],[Modele],[caractéristique1],[caractéristique2],[caractéristique3],[caractéristique4],[caractéristique5],[caractéristique6],[caractéristique7],[caractéristique8],[caractéristique9],[Creer_par],[Date_de_creation],[Modifier_par],[Data_de_modification] FROM [modele]", cnx);
                da.Fill(ds, "MAT");
                DGV1_model.DataSource = ds.Tables["MAT"];
                nbr.Text = (DGV1_model.Rows.Count).ToString();
            }
            else
            {
                if (cmb_ty.SelectedIndex != -1 && cmb_ma.SelectedIndex == -1) 
                {
                    da = new SqlDataAdapter("SELECT [ID_modele],[Type],[Marque],[Modele],[caractéristique1],[caractéristique2],[caractéristique3],[caractéristique4],[caractéristique5],[caractéristique6],[caractéristique7],[caractéristique8],[caractéristique9],[Creer_par],[Date_de_creation],[Modifier_par],[Data_de_modification]FROM [modele] Where [Type]='" + cmb_ty.SelectedValue + "'", cnx);
                    da.Fill(ds, "MAT");
                    DGV1_model.DataSource = ds.Tables["MAT"];
                    nbr.Text = (DGV1_model.Rows.Count).ToString();
                }
                else if (cmb_ma.SelectedIndex != -1 && cmb_ty.SelectedIndex == -1)
                {
                    da = new SqlDataAdapter("SELECT [ID_modele],[Type],[Marque],[Modele],[caractéristique1],[caractéristique2],[caractéristique3],[caractéristique4],[caractéristique5],[caractéristique6],[caractéristique7],[caractéristique8],[caractéristique9],[Creer_par],[Date_de_creation],[Modifier_par],[Data_de_modification]FROM [modele] Where [Marque]='" + cmb_ma.SelectedValue + "'", cnx);
                    da.Fill(ds, "MAT");
                    DGV1_model.DataSource = ds.Tables["MAT"];
                    nbr.Text = (DGV1_model.Rows.Count).ToString();
                }
                else 
                {
                    da = new SqlDataAdapter("SELECT [ID_modele],[Type],[Marque],[Modele],[caractéristique1],[caractéristique2],[caractéristique3],[caractéristique4],[caractéristique5],[caractéristique6],[caractéristique7],[caractéristique8],[caractéristique9],[Creer_par],[Date_de_creation],[Modifier_par],[Data_de_modification]FROM [modele] Where [Type]='" + cmb_ty.SelectedValue + "'and [Marque]='" + cmb_ma.SelectedValue + "'", cnx);
                    da.Fill(ds, "MAT");
                    DGV1_model.DataSource = ds.Tables["MAT"];
                    nbr.Text = (DGV1_model.Rows.Count).ToString();
                }
            }
            
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DGV1_model.DataSource = "";
            cmb_ty.SelectedIndex = -1;
            cmb_ma.SelectedIndex = -1;
            nbr.Text = "0";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Export\samplee.txt");
            try
            {
                string sLine = "";

                //This for loop loops through each row in the table
                for (int r = 0; r <= DGV1_model.Rows.Count - 1; r++)
                {
                    //This for loop loops through each column, and the row number
                    //is passed from the for loop above.
                    for (int c = 0; c <= DGV1_model.Columns.Count - 1; c++)
                    {
                        sLine = sLine + DGV1_model.Rows[r].Cells[c].Value;
                        if (c != DGV1_model.Columns.Count - 1)
                        {
                            //A comma is added as a text delimiter in order
                            //to separate each field in the text file.
                            //You can choose another character as a delimiter.
                            sLine = sLine + ",";
                        }
                    }
                    //The exported text is written to the text file, one line at a time.
                    file.WriteLine(sLine);
                    sLine = "";
                }

                file.Close();
                System.Windows.Forms.MessageBox.Show("Export Complete.", "Program Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception err)
            {
                System.Windows.Forms.MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                file.Close();
            }
        }

        private void DGV1_model_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
                          
        }

        private void DGV1_model_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (DGV1_model.Rows[e.RowIndex].Selected == true)
                    {
                        // DGV1.Rows[e.RowIndex].Selected = true;
                        // Index = e.RowIndex;
                        DGV1_model.CurrentCell = DGV1_model.Rows[e.RowIndex].Cells[0];
                        //contextMenuStrip1.Show(DGV1, e.Location);
                        contextMenuStrip2.Show(Cursor.Position);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void ajouterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Modele mm = new Modele();
            mm.Btn_add.Enabled = true;
            mm.Btn_update.Enabled = false;
            mm.ShowDialog();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modele mm = new Modele();
            mm.Btn_add.Enabled = false;
            mm.Btn_update.Enabled = true;
            mm = new Modele(DGV1_model.SelectedCells[1].Value.ToString());
            mm.ShowDialog();
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Voulez-vous supprimer ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                // DGV1.Rows.RemoveAt(DGV1.SelectedRows[0].Index);
                cnx.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Modele] WHERE ID_modele ='" + DGV1_model.SelectedCells[0].Value.ToString() + "'", cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                MessageBox.Show("Données bien supprimer!", "Suppression", MessageBoxButtons.OK);
                cmb_ty.SelectedIndex = -1;
                cmb_ma.SelectedIndex = -1;
                simpleButton1.PerformClick();
                //DGV1.DataSource = "";  
            }
        }

        private void cmb_ty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}
