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
    public partial class principal : Form
    {
        public principal()
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
            if (!pnlaffichertout.Controls.Contains(client.instance))
            {
                pnlaffichertout.Controls.Add(client.instance);
                client.instance.Dock = DockStyle.Fill;
                client.instance.BringToFront();
            }
            else
            {
                client.instance.BringToFront();
            }
        }

        //PRODUIT
        private void btnproduit_Click(object sender, EventArgs e)
        {
            pnldeplace.Top = btnproduit.Top;
             if (!pnlaffichertout.Controls.Contains(produit.instance))
            {
                pnlaffichertout.Controls.Add(produit.instance);
                produit.instance.Dock = DockStyle.Fill;
                produit.instance.BringToFront();
            }
            else
            {
                produit.instance.BringToFront();
            }
        }

        //COMMANDE
        private void btncommande_Click(object sender, EventArgs e)
        {
            pnldeplace.Top = btncommande.Top;
              if (!pnlaffichertout.Controls.Contains(commande.instance))
            {
                pnlaffichertout.Controls.Add(commande.instance);
                commande.instance.Dock = DockStyle.Fill;
                commande.instance.BringToFront();
            }
            else
            {
                commande.instance.BringToFront();
            }
        }

        //UTILISATEUR
        private void btnutilisateur_Click(object sender, EventArgs e)
        {
            pnldeplace.Top = btnutilisateur.Top;
            if (!pnlaffichertout.Controls.Contains(utilisateur.instance))
            {
                pnlaffichertout.Controls.Add(utilisateur.instance);
                utilisateur.instance.Dock = DockStyle.Fill;
                utilisateur.instance.BringToFront();
            }
            else
            {
                utilisateur.instance.BringToFront();
            }
        }

        private void principal_Load(object sender, EventArgs e)
        {
           if (!pnlaffichertout.Controls.Contains(client.instance))
            {
                pnlaffichertout.Controls.Add(client.instance);
                client.instance.Dock = DockStyle.Fill;
                client.instance.BringToFront();
            }
            else
            {
                client.instance.BringToFront();
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

            DialogResult reponse = MessageBox.Show("Voulez-vous vraiment se déconnecter ?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (reponse == DialogResult.Yes)
            {
                this.Hide();
            }

        }
    }
}
