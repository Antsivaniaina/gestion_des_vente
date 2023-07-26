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
    public partial class ajout_modif_client : Form
    {

        private UserControl usrclient;
        private readonly client _parent;
        public string numcli, nomcli, ville, phone;
        public ajout_modif_client(client parent, UserControl userC)
        {
            InitializeComponent();
            _parent = parent;
            this.usrclient = userC;
        }
        public void vider()
        {
            inputnumcli.Text = "Identifiant";
            inputnumcli.ForeColor = Color.Silver;
            inputnomcli.Text = "Nom du client";
            inputnomcli.ForeColor = Color.Silver;
            inputville.Text = "Ville";
            inputville.ForeColor = Color.Silver;
            inputphone.Text = "Téléphone";
            inputphone.ForeColor = Color.Silver;
        }
        public void save()
        {
            lblajout.Text = "Ajout client";
            btnajouter.Text = "Ajouter";
            btnfinir.Text = "Finir";
            // inputnumcli.Enabled = true;
        }
        string champobli()
        {
            if (inputnumcli.Text == "" || inputnumcli.Text == "Identifiant")
            {
                return "Veuiller entrer l'identifiant du client";
            }
            if (inputnomcli.Text == "" || inputnomcli.Text == "Nom du client")
            {
                return "Veuiller entrer le nom du client !";
            }
            if (inputville.Text == "" || inputville.Text == "Ville")
            {
                return "Veuiller entrer une ville !";
            }
            if (inputphone.Text == "" || inputphone.Text == "Téléphone")
            {
                return "Veuiller entrer le numéro de téléphone";
            }
            return null;
        }
        public void effacer()
        {
            inputnumcli.Text = inputnomcli.Text = inputville.Text = inputphone.Text = string.Empty;
        }
        public void modifier()
        {
            lblajout.Text = "Modifie client";
            btnajouter.Text = "Enregistrer";
            btnfinir.Text = "Annuler";
            btnfinir.Iconimage = Properties.Resources.icons8_add_32px_2;
            btnajouter.Iconimage = Properties.Resources.icons8_save_as_32px;
            // inputnumcli.Enabled = false;
            inputnumcli.Text = numcli;
            inputnomcli.Text = nomcli;
            inputphone.Text = phone;
            inputville.Text = ville;

        }
        public void autoID()
        {
            classe.classeclient.autoID(txtvar, inputnumcli, labelvar);
        }

        //onfocus sur les champs de saisies
        private void inputnumcli_Enter(object sender, EventArgs e)
        {
            if (inputnumcli.Text == "Identifiant")
            {
                inputnumcli.Text = "";
                inputnumcli.ForeColor = Color.Black;
            }
        }

        private void inputnomcli_Enter(object sender, EventArgs e)
        {
            if (inputnomcli.Text == "Nom du client")
            {
                inputnomcli.Text = "";
                inputnomcli.ForeColor = Color.Black;
            }
        }

        private void inputville_Enter(object sender, EventArgs e)
        {
            if (inputville.Text == "Ville")
            {
                inputville.Text = "";
                inputville.ForeColor = Color.Black;
            }
        }

        private void inputphone_Enter(object sender, EventArgs e)
        {
            if (inputphone.Text == "Téléphone")
            {
                inputphone.Text = "";
                inputphone.ForeColor = Color.Black;
            }
        }

       

        //onBlur sur les champs de saisies
        private void inputnumcli_Leave(object sender, EventArgs e)
        {
            if (inputnumcli.Text == "")
            {
                inputnumcli.Text = "Identifiant";
                inputnumcli.ForeColor = Color.Silver;
            }
        }
        private void inputnomcli_Leave(object sender, EventArgs e)
        {
            if (inputnomcli.Text == "")
            {
                inputnomcli.Text = "Nom du client";
                inputnomcli.ForeColor = Color.Silver;
            }
        }
        private void inputville_Leave(object sender, EventArgs e)
        {
            if (inputville.Text == "")
            {
                inputville.Text = "Ville";
                inputville.ForeColor = Color.Silver;
            }
        }
        private void inputphone_Leave(object sender, EventArgs e)
        {
            if (inputphone.Text == "")
            {
                inputphone.Text = "Téléphone";
                inputphone.ForeColor = Color.Silver;
            }
            if (inputphone.Text.Trim().Length < 10)
            {
                MessageBox.Show("Le numéro téléphone doit comporter 10 caratères.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                inputphone.Focus();
            }
        }
       

        //Ajouter les client
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
                    classe.classeclient ajout = new classe.classeclient(inputnumcli.Text.Trim(), inputnomcli.Text.Trim(), inputville.Text.Trim(), inputphone.Text.Trim());
                    classe.classeclient.ajout_client(ajout);
                    (usrclient as client).affichage();
                    vider();
                    classe.classeclient.autoID(txtvar, inputnumcli, labelvar);

                    //effacer();
                }
                if (btnajouter.Text == "Enregistrer")
                {
                    classe.classeclient modif = new classe.classeclient(inputnumcli.Text.Trim(), inputnomcli.Text.Trim(), inputville.Text.Trim(), inputphone.Text.Trim());
                    classe.classeclient.modif_client(modif, inputnumcli.Text.Trim());
                    (usrclient as client).affichage();
                    effacer();
                    this.Close();
                }
            }
    }
     

        //Saisir seulement des chiffres
        private void inputphone_KeyPress(object sender, KeyPressEventArgs e)
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
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnfinir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
