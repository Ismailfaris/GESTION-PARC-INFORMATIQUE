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
    public partial class Modele : Form
    {
        SqlConnection cnx = new SqlConnection("Data Source=(local);Initial Catalog=Materiel;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public Modele()
        {
            InitializeComponent();
        }
        string type_value = "";

        public Modele(string type)
        {
            InitializeComponent();
            type_value=type;
            remplir_champs();
        }
        void remplir_champs() 
        {
            cnx.Open();
            cmd = new SqlCommand("SELECT * FROM [modele] where Type='" + type_value + "'", cnx);
            dr = cmd.ExecuteReader();
            // dt.Load(dr);

            while (dr.Read())
            {
                cmb_typeM.SelectedItem = dr[1].ToString();
                
                // txt_cree.Text = dr[11].ToString();
                // txt_d1.Text = dr[12].ToString();
                //// txt_mod.Text = dr[13].ToString();
                // txt_d2.Text = dr[14].ToString();
            }
            //txt_Type.Enabled = false;
            //dr.Close();
            cnx.Close();
        }
        private void Modele_Load(object sender, EventArgs e)
        {

            da = new SqlDataAdapter("SELECT DISTINCT [TYPE_MATERIEL]FROM [TYPE_MATERIEL]", cnx);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cmb_typeM.Items.Add(dr["TYPE_MATERIEL"].ToString());
            }
            DataTable dtt = new DataTable();
            da = new SqlDataAdapter("SELECT [Marque]FROM [Marque]", cnx);
            da.Fill(dtt);
            foreach (DataRow dr in dtt.Rows)
            {
                cmb_marqueM.Items.Add(dr["Marque"].ToString());
            }
            txt_cre.Text = globals.username;
            txt_modi.Text = globals.username;
            txt_dat.Text = DateTime.Now.ToString();
            txt_dat_modi.Text = DateTime.Now.ToString();
        }

        private void cmb_typeM_SelectedIndexChanged(object sender, EventArgs e)
        {
            cnx.Open();
            try
            {

                cmd = new SqlCommand("SELECT  [ID_modele],[Type],[Marque],[Modele],[caractéristique1],[caractéristique2],[caractéristique3],[caractéristique4],[caractéristique5],[caractéristique6],[caractéristique7],[caractéristique8],[caractéristique9],[Creer_par],[Date_de_creation],[Modifier_par],[Data_de_modification]FROM [modele] where Type='" + cmb_typeM.SelectedItem.ToString() + "'", cnx);

                dr = cmd.ExecuteReader();
                dr.Read();

                txt_modele.Text = dr["Modele"].ToString();
                txt_c1.Text = dr["caractéristique1"].ToString();
                txt_c2.Text = dr["caractéristique2"].ToString();
                txt_c3.Text = dr["caractéristique3"].ToString();
                txt_c4.Text = dr["caractéristique4"].ToString();
                txt_c5.Text = dr["caractéristique5"].ToString();
                txt_c6.Text = dr["caractéristique6"].ToString();
                txt_c7.Text = dr["caractéristique7"].ToString();
                txt_c8.Text = dr["caractéristique8"].ToString();
                txt_c9.Text = dr["caractéristique9"].ToString();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnx.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmb_marqueM.Text == "" && cmb_typeM.Text=="")
                {
                    MessageBox.Show("Le champ Type ou marque et vide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cnx.Open();

                    cmd = new SqlCommand("INSERT INTO [modele]([Type],[Marque],[Modele],[caractéristique1],[caractéristique2],[caractéristique3],[caractéristique4],[caractéristique5],[caractéristique6],[caractéristique7],[caractéristique8],[caractéristique9],[Creer_par],[Date_de_creation],[Modifier_par],[Data_de_modification])VALUES ('" + cmb_typeM.SelectedItem + "','" + cmb_marqueM.SelectedItem + "','" + txt_modele.Text + "','" + txt_c1.Text + "','" + txt_c2.Text + "','" + txt_c3.Text + "','" + txt_c4.Text + "','" + txt_c5.Text + "','" + txt_c6.Text + "','" + txt_c7.Text + "','" + txt_c8.Text + "','" + txt_c9.Text + "','" + globals.username + "','" + DateTime.Now + "','" + globals.username + "','" + DateTime.Now + "')", cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajouté avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cnx.Close();
                    vide();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        void vide()
        {
            
            txt_c1.Text = "";
            txt_c2.Text = "";
            txt_c3.Text = "";
            txt_c4.Text = "";
            txt_c5.Text = "";
            txt_c6.Text = "";
            txt_c7.Text = "";
            txt_c8.Text = "";
            txt_c9.Text = "";
            txt_cre.Text = "";
            txt_dat.Text = "";
            txt_dat_modi.Text = "";
            txt_modi.Text = "";
            txt_modele.Text = "";
        

        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {

            vide();
        }

        private void Btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                if (cmb_typeM.Text == "" && cmb_marqueM.Text=="")
                {
                    MessageBox.Show("Veuillez Remplire  le champ type et marque", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE [modele]SET [Modele] = '" + txt_modele.Text + "',[caractéristique1] = '" + txt_c1.Text + "',[caractéristique2] = '" + txt_c2.Text + "',[caractéristique3] = '" + txt_c3.Text + "',[caractéristique4] = '" + txt_c4.Text + "',[caractéristique5] = '" + txt_c5.Text + "',[caractéristique6] = '" + txt_c6.Text + "',[caractéristique7] = '" + txt_c7.Text + "',[caractéristique8] = '" + txt_c8.Text + "',[caractéristique9] = '" + txt_c9.Text + "',[Creer_par] = '" + txt_cre.Text + "',[Date_de_creation] = '" + txt_dat.Text + "',[Modifier_par] = '" + txt_modi.Text + "',[Data_de_modification] = '" + txt_dat_modi.Text + "' Where [Type]='" + cmb_typeM.SelectedValue + "'and [Marque]='" + cmb_marqueM.SelectedValue + "'", cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modifié avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    vide();
                }

                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_marqueM_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
