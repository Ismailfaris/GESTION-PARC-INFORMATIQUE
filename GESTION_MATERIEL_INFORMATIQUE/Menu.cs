using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GESTION_MATERIEL_INFORMATIQUE
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Identificationn idn = new Identificationn();
            idn.ShowDialog();

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type_Materiel TM = new Type_Materiel();
            TM.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulation_Type_Materiel CTM = new Consulation_Type_Materiel();
            CTM.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Marque m = new Marque();
            m.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Modele me = new Modele();
            me.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultation_Modele cm = new Consultation_Modele();
            cm.ShowDialog();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            labelControl2.Text = globals.username;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
