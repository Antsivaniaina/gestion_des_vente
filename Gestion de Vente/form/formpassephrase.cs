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
    public partial class formpassephrase : Form
    {
        loginForm log;
        public formpassephrase()
        {
            InitializeComponent();
            log = new loginForm();
        }

        private void formpassephrase_Load(object sender, EventArgs e)
        {
          
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnvalider_Click(object sender, EventArgs e)
        {
            if (txtphrase.Text != "gestion de vente")
            {
                MessageBox.Show("La passephrase est incorrect.\nVeuiller saisir le bon passephrase.");
            }
            else
            {
                log.pagecreeradmin();
                this.Hide();
            }
           
        }
    }
}
