namespace GESTION_MATERIEL_INFORMATIQUE
{
    partial class Marque
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Marque));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.Btn_Annuler = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Modifier = new DevExpress.XtraEditors.SimpleButton();
            this.txt_marque = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.Btn_Crée = new DevExpress.XtraEditors.SimpleButton();
            this.DGV2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_marque.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.Btn_Annuler);
            this.groupControl1.Controls.Add(this.Btn_Delete);
            this.groupControl1.Controls.Add(this.Btn_Modifier);
            this.groupControl1.Controls.Add(this.txt_marque);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.Btn_Crée);
            this.groupControl1.Location = new System.Drawing.Point(19, 15);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1721, 183);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "Marque";
            // 
            // Btn_Annuler
            // 
            this.Btn_Annuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Annuler.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Annuler.Image")));
            this.Btn_Annuler.Location = new System.Drawing.Point(1477, 94);
            this.Btn_Annuler.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Annuler.Name = "Btn_Annuler";
            this.Btn_Annuler.Size = new System.Drawing.Size(237, 57);
            this.Btn_Annuler.TabIndex = 15;
            this.Btn_Annuler.Text = "Annuler";
            this.Btn_Annuler.Click += new System.EventHandler(this.Btn_Annuler_Click);
            // 
            // Btn_Delete
            // 
            this.Btn_Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Delete.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Delete.Image")));
            this.Btn_Delete.Location = new System.Drawing.Point(1477, 30);
            this.Btn_Delete.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Delete.Name = "Btn_Delete";
            this.Btn_Delete.Size = new System.Drawing.Size(237, 57);
            this.Btn_Delete.TabIndex = 14;
            this.Btn_Delete.Text = "Supprimer";
            this.Btn_Delete.Click += new System.EventHandler(this.Btn_Delete_Click);
            // 
            // Btn_Modifier
            // 
            this.Btn_Modifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Modifier.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Modifier.Image")));
            this.Btn_Modifier.Location = new System.Drawing.Point(1232, 94);
            this.Btn_Modifier.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Modifier.Name = "Btn_Modifier";
            this.Btn_Modifier.Size = new System.Drawing.Size(237, 57);
            this.Btn_Modifier.TabIndex = 13;
            this.Btn_Modifier.Text = "Modifier";
            this.Btn_Modifier.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // txt_marque
            // 
            this.txt_marque.Location = new System.Drawing.Point(93, 81);
            this.txt_marque.Margin = new System.Windows.Forms.Padding(4);
            this.txt_marque.Name = "txt_marque";
            this.txt_marque.Size = new System.Drawing.Size(133, 22);
            this.txt_marque.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Marque :";
            // 
            // Btn_Crée
            // 
            this.Btn_Crée.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_Crée.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Crée.Image")));
            this.Btn_Crée.Location = new System.Drawing.Point(1232, 30);
            this.Btn_Crée.Margin = new System.Windows.Forms.Padding(4);
            this.Btn_Crée.Name = "Btn_Crée";
            this.Btn_Crée.Size = new System.Drawing.Size(237, 57);
            this.Btn_Crée.TabIndex = 9;
            this.Btn_Crée.Text = "Creer";
            this.Btn_Crée.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // DGV2
            // 
            this.DGV2.AllowUserToAddRows = false;
            this.DGV2.AllowUserToDeleteRows = false;
            this.DGV2.AllowUserToResizeColumns = false;
            this.DGV2.AllowUserToResizeRows = false;
            this.DGV2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV2.Location = new System.Drawing.Point(19, 206);
            this.DGV2.Margin = new System.Windows.Forms.Padding(4);
            this.DGV2.MultiSelect = false;
            this.DGV2.Name = "DGV2";
            this.DGV2.ReadOnly = true;
            this.DGV2.RowHeadersWidth = 40;
            this.DGV2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV2.Size = new System.Drawing.Size(1721, 844);
            this.DGV2.TabIndex = 12;
            this.DGV2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV2_CellContentClick);
            // 
            // Marque
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1756, 1055);
            this.Controls.Add(this.DGV2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Marque";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Marque";
            this.Load += new System.EventHandler(this.Marque2_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_marque.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Annuler;
        private DevExpress.XtraEditors.SimpleButton Btn_Delete;
        private DevExpress.XtraEditors.SimpleButton Btn_Modifier;
        private DevExpress.XtraEditors.TextEdit txt_marque;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton Btn_Crée;
        public System.Windows.Forms.DataGridView DGV2;
    }
}