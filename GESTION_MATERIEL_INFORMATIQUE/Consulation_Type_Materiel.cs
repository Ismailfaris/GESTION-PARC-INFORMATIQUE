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
    public partial class Consulation_Type_Materiel : Form
    {
        SqlConnection cnx = new SqlConnection("Data Source=DESKTOP-1NG7LRA;Initial Catalog=Materiel;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        SqlDataReader dr ;
        Type_Materiel TM = new Type_Materiel();
        public Consulation_Type_Materiel()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            DGV1.ReadOnly = true;
            if (ds.Tables["MAT"] != null)
            {
                ds.Tables["MAT"].Clear();
            }
            if ( Cmb_Type.SelectedIndex==-1)
            {
                da = new SqlDataAdapter("SELECT [ID_TYPE_MATERIEL],[TYPE_MATERIEL],[caracteristique1],[caracteristique2],[caracteristique3],[caracteristique4],[caracteristique5],[caracteristique6],[caracteristique7],[caracteristique8],[caracteristique9],[Cree_Par],[Date_Creation],[Modifier_Par],[Date_Modification]FROM TYPE_MATERIEL ", cnx);
                da.Fill(ds, "MAT");
                DGV1.DataSource = ds.Tables["MAT"];
                nbr.Text = (DGV1.Rows.Count ).ToString(); 
            }
            else
            {
                da = new SqlDataAdapter("SELECT [ID_TYPE_MATERIEL],[TYPE_MATERIEL],[caracteristique1],[caracteristique2],[caracteristique3],[caracteristique4],[caracteristique5],[caracteristique6],[caracteristique7],[caracteristique8],[caracteristique9],[Cree_Par],[Date_Creation],[Modifier_Par],[Date_Modification]FROM TYPE_MATERIEL where [TYPE_MATERIEL]='" + Cmb_Type.SelectedValue + "'", cnx);
                da.Fill(ds, "MAT");
                DGV1.DataSource = ds.Tables["MAT"];
                nbr.Text = (DGV1.Rows.Count ).ToString(); 
            }
                                                                                   
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DGV1.DataSource = "";
            Cmb_Type.SelectedIndex = -1;
            nbr.Text = "0";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            cnx.Open();
            DataTable data = new DataTable();

            cmd =new SqlCommand("select * from TYPE_MATERIEL",cnx);
            
            dr = cmd.ExecuteReader();
            data.Load(dr);
            if (MessageBox.Show("Voulez vous enregistrer vos données ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string chemin = "";
                    saveFileDialog1.Filter = "Text Files |.*txt";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        chemin = saveFileDialog1.FileName;
                    }
                    StreamWriter st = new StreamWriter(chemin);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        st.WriteLine(data.Rows[i][0].ToString() + " " + data.Rows[i][1].ToString() + " " + data.Rows[i][2].ToString() + " " + data.Rows[i][3].ToString() + " " + data.Rows[i][4].ToString() + " " + data.Rows[i][5].ToString() + " " + data.Rows[i][6].ToString() + " " + data.Rows[i][7].ToString() + " " + data.Rows[i][8].ToString() + " " + data.Rows[i][9].ToString() + " " + data.Rows[i][10].ToString() );
                    }
                    st.Close();
                    MessageBox.Show("Données enregistrer avec succes !", "Confirmation", MessageBoxButtons.OK);
                }
                catch
                {
                    MessageBox.Show("Erreur d'exportation");
                }
                
            }
            cnx.Close();
        }

       
       

       
        private void Consulation_Type_Materiel_Load_1(object sender, EventArgs e)
        {
            
           // DGV1.RowHeadersVisible = false;


            da = new SqlDataAdapter("SELECT [ID_TYPE_MATERIEL] AS 'ID',[TYPE_MATERIEL] AS 'MATERIEL TYPE' ,[caracteristique1],[caracteristique2],[caracteristique3],[caracteristique4],[caracteristique5],[caracteristique6],[caracteristique7],[caracteristique8],[caracteristique9],[Cree_Par] AS 'CREE PAR' ,[Date_Creation] AS 'DATE CREATION',[Modifier_Par] AS' MODIFIER PAR',[Date_Modification] AS 'DATE DE MODIFICATION' FROM TYPE_MATERIEL ", cnx);
            da.Fill(dt);
            DGV1.DataSource = dt;
            nbr.Text = (DGV1.Rows.Count).ToString();
            nbr.TextAlign = HorizontalAlignment.Center; ;

            while (Cmb_Type.Text == "")
            {
                da = new SqlDataAdapter("select * from TYPE_MATERIEL", cnx);
                da.Fill(ds, "Ma");
                Cmb_Type.DataSource = ds.Tables["Ma"];
                Cmb_Type.DisplayMember = "TYPE_MATERIEL";
                Cmb_Type.ValueMember = "TYPE_MATERIEL";
            }
            
        }

        private void DGV1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
           
        }
        public void Vide()
        {
            if ( TM.txt_car1.Text != "" || TM.txt_car2.Text != "" || TM.txt_car3.Text != "" || TM.txt_car4.Text != "" || TM.txt_car5.Text != "" || TM.txt_car6.Text != "" || TM.txt_car8.Text != "" || TM.txt_car7.Text != "" || TM.txt_car9.Text != "" || TM.txt_Type.Text != "" ) 
            {
               
                TM.txt_car1.Text = "";
                TM.txt_car2.Text = "";
                TM.txt_car3.Text = "";
                TM.txt_car4.Text = "";
                TM.txt_car5.Text = "";
                TM.txt_car6.Text = "";
                TM.txt_car8.Text = "";
                TM.txt_car7.Text = "";
                TM.txt_car9.Text = "";
                TM.txt_Type.Text = "";
                
                
            }
            
        }
        private void ajouterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Type_Materiel tm = new Type_Materiel();
            //Vide();
            tm.Btn_Ajouter.Enabled = true;
            tm.Btn_Modifier.Enabled = false;
            tm.Btn_Supprimer.Enabled = false;
           // TM.txt_Type.Enabled = true;
            //TM.txt_Type.Text = "";
            //TM.ShowDialog();           
            tm.ShowDialog();           
            Cmb_Type.SelectedIndex = -1;
            Btn_Search.PerformClick();
        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Type_Materiel tm = new Type_Materiel();
            tm =new Type_Materiel(DGV1.SelectedCells[1].Value.ToString());
            tm.Btn_Modifier.Enabled = true;
            tm.Btn_Ajouter.Enabled = false;
            tm.Btn_Supprimer.Enabled = false;
            //TM.txt_Type.Enabled = false;
            tm.ShowDialog();
            Cmb_Type.SelectedIndex = -1;
            Btn_Search.PerformClick();
        }

       

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
             
            if (MessageBox.Show("Voulez-vous supprimer ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                
               // DGV1.Rows.RemoveAt(DGV1.SelectedRows[0].Index);
                cnx.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM [TYPE_MATERIEL] WHERE [TYPE_MATERIEL] ='" + DGV1.SelectedCells[1].Value.ToString() + "'", cnx);
                cmd.ExecuteNonQuery();
                cnx.Close();
                MessageBox.Show("Données bien supprimer!", "Suppression", MessageBoxButtons.OK);
                Cmb_Type.SelectedIndex = -1;
                Btn_Search.PerformClick();
                //DGV1.DataSource = "";  
            }
       
        }

        //int ID = 0;
        
        //private void DGV1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    ID = Convert.ToInt32(DGV1.Rows[e.RowIndex].Cells[0].Value.ToString());  
        //}

        private void DGV1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    if (DGV1.Rows[e.RowIndex].Selected == true)
                    {
                        // DGV1.Rows[e.RowIndex].Selected = true;
                        // Index = e.RowIndex;
                        DGV1.CurrentCell = DGV1.Rows[e.RowIndex].Cells[0];
                        //contextMenuStrip1.Show(DGV1, e.Location);
                        contextMenuStrip1.Show(Cursor.Position);
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void nbr_TextChanged(object sender, EventArgs e)
        {

        }

        private void Cmb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void DGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
