using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Gestion_de_Vente.classe
{
    class classefacture
    {
        public string Numcli { set; get; }
        public string Idfact { set; get; }
        public string Date { set; get; }
      
        //Constructeur de la classe commande
        public classefacture(string numcli, string idfact, string date)
        {
            Numcli = numcli;
            Idfact = idfact;
            Date = date;
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

        //Ajout du facture a la base 
        public static void ajout_fact(classefacture fact)
        {
            MySqlConnection connexion = connexionbase();
            string sql = $"INSERT INTO facture VALUES ('{fact.Idfact}','{fact.Numcli}','{fact.Date}')";
            MySqlCommand cmd = new MySqlCommand(sql,connexion);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("La facture n'est pas générer.");
            }
        }

        //AutoID facture
        public static void autoID(TextBox txt, TextBox txtID, Label var)
        {
           
            string sql = "SELECT idfact from facture order by idfact desc";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            DataSet data = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            if (data.Tables[0].Rows.Count > 0)
            {
                txt.Text = data.Tables[0].Rows[0]["idfact"].ToString();
            }
            else
            {
                txt.Text = "000000";
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
                txtID.Text = ID.ToString("000000");
            }
            
        }

    }

}
