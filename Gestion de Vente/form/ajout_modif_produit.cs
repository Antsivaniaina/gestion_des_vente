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
    public partial class ajout_modif_produit : Form
    {

        private UserControl usrprod;
        private readonly produit _parent;
        public string numpro, libelle, pu, stock;
        public ajout_modif_produit(produit parent, UserControl userP)
        {
            InitializeComponent();
            _parent = parent;
            this.usrprod = userP;
        }

        public void autoID()
        {
            classe.classeproduit.autoID(txtvar, inputnumpro, labelvar);
        }
        public void vider()
        {
            inputnumpro.Text = "Identifiant du produit";
            inputnumpro.ForeColor = Color.Silver;
            inputlibelle.Text = "Nom du produit";
            inputlibelle.ForeColor = Color.Silver;
            inputpu.Text = "Prix unitaire";
            inputpu.ForeColor = Color.Silver;
            inputstock.Text = "Quantité en stock";
            inputstock.ForeColor = Color.Silver;
        }
        public void modifier()
        {
            lblajouter.Text = "Modifie produit";
            btnajouter.Text = "Enregistrer";
            btnfinir.Text = "Annuler";
            inputnumpro.Text = numpro;
            inputlibelle.Text = libelle;
            inputpu.Text = pu;
            inputstock.Text = stock;
        }
        public void save()
        {
            lblajouter.Text = "Ajout produit";
            btnajouter.Text = "Ajouter";
            btnfinir.Text = "Finir";
        }
        string champobli()
        {
            if (inputnumpro.Text == "" || inputnumpro.Text == "Identifiant du produit")
            {
                return "Veuiller entrer le numéro du produit";
            }
            if (inputlibelle.Text == "" || inputlibelle.Text == "Nom du produit")
            {
                return "Veuiller entrer le nom du produit";
            }
            if (inputpu.Text == "" || inputpu.Text == "Prix unitaire")
            {
                return "Veuiller entrer le prix unitaire du produit";
            }
            if (inputstock.Text == "" || inputstock.Text == "Quantité en stock" || inputstock.Text == "0")
            {
                return "Veuiller entrer la quantité en stock du produit";
            }
            return null;
        }
        //onFocus sur les champs de texte
        private void inputnumpro_Enter(object sender, EventArgs e)
        {
            if (inputnumpro.Text == "Identifiant du produit")
            {
                inputnumpro.Text = "";
                inputnumpro.ForeColor = Color.Black;
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

        private void inputpu_Enter(object sender, EventArgs e)
        {
            if (inputpu.Text == "Prix unitaire")
            {
                inputpu.Text = "";
                inputpu.ForeColor = Color.Black;
            }
        }

        private void inputstock_Enter(object sender, EventArgs e)
        {
            if (inputstock.Text == "Quantité en stock")
            {
                inputstock.Text = "";
                inputstock.ForeColor = Color.Black;
            }
        }

        //onBlur sur les zones de textes
        private void inputnumpro_Leave(object sender, EventArgs e)
        {
            if (inputnumpro.Text == "")
            {
                inputnumpro.Text = "Identifiant du produit";
                inputnumpro.ForeColor = Color.Silver;
            }
        }
        private void inputlibelle_Leave(object sender, EventArgs e)
        {
            if (inputlibelle.Text == "")
            {
                inputlibelle.Text = "Nom du produit";
                inputlibelle.ForeColor = Color.Silver;
            }
        }
        private void inputpu_Leave(object sender, EventArgs e)
        {
            if (inputpu.Text == "")
            {
                inputpu.Text = "Prix unitaire";
                inputpu.ForeColor = Color.Silver;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnfinir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void inputstock_Leave(object sender, EventArgs e)
        {
            if (inputstock.Text == "")
            {
                inputstock.Text = "Quantité en stock";
                inputstock.ForeColor = Color.Silver;
            }
        }
        
        private void btnajouter_Click(object sender, EventArgs e)
        {

            if (champobli() != null)
            {
                MessageBox.Show(champobli(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (btnajouter.Text == "Ajouter")
                {
                    // MessageBox.Show(date + time + inputlibelle.Text.Trim() + inputnumcli.Text.Trim());
                    classe.classeproduit ajout = new classe.classeproduit(inputnumpro.Text.Trim(), inputlibelle.Text.Trim(), inputpu.Text.Trim(), inputstock.Text.Trim());
                    classe.classeproduit.ajout_produit(ajout);
                    (usrprod as produit).affichage();
                    vider();
                    classe.classeproduit.autoID(txtvar, inputnumpro, labelvar);


                    //effacer();
                }
                if (btnajouter.Text == "Enregistrer")
                {
                    classe.classeproduit modif = new classe.classeproduit(inputnumpro.Text.Trim(), inputlibelle.Text.Trim(), inputpu.Text.Trim(), inputstock.Text.Trim());
                    classe.classeproduit.modif_produit(modif, inputnumpro.Text);
                    (usrprod as produit).affichage();
                    vider();
                    this.Close();
                }
            }
        }
    }
    
}
