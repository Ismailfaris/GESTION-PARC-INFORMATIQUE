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
    public partial class Type_Materiel : Form
    {
        SqlConnection cnx = new SqlConnection("Data Source=(local);Initial Catalog=Materiel;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();
        public Type_Materiel()
        {
            InitializeComponent();
        }
        string type_value = "";

        public Type_Materiel(string type)
        {
            InitializeComponent();
            type_value=type;
            remplir_champs();
        }

        public void remplir_champs()
        {
            cnx.Open();
            cmd = new SqlCommand("SELECT [TYPE_MATERIEL],[caracteristique1],[caracteristique2],[caracteristique3],[caracteristique4],[caracteristique5],[caracteristique6],[caracteristique7],[caracteristique8],[caracteristique9],[Cree_Par],[Date_Creation],[Modifier_Par],[Date_Modification]FROM TYPE_MATERIEL where [TYPE_MATERIEL]='" + type_value + "'", cnx);
            dr=cmd.ExecuteReader();
           // dt.Load(dr);

            while (dr.Read()) 
            {
                txt_Type.Text = dr[0].ToString();
                txt_car1.Text = dr[1].ToString();
                txt_car2.Text = dr[2].ToString();
                txt_car3.Text = dr[3].ToString();
                txt_car4.Text = dr[4].ToString();
                txt_car5.Text = dr[5].ToString();
                txt_car6.Text = dr[6].ToString();
                txt_car7.Text = dr[7].ToString();
                txt_car8.Text = dr[8].ToString();
                txt_car9.Text = dr[9].ToString();
               // txt_cree.Text = dr[11].ToString();
               // txt_d1.Text = dr[12].ToString();
               //// txt_mod.Text = dr[13].ToString();
               // txt_d2.Text = dr[14].ToString();
            }
            txt_Type.Enabled = false;
            //dr.Close();
            cnx.Close();
        }
        private void Type_Materiel_Load(object sender, EventArgs e)
        {
           // remplir_champs();
            //////txt_Type.Text = globals.iid;
            //txt_cree.Text = globals.username;
            //txt_mod.Text = globals.username;
        }
        
       
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            try
            {
                cnx.Open();
                if (txt_Type.Text == "")
                {
                    MessageBox.Show("Le champ Type et vide", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmd = new SqlCommand("INSERT INTO [dbo].[TYPE_MATERIEL]([TYPE_MATERIEL],[caracteristique1],[caracteristique2],[caracteristique3],[caracteristique4],[caracteristique5],[caracteristique6],[caracteristique7],[caracteristique8],[caracteristique9],[Cree_Par],[Date_Creation])VALUES('" + txt_Type.Text + "','" + txt_car1.Text + "','" + txt_car2.Text + "','" + txt_car3.Text + "','" + txt_car4.Text + "','" + txt_car5.Text + "','" + txt_car6.Text + "','" + txt_car7.Text + "','" + txt_car8.Text + "','" + txt_car9.Text + "','" + globals.username + "','" + DateTime.Now + "')", cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Ajouté avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Vide();
                }
                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Vide()
        {
            //txt_d2.Text = "";
            //txt_d1.Text = "";
            txt_car1.Text = "";
            txt_car2.Text = "";
            txt_car3.Text = "";
            txt_car4.Text = "";
            txt_car5.Text = "";
            txt_car6.Text = "";
            txt_car8.Text = "";
            txt_car7.Text = "";
            txt_car9.Text = "";
            txt_Type.Text = "";
            //txt_mod.Text = "";
            //txt_cree.Text = "";
        }
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            Vide();
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                  cnx.Open();
                if (txt_Type.Text=="")
                {
                    MessageBox.Show("Veuillez Remplire tous les champs", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmd = new SqlCommand("update TYPE_MATERIEL set caracteristique1 = '" + txt_car1.Text + "',caracteristique2 ='" + txt_car2.Text + "',caracteristique3='" + txt_car3.Text + "',caracteristique4 ='" + txt_car4.Text + "',caracteristique5='" + txt_car5.Text + "',caracteristique6='" + txt_car6.Text + "',caracteristique7='" + txt_car7.Text + "',caracteristique8='" + txt_car8.Text + "',caracteristique9='" + txt_car9.Text + "',Cree_Par='" + globals.username + "',Date_Creation='" + DateTime.Now + "' where TYPE_MATERIEL ='" + txt_Type.Text + "'", cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Modifié avec succes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Vide();
                }
            
                cnx.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            try
            {
                cnx.Open();
                if (txt_Type.Text == "")
                {
                    MessageBox.Show("Veuillez Remplir Le Champs Type Materiel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    cmd = new SqlCommand("delete from TYPE_MATERIEL where TYPE_MATERIEL ='" + txt_Type.Text + "'", cnx);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Supprimer avec succès", "Supprimer", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Vide();

                }

                cnx.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }
    }
}
