using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Vente.form
{
    public partial class produituser : UserControl
    {
        private static produituser pageproduit;
        public produituser()
        {
            InitializeComponent();
        }

        //Creation d'une instance de classe du PRODUIT
        public static produituser instance
        {
            get
            {
                if (pageproduit == null)
                {
                    pageproduit = new produituser();
                }
                return pageproduit;
            }
        }

        public void affichage()
        {
            classe.classeproduit.recherche_affiche("select * from produit", dgvproduit);

        }


        //Recherche par codepro
        private void txtcodepro_TextChange(object sender, EventArgs e)
        {
            if (txtcodepro.Text == "")
            {
                affichage();
            }
            else
            {
                classe.classeproduit.recherche_affiche("SELECT * FROM produit WHERE codepro LIKE '%" + txtcodepro.Text + "%'", dgvproduit);
            }
        }
        //Recherche par libellé
        private void txtlibelle_TextChange(object sender, EventArgs e)
        {
            classe.classeproduit.recherche_affiche("SELECT * FROM produit WHERE libelle LIKE '%" + txtlibelle.Text + "%'", dgvproduit);
        }

        //Recherche par quantité
        private void txtquantite_TextChange(object sender, EventArgs e)
        {
            classe.classeproduit.recherche_affiche("SELECT * FROM produit WHERE quantite LIKE '%" + txtquantite.Text + "%'", dgvproduit);
        }

        //Saisir que des chiffres sur la quantité
        private void txtquantite_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }


        private void produit_Load(object sender, EventArgs e)
        {
            affichage();
        }

        private void btnactualiser_Click(object sender, EventArgs e)
        {
            affichage();
        }
    }
}
