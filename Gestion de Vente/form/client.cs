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
    public partial class client : UserControl
    {
        private static client pageclient;
        ajout_modif_client form_ajout_modif;
        loginForm log;
        public client()
        {
            InitializeComponent();
            form_ajout_modif = new ajout_modif_client(this, this);
            log = new loginForm();
        }
        
        public static client instance
        {
            get
            {
                if (pageclient == null)
                {
                    pageclient = new client();
                }
                return pageclient;
            }
        }
       
        //Affichage sur le DatagriedView
        public void affichage()
        {
            classe.classeclient.recherche_affiche("select * from client", dgvclient);

        }

        //Ajouter le nouveau client
        private void btnnouveau_Click(object sender, EventArgs e)
        {
            //form_ajout_modif.effacer();
            form_ajout_modif.vider();
            form_ajout_modif.autoID();
            form_ajout_modif.save();
            form_ajout_modif.ShowDialog();
        }

        private void client_Load(object sender, EventArgs e)
        {
            affichage();
        }

        //Recherche par nom du client
        private void txtnomcli_TextChange(object sender, EventArgs e)
        {
            classe.classeclient.recherche_affiche("SELECT * FROM client WHERE nom LIKE '" + txtnomcli.Text + "%'", dgvclient);
        }
         //Recherche par numéro du client
        private void txtnumcli_TextChange(object sender, EventArgs e)
        {
            if (txtnumcli.Text == "")
            {
                affichage();
            }
            else
            {
                classe.classeclient.recherche_affiche("SELECT * FROM client WHERE numcli LIKE '%" + txtnumcli.Text + "%'", dgvclient);
            }
        }

        //Recherche par ville
        private void txtville_TextChange(object sender, EventArgs e)
        {
            classe.classeclient.recherche_affiche("SELECT * FROM client WHERE ville LIKE '" + txtville.Text + "%'", dgvclient);
        }

        //Recherche par numéro de téléphone
        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            classe.classeclient.recherche_affiche("SELECT * FROM client WHERE telephone LIKE '%" + txtphone.Text + "%'", dgvclient);
        }

        //Modifier et supprimer sur le dataGridView
        private void dgvclient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form_ajout_modif.effacer();
                form_ajout_modif.numcli = dgvclient.Rows[e.RowIndex].Cells[2].Value.ToString();
                form_ajout_modif.nomcli = dgvclient.Rows[e.RowIndex].Cells[3].Value.ToString();
                form_ajout_modif.ville = dgvclient.Rows[e.RowIndex].Cells[4].Value.ToString();
                form_ajout_modif.phone = dgvclient.Rows[e.RowIndex].Cells[5].Value.ToString();
                form_ajout_modif.modifier();
                form_ajout_modif.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("La suppression du client supprimera touts ces commandes.\n\n Voulez-vous vraiment supprimer cet client ?", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    classe.classeclient.supprime_client(dgvclient.Rows[e.RowIndex].Cells[2].Value.ToString());
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

        //Télécharger facture
        private void btntelecharger_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Vous êtes sur le point de télécharger le fichier contenant la liste de toutes les clients.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (reponse == DialogResult.Yes)
            {
              classe.classeclient.pdfclient();
            }
        }
    }
}
