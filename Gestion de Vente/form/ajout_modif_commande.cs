using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_de_Vente.form
{
    public partial class ajout_modif_commande : Form
    {
        private UserControl usrcommande;
        private readonly commande _parent;
        produit produit = new produit();
        public string numcli, libelle, quantite, time_modif, qte_reel;

        public ajout_modif_commande(commande parent, UserControl userC)
        {
            InitializeComponent();
            _parent = parent;
            this.usrcommande = userC;
        }
        public void autoID()
        {

            classe.classecommande.remplircombo("client", "numcli", inputnumcli);
            classe.classecommande.remplircombo("produit", "libelle", inputlibelle);
        }
        public void modifier()
        {
            lblajouter.Text = "Modification";
            btnajouter.Text = "Enregistrer";
            btnfinir.Text = "Annuler";
            inputnumcli.Enabled = false;
            inputnumcli.Text = numcli;
            inputlibelle.Text = libelle;
            inputquantite.Text = quantite;
        }
        public void save()
        {
            lblajouter.Text = "Ajout";
            btnajouter.Text = "Ajouter";
            btnfinir.Text = "Finir";
            inputnumcli.Enabled = true;
        }
        public void effacer()
        {
            inputquantite.Text = "";
        }

        //onFocus sur les zone de textes
        private void inputnumcli_Enter(object sender, EventArgs e)
        {
            if (inputnumcli.Text == "Identifiant client")
            {
                inputnumcli.Text = "";
                inputnumcli.ForeColor = Color.Black;
            }
        }

        private void inputlibelle_Enter(object sender, EventArgs e)
        {
            if (inputlibelle.Text == "Nom du produit")
            {
                inputlibelle.Text = "";
                inputlibelle.ForeColor = Color.Black;
            }
        }

        private void inputquantite_Enter_1(object sender, EventArgs e)
        {

            if (inputquantite.Text == "Quantité commandé")
            {
                inputquantite.Text = "";
                inputquantite.ForeColor = Color.Black;
            }
        }

        //onBlur sur les zones de textes
        private void inputnumcli_Leave(object sender, EventArgs e)
        {
            if (inputnumcli.Text == "")
            {
                inputnumcli.Text = "Identifiant client";
                inputnumcli.ForeColor = Color.Silver;
            }
        }

        private void inputlibelle_Leave(object sender, EventArgs e)
        {
            if (inputnumcli.Text == "")
            {
                inputnumcli.Text = "Nom du produit";
                inputnumcli.ForeColor = Color.Silver;
            }
        }

        private void inputquantite_Leave(object sender, EventArgs e)
        {
            if (inputnumcli.Text == "")
            {
                inputnumcli.Text = "Quantité commandé";
                inputnumcli.ForeColor = Color.Silver;
            }
        }

        private void inputquantite_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Ne pas entrer que des chiffres
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
            }
        }

        //Ajouter le commande
        private void btnajouter_Click(object sender, EventArgs e)
        {
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            string time = DateTime.Now.ToString("HH:mm:ss");
            if (champobli() != null)
            {
                MessageBox.Show(champobli(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (btnajouter.Text == "Ajouter")
                {
                    // MessageBox.Show(date + time + inputlibelle.Text.Trim() + inputnumcli.Text.Trim());
                    classe.classecommande ajout = new classe.classecommande(inputnumcli.Text.Trim(), inputlibelle.Text.Trim(), inputquantite.Text.Trim(), date, time);
                    classe.classecommande.ajout_commande(ajout);
                    (usrcommande as commande).affichage();
                    produit.affichage();
                    effacer();
                }
                if (btnajouter.Text == "Enregistrer")
                {
                    classe.classecommande modif = new classe.classecommande(inputnumcli.Text.Trim(), inputlibelle.Text.Trim(), inputquantite.Text.Trim(), date, time);
                    classe.classecommande.modif_commande(modif, time_modif, int.Parse(qte_reel.ToString()));
                    (usrcommande as commande).affichage();
                    produit.affichage();
                    effacer();
                    this.Close();
                }
            }
        }

        private void btnfinir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    
        //Obligatoire des champs
        string champobli()
        {
            if (inputnumcli.Text == "")
            {
                return "Veuiller choisir le numéro du client !";
            }
            if (inputlibelle.Text == "")
            {
                return "Veuiller choisir un libellé !";
            }
            if (inputquantite.Text == "" || inputquantite.Text == "0")
            {
                return "Veuiller entrer la quantité commandé !";
            }
            return null;
        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
