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
    public partial class principaluser : Form
    {
        public principaluser()
        {
            InitializeComponent();
        }
        //Quitter
        private void btnclose_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show("Voulez-vous vraiment quitter cette application ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (reponse == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //Agrandir
        private void btnagrandir_Click(object sender, EventArgs e)
        {
            // WindowState = FormWindowState.Maximized;
            if (WindowState.Equals(FormWindowState.Maximized))
            {
                WindowState = FormWindowState.Normal;
                // btnagrandir.Image = global::Gestion_de_Vente.Properties.Resources.icons8_macos_full_screen_20px;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                // btnagrandir.Image = global::Gestion_de_Vente.Properties.Resources.icons8_macos_full_screen_20px;
            }
        }

        //Reduire
        private void btnreduire_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Masquer et afficher menu
        private void btnaffiche_Click(object sender, EventArgs e)
        {

            if (pnlmenu.Width == 83)
            {
                pnlmenu.Visible = false;
                pnlmenu.Size = new Size(261, 879);
                panelanimation.ShowSync(pnlmenu);
                // logoanimation.ShowSync(logo);
            }
            else
            {
                // logoanimation.Hide(logo);
                pnlmenu.Visible = false;
                pnlmenu.Size = new Size(83, 879);
                panelanimation.ShowSync(pnlmenu);
            }
        }

        //CLIENT
        private void btnclient_Click(object sender, EventArgs e)
        {
            pnldeplace.Top = btnclient.Top;
            if (!pnlaffichertout.Controls.Contains(clientuser.instance))
            {
                pnlaffichertout.Controls.Add(clientuser.instance);
                clientuser.instance.Dock = DockStyle.Fill;
                clientuser.instance.BringToFront();
            }
            else
            {
                clientuser.instance.BringToFront();
            }
        }

        //PRODUIT
        private void btnproduit_Click(object sender, EventArgs e)
        {
            pnldeplace.Top = btnproduit.Top;
            if (!pnlaffichertout.Controls.Contains(produituser.instance))
            {
                pnlaffichertout.Controls.Add(produituser.instance);
                produituser.instance.Dock = DockStyle.Fill;
                produituser.instance.BringToFront();
            }
            else
            {
                produituser.instance.BringToFront();
            }
        }

        //COMMANDE
        private void btncommande_Click(object sender, EventArgs e)
        {
            pnldeplace.Top = btncommande.Top;
            if (!pnlaffichertout.Controls.Contains(commandeuser.instance))
            {
                pnlaffichertout.Controls.Add(commandeuser.instance);
                commandeuser.instance.Dock = DockStyle.Fill;
                commandeuser.instance.BringToFront();
            }
            else
            {
                commandeuser.instance.BringToFront();
            }
        }




        private void principal_Load(object sender, EventArgs e)
        {
            if (!pnlaffichertout.Controls.Contains(clientuser.instance))
            {
                pnlaffichertout.Controls.Add(clientuser.instance);
                clientuser.instance.Dock = DockStyle.Fill;
                clientuser.instance.BringToFront();
            }
            else
            {
                clientuser.instance.BringToFront();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
    }
}
