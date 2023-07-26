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
    public partial class produit : UserControl
    {
        private static produit pageproduit;
        ajout_modif_produit form_ajout_modif;
        public produit()
        {
            InitializeComponent();
            form_ajout_modif = new ajout_modif_produit(this, this);
        }

        //Creation d'une instance de classe du PRODUIT
        public static produit instance
        {
            get
            {
                if (pageproduit == null)
                {
                    pageproduit = new produit();
                }
                return pageproduit;
            }
        }

        //Foncion affichage
        public void affichage()
        {
            classe.classeproduit.recherche_affiche("select * from produit", dgvproduit);

        }

        //Affichage du boite de dialogue ajout_modif_produit
        private void btnnouveau_Click(object sender, EventArgs e)
        {
            form_ajout_modif.vider();
            form_ajout_modif.autoID();
            form_ajout_modif.save();
            form_ajout_modif.ShowDialog();
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

        //Modification d-un produit
        private void dgvproduit_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //form_ajout_modif.effacer();
                form_ajout_modif.numpro = dgvproduit.Rows[e.RowIndex].Cells[2].Value.ToString();
                form_ajout_modif.libelle = dgvproduit.Rows[e.RowIndex].Cells[3].Value.ToString();
                form_ajout_modif.pu = dgvproduit.Rows[e.RowIndex].Cells[4].Value.ToString();
                form_ajout_modif.stock = dgvproduit.Rows[e.RowIndex].Cells[5].Value.ToString();
                form_ajout_modif.modifier();
                form_ajout_modif.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("La suppression du client supprimera touts ces commandes.\n\n Voulez-vous vraiment supprimer cet client ?", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    classe.classeproduit.supprime_produit(dgvproduit.Rows[e.RowIndex].Cells[3].Value.ToString());
                    affichage();
                    return;
                }
            }
        }

        private void produit_Load(object sender, EventArgs e)
        {
            affichage();
        }

        //Actualiser
        private void btnactualiser_Click(object sender, EventArgs e)
        {
            affichage();
        }


        //Télécharger pdf
        private void btntelecharger_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Vous êtes sur le point de télécharger le fichier contenant la liste de toutes les produits.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (reponse == DialogResult.Yes)
            {
                classe.classeproduit.pdfproduit();
            }
        }
    }
}
