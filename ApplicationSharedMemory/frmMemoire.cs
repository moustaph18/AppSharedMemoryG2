using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationSharedMemory
{
    public partial class frmMemoire : Form
    {
        ServiceReference1.Service1Client service;
        public frmMemoire()
        {
            InitializeComponent();
            service = new ServiceReference1.Service1Client();
        }

        private void txtRecherche_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgMemoire_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecherche.Text))
            {
                dgMemoire.DataSource = service.ListMemoires();
            }
            else
            {
                dgMemoire.DataSource = service.ListMemorieParCh(txtRecherche.Text);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void effacer()
        {
            txtSujet.Text = String.Empty;
            txtFilename.Text = String.Empty;
            txtAnnee.Text = String.Empty;
            dgMemoire.DataSource = service.ListMemoires();
            cmbEncadreur.DataSource = service.ChargementComboBox();
            cmbEncadreur.ValueMember = "Value";
            cmbEncadreur.DisplayMember = "Text";
            txtSujet.Focus();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMemoire_Load(object sender, EventArgs e)
        {

            dgMemoire.DataSource = service.ListMemoires();
            cmbEncadreur.DataSource = service.ChargementComboBox();
            cmbEncadreur.ValueMember = "Value";
            cmbEncadreur.DisplayMember = "Text";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAjout1_Click(object sender, EventArgs e)
        {
            ServiceReference1.Memoire memoire = new ServiceReference1.Memoire();
            memoire.Sujet = txtSujet.Text;
            memoire.FileName = txtFilename.Text;
            memoire.Annee = int.Parse(txtAnnee.Text);

           // memoire.encadreur = new ServiceReference1.Encadreur();
           memoire.IdEncadreur = int.Parse(cmbEncadreur.SelectedValue.ToString());
            //memoire.IdEncadreur = int.Parse(cmbEncadreur.SelectedValue.ToString());

            // memoire.encadreur = cmbEncadreur.SelectedText.ToString(); 
            MessageBox.Show($"Sujet: {memoire.Sujet}\n" +
                               $"FileName: {memoire.FileName}\n" +
                               $"Année: {memoire.Annee}\n" +
                               $"Encadreur ID: {memoire.IdEncadreur}");
            service.AjoutMemoire(memoire);
            effacer();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            btnAjout1.Enabled = false;
            txtSujet.Text = dgMemoire.CurrentRow.Cells[4].Value.ToString();
            txtFilename.Text = dgMemoire.CurrentRow.Cells[1].Value.ToString();
            txtAnnee.Text = dgMemoire.CurrentRow.Cells[0].Value.ToString();
            cmbEncadreur.SelectedValue = dgMemoire.CurrentRow.Cells[2].Value.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier2_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMemoire.CurrentRow.Cells[3].Value.ToString());
            ServiceReference1.Memoire memoire = new ServiceReference1.Memoire();

            memoire = service.MemoireById(id);
            memoire.Sujet = txtSujet.Text;
            memoire.FileName = txtFilename.Text;
            memoire.Annee = int.Parse(txtAnnee.Text);
            memoire.IdEncadreur = int.Parse(cmbEncadreur.SelectedValue.ToString());

            service.ModifierMemoire(memoire);
            effacer();
            btnAjout1.Enabled = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer2_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgMemoire.CurrentRow.Cells[3].Value.ToString());
            service.SupprimerMemoire(id);

            effacer();
            btnAjout1.Enabled = true;
            
        }
    }
}
