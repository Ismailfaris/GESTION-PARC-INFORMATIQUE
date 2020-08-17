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
    public partial class Menu1 : Form
    {
        public Menu1()
        {
            InitializeComponent();
            //type_Materiele1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Type_Materiel TM = new Type_Materiel();
            TM.StartPosition = FormStartPosition.Manual;
            TM.Left = 210;
            TM.Top = 100;
            TM.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulation_Type_Materiel CTM = new Consulation_Type_Materiel();
            CTM.StartPosition = FormStartPosition.Manual;
            CTM.Left = 210;
            CTM.Top = 100;
            CTM.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Marque m = new Marque();
            m.StartPosition = FormStartPosition.Manual;
            m.Left = 210;
            m.Top = 100;
            m.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Modele me = new Modele();
            me.StartPosition = FormStartPosition.Manual;
            me.Left = 210;
            me.Top = 100;
            me.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Consultation_Modele cm = new Consultation_Modele();
            cm.StartPosition = FormStartPosition.Manual;
            cm.Left = 210;
            cm.Top = 100;
            cm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            Authentification aa = new Authentification();
            aa.ShowDialog();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void Menu1_Load(object sender, EventArgs e)
        {
            labelControl2.Text = globals.username;
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // type_Materiele1.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           // consultation_TypeMateriel1.BringToFront();
        }
    }
}
