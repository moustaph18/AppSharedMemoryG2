using ApplicationSharedMemory.Model;
using ApplicationSharedMemory.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationSharedMemory
{
    public partial class frmCategoriePhp : Form
    {
        SqlClientLogger logger;
        public frmCategoriePhp()
        {
            InitializeComponent();
        }
       
        CategorieServicesPhp categorieService = new CategorieServicesPhp();
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void effacer()
        {
            textCodeCategorie2.Text = string.Empty;
            textLibelle2.Text = string.Empty;
            dgCategorie2.DataSource = categorieService.servGetListeCategorie();
            textCodeCategorie2.Focus();
        }
        private void btnAjout_Click(object sender, EventArgs e)
        {

            CategorieApiPhp categorie = new CategorieApiPhp();
            categorie.CodeCategorie = textCodeCategorie2.Text;
            categorie.LibelleCategorie = textLibelle2.Text;
            categorieService.AddCategorie(categorie);
            effacer();
        }

        private void textLibelle_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            textCodeCategorie2.Text = dgCategorie2.CurrentRow.Cells[1].Value.ToString();
            textLibelle2.Text = dgCategorie2.CurrentRow.Cells[2].Value.ToString();
            btnAjout2.Enabled = false;

        }

        private void textCodeCategorie_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgCategorie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmCategoriePhp_Load(object sender, EventArgs e)
        {
            dgCategorie2.DataSource = categorieService.servGetListeCategorie();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgCategorie2.CurrentRow.Cells[0].Value.ToString());
            categorieService.DeleteCategorie(id);
            effacer();
            btnAjout2.Enabled = true;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgCategorie2.CurrentRow.Cells[0].Value.ToString());
            CategorieApiPhp categorie =  categorieService.GetCategorieById(id);
            categorie.idCategorie = id;
            categorie.CodeCategorie = textCodeCategorie2.Text;
            categorie.LibelleCategorie = textLibelle2.Text;
            categorieService.UpdateCategorie(categorie);
            effacer();
            btnAjout2.Enabled = true;

        }

        private void actionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
