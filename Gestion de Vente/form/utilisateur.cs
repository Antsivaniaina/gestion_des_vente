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
    public partial class utilisateur : UserControl
    {
        private static utilisateur pageuser;
        public utilisateur()
        {
            InitializeComponent();
        }
        public static utilisateur instance
        {
            get
            {
                if (pageuser == null)
                {
                    pageuser = new utilisateur();
                }
                return pageuser;
            }
        }
        // fonction affichage
        public void affichage()
        {
            classe.classeuser.recherche_affiche("SELECT * from utilisateur", dgvuser);
        }

        private void utilisateur_Load(object sender, EventArgs e)
        {
            affichage();
        }

        //Recherche par id user
        private void txtnumcli_TextChange(object sender, EventArgs e)
        {
            classe.classeuser.recherche_affiche("SELECT * from utilisateur where iduser like'%"+txtnumcli.Text+"%'", dgvuser);
        }

        //Recherche par nom d'utilisateur
        private void txtnomcli_TextChange(object sender, EventArgs e)
        {
            classe.classeuser.recherche_affiche("SELECT * from utilisateur where nom like'" + txtnomcli.Text + "%'", dgvuser);
        }

        //Recherche par mail
        private void txtville_TextChange(object sender, EventArgs e)
        {
            classe.classeuser.recherche_affiche("SELECT * from utilisateur where mail like'" + txtville.Text + "%'", dgvuser);
        }

        //Supprimer utilisateur
        private void dgvuser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if (MessageBox.Show("J'éspère que vous êtes vraiment l'administrateur.\n\n Voulez-vous vraiment supprimer cet utilisateur ?", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    classe.classeuser.supprime_user(dgvuser.Rows[e.RowIndex].Cells[1].Value.ToString());
                    affichage();
                    return;
                }
            }
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
                classe.classeuser.pdfuser();
            }
        }
    }
}
