using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationSharedMemory.Model;
using ApplicationSharedMemory.Service;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ApplicationSharedMemory
{
    public partial class frmCategorie : Form
    {
        public frmCategorie()
        {
            InitializeComponent();
        }

        CategorieService categorieService = new CategorieService();

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            Categorie categorie = new Categorie();
            categorie.CodeCategorie = textCodeCategorie.Text;
            categorie.LibelleCategorie = textLibelle.Text;
            categorieService.AddCategorie(categorie);
            effacer();
        }

        private void frmCategorie_Load(object sender, EventArgs e)
        {
            dgCategorie.DataSource = categorieService.servGetListeCategorie();
        }

        private void effacer()
        {
            textCodeCategorie.Text = string.Empty;
            textLibelle.Text = string.Empty;
            dgCategorie.DataSource = categorieService.servGetListeCategorie();
            textCodeCategorie.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textCodeCategorie.Text = dgCategorie.CurrentRow.Cells[1].Value.ToString();
            textLibelle.Text = dgCategorie.CurrentRow.Cells[2].Value.ToString();
            btnAjout.Enabled = false;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgCategorie.CurrentRow.Cells[0].Value.ToString()); 
            categorieService.DeleteCategorie(id);
            effacer();
            btnAjout.Enabled=true;
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgCategorie.CurrentRow.Cells[0].Value.ToString());
            Categorie categorie = categorieService.GetCategorieById(id);
            MessageBox.Show(categorie.idCategorie.ToString());
            categorie.idCategorie = id;
            categorie.CodeCategorie = textCodeCategorie.Text;
            categorie.LibelleCategorie = textLibelle.Text;

            categorieService.UpdateCategorie(categorie);

            effacer();
            btnAjout.Enabled = true;
        }

        private void dgCategorie_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
