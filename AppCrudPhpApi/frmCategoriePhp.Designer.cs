namespace ApplicationSharedMemory
{
    partial class frmCategoriePhp
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
            this.btnSelectionner2 = new System.Windows.Forms.Button();
            this.btnAjout2 = new System.Windows.Forms.Button();
            this.textLibelle2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textCodeCategorie2 = new System.Windows.Forms.TextBox();
            this.dgCategorie2 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgCategorie2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectionner2
            // 
            this.btnSelectionner2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectionner2.Location = new System.Drawing.Point(152, 48);
            this.btnSelectionner2.Name = "btnSelectionner2";
            this.btnSelectionner2.Size = new System.Drawing.Size(113, 30);
            this.btnSelectionner2.TabIndex = 12;
            this.btnSelectionner2.Text = "Selectionner";
            this.btnSelectionner2.UseVisualStyleBackColor = true;
            this.btnSelectionner2.Click += new System.EventHandler(this.btnSelectionner_Click);
            // 
            // btnAjout2
            // 
            this.btnAjout2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjout2.Location = new System.Drawing.Point(189, 311);
            this.btnAjout2.Name = "btnAjout2";
            this.btnAjout2.Size = new System.Drawing.Size(75, 30);
            this.btnAjout2.TabIndex = 11;
            this.btnAjout2.Text = "Ajouter";
            this.btnAjout2.UseVisualStyleBackColor = true;
            this.btnAjout2.Click += new System.EventHandler(this.btnAjout_Click);
            // 
            // textLibelle2
            // 
            this.textLibelle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textLibelle2.Location = new System.Drawing.Point(12, 243);
            this.textLibelle2.Multiline = true;
            this.textLibelle2.Name = "textLibelle2";
            this.textLibelle2.Size = new System.Drawing.Size(253, 27);
            this.textLibelle2.TabIndex = 10;
            this.textLibelle2.TextChanged += new System.EventHandler(this.textLibelle_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "CodeCategorie";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textCodeCategorie2
            // 
            this.textCodeCategorie2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCodeCategorie2.Location = new System.Drawing.Point(11, 140);
            this.textCodeCategorie2.Multiline = true;
            this.textCodeCategorie2.Name = "textCodeCategorie2";
            this.textCodeCategorie2.Size = new System.Drawing.Size(253, 26);
            this.textCodeCategorie2.TabIndex = 8;
            this.textCodeCategorie2.TextChanged += new System.EventHandler(this.textCodeCategorie_TextChanged);
            // 
            // dgCategorie2
            // 
            this.dgCategorie2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCategorie2.Location = new System.Drawing.Point(284, 48);
            this.dgCategorie2.Name = "dgCategorie2";
            this.dgCategorie2.RowHeadersWidth = 45;
            this.dgCategorie2.Size = new System.Drawing.Size(509, 390);
            this.dgCategorie2.TabIndex = 7;
            this.dgCategorie2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgCategorie_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "LibelleCategorie";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimer.Location = new System.Drawing.Point(169, 362);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(96, 30);
            this.btnSupprimer.TabIndex = 14;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.86792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifier.Location = new System.Drawing.Point(169, 407);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(96, 30);
            this.btnModifier.TabIndex = 15;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(800, 27);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitterToolStripMenuItem});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.actionToolStripMenuItem.Text = "Action";
            this.actionToolStripMenuItem.Click += new System.EventHandler(this.actionToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // frmCategoriePhp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSelectionner2);
            this.Controls.Add(this.btnAjout2);
            this.Controls.Add(this.textLibelle2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textCodeCategorie2);
            this.Controls.Add(this.dgCategorie2);
            this.Name = "frmCategoriePhp";
            this.Text = "frmCategoriePhp";
            this.Load += new System.EventHandler(this.frmCategoriePhp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgCategorie2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectionner2;
        private System.Windows.Forms.Button btnAjout2;
        private System.Windows.Forms.TextBox textLibelle2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textCodeCategorie2;
        private System.Windows.Forms.DataGridView dgCategorie2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
    }
}