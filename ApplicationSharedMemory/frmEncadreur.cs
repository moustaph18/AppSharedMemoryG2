using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace ApplicationSharedMemory
{
    public partial class frmEncadreur : Form
    {
        ServiceReference1.Service1Client service;
        public frmEncadreur()
        {
            InitializeComponent();
            service = new ServiceReference1.Service1Client();
        }

        private void fermer()
        {
            Form[] charr = this.MdiChildren;

            //For each child form set the window state to Maximized 
            foreach (Form chform in charr)
            {
                //chform.WindowState = FormWindowState.Maximized;
                chform.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dgEncadreur.DataSource = service.ListEncadreur();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgEncadreur_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjout_Click(object sender, EventArgs e)
        {
            ServiceReference1.Encadreur encadreur = new ServiceReference1.Encadreur();
            encadreur.Prenom = txtPrenom.Text;
            encadreur.Nom = txtNom.Text;
            encadreur.Specialite = txtSpecialite.Text;
            service.AjoutEncadreur(encadreur);
            effacer();
            
        }
       
        /// <summary>
        /// 
        /// </summary>
        private void effacer()
        {
            txtPrenom.Text = String.Empty;
            txtNom.Text = String.Empty;
            txtSpecialite.Text = String.Empty;
            dgEncadreur.DataSource = service.ListEncadreur();
            txtPrenom.Focus();
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            txtPrenom.Text = dgEncadreur.CurrentRow.Cells[3].Value.ToString();
            txtNom.Text = dgEncadreur.CurrentRow.Cells[2].Value.ToString();
            txtSpecialite.Text = dgEncadreur.CurrentRow.Cells[0].Value.ToString();
            btnAjout.Enabled = false;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgEncadreur.CurrentRow.Cells[1].Value.ToString());
            service.SupprimerEncadreur(id);
            effacer();
            btnAjout.Enabled = true;
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgEncadreur.CurrentRow.Cells[1].Value.ToString());
            ServiceReference1.Encadreur encadreur = new ServiceReference1.Encadreur();
            encadreur = service.encadreurById(id);
            encadreur.Prenom = txtPrenom.Text;
            encadreur.Nom = txtNom.Text;
            encadreur.Specialite = txtSpecialite.Text;

            service.ModifierEncadreur(encadreur);
            effacer();
            btnAjout.Enabled = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRecherche.Text))
            {
                dgEncadreur.DataSource = service.ListEncadreur();
            }
            else
            {
                dgEncadreur.DataSource = service.ListEncadreurs(txtRecherche.Text);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
