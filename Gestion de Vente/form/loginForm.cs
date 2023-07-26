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
    public partial class loginForm : Form
    {
        principal principale;
        principaluser principaleuser;
        public loginForm()
        {
            InitializeComponent();
            principale = new principal();
            principaleuser = new principaluser();
          
        }

        public  void  pagecreeradmin()
        {
            bunifuPages1.SetPage(3);
        }
        string champoblicreer()
        {
            if (txtnvnomadmin.Text == "")
            {
                return "Veuiller entrer un nom d'utilisateur";
            }
            if (txtnvmailadmin.Text == "")
            {
                return "Veuiller entrer une adresse e-mail";
            }
            if (txtnvmdpadmin.Text == "")
            {
                return "Veuiller entrer un mot de passe";
            }
            if (txtnvmdpcnfadmin.Text == "")
            {
                return "Veuiller resaisir le mot de passe";
            }

            return null;
        }
        string champoblicreeruser()
        {
            if (inputcreernom.Text == "")
            {
                return "Veuiller entrer un nom d'utilisateur";
            }
            if (inputmail.Text == "")
            {
                return "Veuiller entrer une adresse e-mail";
            }
            if (inputcreermdpnew.Text == "")
            {
                return "Veuiller entrer un mot de passe";
            }
            if (inputcreermdpold.Text == "")
            {
                return "Veuiller resaisir le mot de passe";
            }

            return null;
        }
        string champoblilogin()
        {

            if (txtadminname.Text == "")
            {
                return "Veuiller entrer un nom d'utilisateur";
            }
            if (txtmdpadmin.Text == "")
            {
                return "Veuiller saisir le mot de passe";
            }
            return null;
        }
        string champobliloginuser()
        {
            if (inputnom.Text == "")
            {
                return "Veuiller entrer un nom d'utilisateur";
            }
            if (inputmdp.Text == "")
            {
                return "Veuiller saisir le mot de passe";
            }
            return null;
        }
        private void btnseconnecter_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void btncreercompte_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        //Se connecter
        private void btnconnecter_Click(object sender, EventArgs e)
        {
            string mdphasher = classe.classeuser.hashage(inputmdp.Text.Trim());
            if (champobliloginuser() != null)
            {
                MessageBox.Show(champobliloginuser(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                classe.classeuser.connecter(inputnom.Text.Trim(), mdphasher, principaleuser,this);
                inputmdp.Text = "";
                inputnom.Text = "";
            }
        }

        //Créer user
        private void btncreer_Click(object sender, EventArgs e)
        {
            classe.classeuser.autoID(txtvar, inputID, labelvar);
            //classe.classeuser.hashage(inputcreermdpold.Text);
            if (champoblicreeruser() != null)
            {
                MessageBox.Show(champoblicreeruser(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (inputcreermdpold.Text.Trim() == inputcreermdpnew.Text.Trim())
                {
                    string mdphasher = classe.classeuser.hashage(inputcreermdpold.Text.Trim());
                    classe.classeuser user = new classe.classeuser(inputID.Text.Trim(), inputcreernom.Text.Trim(), inputmail.Text.Trim(), mdphasher);
                    classe.classeuser.creeruser(user);
                    inputcreermdpold.Text = "";
                    inputcreermdpnew.Text = "";
                    inputcreernom.Text = "";
                    inputmail.Text = "";
                    classe.classeuser.autoID(txtvar, inputID, labelvar);
                    bunifuPages1.SetPage(0);
                }

                else
                {
                    MessageBox.Show("Les mots de passe sont différent.", "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inputcreermdpold.Text = "";
                }
            }
        }
       

        //Afficher le mot de passe 
        private void btnshowpass_Click(object sender, EventArgs e)
        {
            if (inputcreermdpnew.PasswordChar == '•')
            {
                inputcreermdpnew.PasswordChar = '\0';
                btnmasquer.BringToFront();
            }
        }
        private void btnmasquer_Click(object sender, EventArgs e)
        {
            if (inputcreermdpnew.PasswordChar == '\0')
            {
                inputcreermdpnew.PasswordChar = '•';
                btnshowpass.BringToFront();
            }
        }

        private void btnshowpass1_Click(object sender, EventArgs e)
        {
            if (inputcreermdpold.PasswordChar == '•')
            {
                inputcreermdpold.PasswordChar = '\0';
                btnmasquer1.BringToFront();
            }
        }

        private void btnmasquer1_Click(object sender, EventArgs e)
        {
            if (inputcreermdpold.PasswordChar == '\0')
            {
                inputcreermdpold.PasswordChar = '•';
                btnshowpass1.BringToFront();
            }
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (inputmdp.PasswordChar == '\0')
            {
                inputmdp.PasswordChar = '•';
                bunifuImageButton4.BringToFront();
            }
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (inputmdp.PasswordChar == '•')
            {
                inputmdp.PasswordChar = '\0';
                bunifuImageButton3.BringToFront();
            }
        }

        //Vérification Mail
        private void inputmail_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.]*[a-zA-Z]$");
            if (inputmail.Text.Length > 0)
            {
                if (!rmail.IsMatch(inputmail.Text))
                {
                    MessageBox.Show("Adresse e-mail invalide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    inputmail.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        private void inputcreermdpnew_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (inputcreermdpnew.PasswordChar == '\0')
            {
                inputcreermdpnew.PasswordChar = '\0';
            }
            if (inputcreermdpnew.PasswordChar == '•')
            {
                inputcreermdpnew.PasswordChar = '•';
            }
        }

        private void inputcreermdpold_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (inputcreermdpold.PasswordChar == '\0')
            {
                inputcreermdpold.PasswordChar = '\0';
            }
            if (inputcreermdpold.PasswordChar == '•')
            {
                inputcreermdpold.PasswordChar = '•';
            }
        }

        private void inputmdp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (inputmdp.Text == "")
            {
                inputmdp.PasswordChar = '\0';
            }
            if (inputmdp.PasswordChar == '\0')
            {
                inputmdp.PasswordChar = '\0';
            }
            if (inputmdp.PasswordChar == '•')
            {
                inputmdp.PasswordChar = '•';
            }
        }

        private void lblpage0_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(2);
        }

        private void lblpage1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("J'éspère que vous êtes bien un administrateur.","Attention",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);
            formpassephrase pass = new formpassephrase();
            pass.ShowDialog();
            bunifuPages1.SetPage(3);
        }

        private void lblpage2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void inputcreermdpnew_Leave(object sender, EventArgs e)
        {

            if (inputcreermdpnew.Text.Trim().Length < 8)
            {
                MessageBox.Show("Le mot de passe doit comporter au moins 8 caractères.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                inputcreermdpnew.Focus();
            }
        }

        //SE connecter en tant qu'admin
        private void btnconnecteradmin_Click(object sender, EventArgs e)
        {

            string mdphasher = classe.classeuser.hashage(txtmdpadmin.Text.Trim());
            if (champoblilogin() != null)
            {
                MessageBox.Show(champoblilogin(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                classe.classadmin.connecter(txtadminname.Text.Trim(), mdphasher,principale,this);
                txtmdpadmin.Text = "";
            }
        }


        //Créer un compte admin
        private void btncreeradmin_Click(object sender, EventArgs e)
        {
            classe.classeuser.autoID(txtvarIDadmin, txtIDadmin, lblvaradmin);
            if (champoblicreer() != null)
            {
                MessageBox.Show(champoblicreer(), "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (txtnvmdpadmin.Text.Trim() == txtnvmdpcnfadmin.Text.Trim())
                {
                    string mdphasher = classe.classeuser.hashage(txtnvmdpadmin.Text.Trim());
                    classe.classadmin admin = new classe.classadmin(txtIDadmin.Text.Trim(), txtnvnomadmin.Text.Trim(), txtnvmailadmin.Text.Trim(), mdphasher);
                    classe.classadmin.creeradmin(admin);
                    txtnvmdpadmin.Text = "";
                    txtnvmdpcnfadmin.Text = "";
                    txtnvnomadmin.Text = "";
                    txtnvmailadmin.Text = "";
                    classe.classadmin.autoID(txtvarIDadmin, txtIDadmin, lblvaradmin);
                    bunifuPages1.SetPage(2);
                }

                else
                {
                    MessageBox.Show("Les mots de passe sont différent.\n Veuiller vérifier s'il vous plait!", "Obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnvmdpcnfadmin.Text = "";
                }
            }
        }

        private void txtnvmailadmin_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z\.]*[a-zA-Z]$");
            if (txtnvmailadmin.Text.Length > 0)
            {
                if (!rmail.IsMatch(txtnvmailadmin.Text))
                {
                    MessageBox.Show("Adresse e-mail invalide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtnvmailadmin.SelectAll();
                    e.Cancel = true;
                }
            }
        }

        //Mot de passe avec 8 caractères au moins
        private void txtnvmdpadmin_Leave(object sender, EventArgs e)
        {

            if (txtnvmdpadmin.Text.Trim().Length < 8)
            {
                MessageBox.Show("Le mot de passe doit comporter au moins 8 caractères.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtnvmdpadmin.Focus();
            }
        }
    }
}
