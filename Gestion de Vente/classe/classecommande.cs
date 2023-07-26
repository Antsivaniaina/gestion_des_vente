using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Gestion_de_Vente.classe
{
    class classecommande
    {
        //Accesseur
        public string Numcli { set; get; }
        public string Libelle { set; get; }
        public string Qte_com { set; get; }
        public string Date_com { set; get; }
        public string Time_com { set; get; }

        //Constructeur de la classe commande
        public classecommande(string numcli, string libelle, string qte_com, string date_com, string time_com)
        {
            Numcli = numcli;
            Libelle = libelle;
            Qte_com = qte_com;
            Date_com = date_com;
            Time_com = time_com;
        }

        //Connexion à la base de donnée
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

        //Ajout d'une commande
        public static void ajout_commande(classecommande com)
        {
            Int32 qte_stock = 0;
            string sql1 = $"INSERT INTO commande VALUES ('{com.Numcli}','{com.Libelle}','{com.Qte_com}','{com.Date_com}','{com.Time_com}')";
            string sql2 = $"UPDATE produit SET quantite=(quantite - '{com.Qte_com}') WHERE libelle='{com.Libelle}'";
            string sql3 = $"SELECT quantite FROM produit where libelle = '{com.Libelle}'";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);
            MySqlCommand cmd2 = new MySqlCommand(sql2, connexion);
            MySqlCommand cmd3 = new MySqlCommand(sql3, connexion);
            MySqlDataReader data = cmd3.ExecuteReader();
            try
            {
                while (data.Read())
                {
                    qte_stock = Int32.Parse(data[0].ToString());
                }
                if (qte_stock <= Int32.Parse(com.Qte_com))
                {
                    MessageBox.Show("La quantité en stock est insuffisante pour effectuer cette ajout.\nVous n'avez que "+qte_stock.ToString()+" "+com.Libelle+" en stock.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    data.Close();
                    cmd1.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    MessageBox.Show("La nouvelle commande a été bien enregistrer!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Il y a une erreur lors de l'enregistrement du commande!\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            connexion.Close();
        }

        //Modifier une commande
        public static void modif_commande(classecommande com, string time, int qte_reel)
        {
            Int32 qte_stock =0;
            Int32 diff = qte_reel - Int32.Parse(com.Qte_com.ToString());
            string sql1 = $"UPDATE commande SET libelle='{com.Libelle}', qte_com ='{com.Qte_com}' WHERE time='{time}' ";
            string sql2 = $"SELECT quantite FROM produit WHERE libelle='{com.Libelle}'";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);
            MySqlCommand cmd2 = new MySqlCommand(sql2, connexion);
            MySqlDataReader data = cmd2.ExecuteReader();
            try
            {
                while (data.Read())
                {
                    qte_stock = Int32.Parse(data[0].ToString());
                }
                data.Close();
                if (diff >= 0)
                {
                    string sql3 = $"UPDATE produit SET quantite=(quantite + {diff}) WHERE libelle = '{com.Libelle}'";
                    MySqlCommand cmd3 = new MySqlCommand(sql3, connexion);
                    cmd3.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("Votre commande a été bien modifier!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (diff < 0)
                {
                    diff = diff * (-1);
                    if ((qte_stock - diff) >= 0)
                    {
                        string sql4 = $"UPDATE produit SET quantite=(quantite - {diff}) WHERE libelle = '{com.Libelle}'";
                        MySqlCommand cmd4 = new MySqlCommand(sql4, connexion);
                        cmd4.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Votre commande a été bien modifier!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("La quantité en stock est insuffisante pour effectuer cette ajout.\nVous n'avez que " + qte_stock.ToString() +" "+ com.Libelle + " en stock.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de modification\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connexion.Close();
        }

        //Supprimer une commande

        public static void supprime_commande(string time)
        {
            string sql = $"DELETE FROM commande WHERE time ='{time}'";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Votre commande a été bien supprimer!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Il y a une erreur lors de la suppression du commande!\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connexion.Close();
        }

        //Rechercher et afficher 
        public static void recherche_affiche(string query, DataGridView dgv,Label affiche)
        {
            int total = 0;
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(query, connexion);
            DataTable tbl = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            MySqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                total += Int32.Parse(data[6].ToString());
            }
            affiche.Text = total.ToString() + " Ariary";
            connexion.Close();
        }

        //Remplir les ComboBox
        public static void remplircombo(string table, string champAfficher, ComboBox cmbx)
        {
            MySqlConnection connexion = connexionbase();
            string sql = $"SELECT {champAfficher} FROM {table} GROUP by {champAfficher}";
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            DataTable tbl = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(tbl);
            cmbx.DataSource = tbl;
            cmbx.DisplayMember = champAfficher;
            connexion.Close();
        }
    }
}
