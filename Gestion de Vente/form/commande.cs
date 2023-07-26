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
    public partial class commande : UserControl
    {
        ajout_modif_commande form_ajout_modif;
        Dialogue dialogue;
        private static commande pagecommande;
        //creation d'un instanse pour le commande controle
        public static commande instance
        {
            get
            {
                if (pagecommande == null)
                {
                    pagecommande = new commande();
                }
                return pagecommande;
            }
        }
        public commande()
        {
            InitializeComponent();
            form_ajout_modif = new ajout_modif_commande(this, this);
            dialogue = new Dialogue();
        }

        //Affichage sur le DataGridView
        public void affichage()
        {
            classe.classecommande.recherche_affiche("select  commande.numcli,client.nom,produit.codepro, commande.libelle,commande.qte_com,produit.pu,(pu*qte_com) as montant,commande.date,commande.time from client,commande,produit where (commande.libelle=produit.libelle) and (client.numcli = commande.numcli)", dgvcommande,lblmontant);
           
        }

        private void commande_Load(object sender, EventArgs e)
        {
            affichage();
        }

        //Afficher la boite d'ajout
        private void btnnouveau_Click(object sender, EventArgs e)
        {
            form_ajout_modif.effacer();
            form_ajout_modif.save();
            form_ajout_modif.autoID();
            form_ajout_modif.ShowDialog();
        }

        //Click sur le datagridView
        private void dgvcommande_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                form_ajout_modif.effacer();
                form_ajout_modif.numcli = dgvcommande.Rows[e.RowIndex].Cells[2].Value.ToString();
                form_ajout_modif.libelle = dgvcommande.Rows[e.RowIndex].Cells[5].Value.ToString();
                form_ajout_modif.quantite = dgvcommande.Rows[e.RowIndex].Cells[6].Value.ToString();
                form_ajout_modif.qte_reel = dgvcommande.Rows[e.RowIndex].Cells[6].Value.ToString();
                form_ajout_modif.time_modif = dgvcommande.Rows[e.RowIndex].Cells[10].Value.ToString();
                form_ajout_modif.modifier();
              //  MessageBox.Show(dgvcommande.Rows[e.RowIndex].Cells[10].Value.ToString());
                form_ajout_modif.ShowDialog();
                return;
            }
            if (e.ColumnIndex == 1)
            {
                if (MessageBox.Show("Voulez-vous vraiment supprimer la commande du client " + dgvcommande.Rows[e.RowIndex].Cells[2].Value.ToString().ToUpper() + " ,du" + dgvcommande.Rows[e.RowIndex].Cells[9].Value.ToString() + " à" + dgvcommande.Rows[e.RowIndex].Cells[10].Value.ToString() + " ?", "Attention", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    classe.classecommande.supprime_commande(dgvcommande.Rows[e.RowIndex].Cells[10].Value.ToString());
                    affichage();
                    return;
                }
            }
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
                classe.classecommande.recherche_affiche("SELECT  commande.numcli,client.nom,produit.codepro, commande.libelle,commande.qte_com,produit.pu,(pu*qte_com) as montant,commande.date,commande.time from commande,produit,client where (commande.libelle=produit.libelle) and (client.numcli = commande.numcli) AND client.numcli like '%" + txtnumcli.Text + "%'", dgvcommande,lblmontant);
            }
        }

        //Recherche par nom du client
        private void txtnomcli_TextChange(object sender, EventArgs e)
        {
            
            classe.classecommande.recherche_affiche("SELECT  commande.numcli,client.nom,produit.codepro, commande.libelle,commande.qte_com,produit.pu,(pu*qte_com) as montant,commande.date,commande.time from commande,produit,client where (commande.libelle=produit.libelle) and (client.numcli = commande.numcli) and client.nom LIKE '%" + txtnomcli.Text + "%'", dgvcommande,lblmontant);
        }

        //Recherche entre deux dates
        private void btnrecherche_Click(object sender, EventArgs e)
        {
            string datenew = txtdatenew.Value.Date.ToString("yyyy/MM/dd");
            string dateold = txtdateold.Value.Date.ToString("yyyy/MM/dd");
            classe.classecommande.recherche_affiche("select  commande.numcli,client.nom,produit.codepro, commande.libelle,commande.qte_com,produit.pu,(pu*qte_com) as montant,commande.date,commande.time from client,commande,produit where (commande.libelle=produit.libelle) and (client.numcli = commande.numcli) and commande.date BETWEEN '"+dateold+"' AND '"+datenew+"'", dgvcommande,lblmontant);

        }

        private void btnfact_Click(object sender, EventArgs e)
        {
            dialogue.ShowDialog();

        }

        private void btnactualiser_Click(object sender, EventArgs e)
        {
            affichage();
        }
    }
}
