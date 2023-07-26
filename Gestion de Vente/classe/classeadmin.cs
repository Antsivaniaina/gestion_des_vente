using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Gestion_de_Vente.classe
{
    class classadmin
    {

        public string Nomadmin { set; get; }
        public string Mdpadmin { set; get; }
        public string Mailadmin { set; get; }
        public string Iduser { set; get; }

        public classadmin(string iduser, string nomadmin, string mailadmin, string mdpadmin)
        {
            Iduser = iduser;
            Nomadmin = nomadmin;
            Mdpadmin = mdpadmin;
            Mailadmin =  mailadmin;
        }
        //Connexion a la base de donnée
        public static MySqlConnection connexionbase()
        {
            string sql = "datasource=localhost;username=root;password=;database=projetcsharp";
            MySqlConnection connexion = new MySqlConnection(sql);
            try
            {
                connexion.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Mysql Connection!\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connexion;
        }
        public static string hashage(string mdp)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(mdp);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[1].ToString("X6"));
            }
            return sb.ToString();
        }

        //Creer nouveau administrateur
        public static void creeradmin(classadmin user)
        {
            string sql1 = $"INSERT INTO utilisateur VALUES ('{user.Iduser}','{user.Nomadmin}','{user.Mailadmin}','{user.Mdpadmin}','admin')";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);

            try
            {
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Votre compte a été créer avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(user.Mailadmin);
                MessageBox.Show(ex.Message);
                MessageBox.Show("Une erreur inattendue nous empêche de créer votre compte.\n Veuiller réessayer les étapes.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connexion.Close();
        }

        //Se connecter
        public static void connecter(string nom, string mdp, Form afficher,Form cacher)
        {
            string sql1 = $"SELECT * FROM utilisateur WHERE nom='{nom}' AND mdp='{mdp}' AND status='admin'";
            MySqlConnection connexion = connexionbase();
            // MessageBox.Show(nom + mdp);
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);
            MySqlDataReader data = cmd1.ExecuteReader();
            if (data.Read() == true)
            {
                MessageBox.Show("Vous êtes connecté.", "Félicitation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cacher.Hide();
                afficher.Show();
            
            }
            else
            {
                MessageBox.Show("Login invalide !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //AutoID
        public static void autoID(TextBox txt, TextBox txtID, Label var)
        {
            string sql = "SELECT iduser from utilisateur order by iduser desc";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            DataSet data = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            if (data.Tables[0].Rows.Count > 0)
            {
                txt.Text = data.Tables[0].Rows[0]["iduser"].ToString();
            }
            else
            {
                txt.Text = "USR000";
            }
            if (!string.IsNullOrEmpty(txt.Text))
            {
                txt.SelectionStart = 3;
                txt.SelectionLength = 3;
                var.Text = txt.SelectedText;
            }
            if (!string.IsNullOrEmpty(var.Text))
            {
                int ID = int.Parse(var.Text.ToString()) + 1;
                txtID.Text = ID.ToString("USR000");
            }
        }
    }
}

