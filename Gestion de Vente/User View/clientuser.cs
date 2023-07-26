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
    public partial class clientuser : UserControl
    {
        private static clientuser pageclient;
        loginForm log;
        public clientuser()
        {
            InitializeComponent();
            log = new loginForm();
        }

        //Affichage user

        public static clientuser instance
        {
            get
            {
                if (pageclient == null)
                {
                    pageclient = new clientuser();
                }
                return pageclient;
            }
        }

        //Affichage sur le DatagriedView
        public void affichage()
        {
            classe.classeclient.recherche_affiche("select * from client", dgvclient);

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


        private void btnactualiser_Click(object sender, EventArgs e)
        {
            affichage();
        }
    }
}
