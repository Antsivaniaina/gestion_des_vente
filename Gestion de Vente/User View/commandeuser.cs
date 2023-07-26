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
    public partial class commandeuser : UserControl
    {

        Dialogue dialogue;
        private static commandeuser pagecommande;
        //creation d'un instanse pour le commande controle
        public static commandeuser instance
        {
            get
            {
                if (pagecommande == null)
                {
                    pagecommande = new commandeuser();
                }
                return pagecommande;
            }
        }
        public commandeuser()
        {
            InitializeComponent();
            dialogue = new Dialogue();
        }

        //Affichage sur le DataGridView
        public void affichage()
        {
            classe.classecommande.recherche_affiche("select  commande.numcli,client.nom,produit.codepro, commande.libelle,commande.qte_com,produit.pu,(pu*qte_com) as montant,commande.date,commande.time from client,commande,produit where (commande.libelle=produit.libelle) and (client.numcli = commande.numcli)", dgvcommande, lblmontant);

        }

        private void commande_Load(object sender, EventArgs e)
        {
            affichage();
        }

        //Afficher la boite d'ajout




        //Recherche par numéro du client
        private void txtnumcli_TextChange(object sender, EventArgs e)
        {
            if (txtnumcli.Text == "")
            {
                affichage();
            }
            else
            {
                classe.classecommande.recherche_affiche("SELECT  commande.numcli,client.nom,produit.codepro, commande.libelle,commande.qte_com,produit.pu,(pu*qte_com) as montant,commande.date,commande.time from commande,produit,client where (commande.libelle=produit.libelle) and (client.numcli = commande.numcli) AND client.numcli like '%" + txtnumcli.Text + "%'", dgvcommande, lblmontant);
            }
        }

        //Recherche par nom du client
        private void txtnomcli_TextChange(object sender, EventArgs e)
        {

            classe.classecommande.recherche_affiche("SELECT  commande.numcli,client.nom,produit.codepro, commande.libelle,commande.qte_com,produit.pu,(pu*qte_com) as montant,commande.date,commande.time from commande,produit,client where (commande.libelle=produit.libelle) and (client.numcli = commande.numcli) and client.nom LIKE '%" + txtnomcli.Text + "%'", dgvcommande, lblmontant);
        }

        //Recherche entre deux dates
        private void btnrecherche_Click(object sender, EventArgs e)
        {
            string datenew = txtdatenew.Value.Date.ToString("yyyy/MM/dd");
            string dateold = txtdateold.Value.Date.ToString("yyyy/MM/dd");
            classe.classecommande.recherche_affiche("select  commande.numcli,client.nom,produit.codepro, commande.libelle,commande.qte_com,produit.pu,(pu*qte_com) as montant,commande.date,commande.time from client,commande,produit where (commande.libelle=produit.libelle) and (client.numcli = commande.numcli) and commande.date BETWEEN '" + dateold + "' AND '" + datenew + "'", dgvcommande, lblmontant);

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
