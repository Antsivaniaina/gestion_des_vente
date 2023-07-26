using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System.Security.Cryptography;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;



namespace Gestion_de_Vente.classe
{
    class classeuser
    {
        public string Nomuser { set; get; }
        public string Mdpuser { set; get; }
        public string Mailuser { set; get; }
        public string Iduser { set; get; }

        public classeuser(string iduser,string nomuser, string mailuser, string mdpuser)
        {
            Iduser = iduser;
            Nomuser = nomuser;
            Mdpuser = mdpuser;
            Mailuser = mailuser;
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
         
        //Creer nouveau utilisateur
        public static void creeruser(classeuser user)
        {
            string sql1 = $"INSERT INTO utilisateur VALUES ('{user.Iduser}','{user.Nomuser}','{user.Mailuser}','{user.Mdpuser}','user')";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);

            try
            {
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Compte créer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Compte non créer\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connexion.Close();
        }

        //Se connecter
        public static void connecter(string nom, string mdp, Form afficher, Form cacher)
        {
            string sql1 = $"SELECT * FROM utilisateur WHERE nom='{nom}' AND mdp='{mdp}' AND status='user'";
            MySqlConnection connexion = connexionbase();
           // MessageBox.Show(nom + mdp);
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);
            MySqlDataReader data = cmd1.ExecuteReader();
            try
            {
                if (data.Read() == true)
                {
                    MessageBox.Show("Vous êtes connecté", "Félicitation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cacher.Hide();
                    afficher.Show();
                }
                else
                {
                    MessageBox.Show("Login invalide !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Il y une  erreur lors de votre connexion, veuiller réessayer s'il vous plait.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //Rechercher et afficher 
        public static void recherche_affiche(string query, DataGridView dgv)
        {
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(query, connexion);
            DataTable tbl = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            connexion.Close();
        }

        //Supprimer un utilisateur
        public static void supprime_user(string iduser)
        {
            string sql = $"DELETE FROM utilisateur WHERE iduser='{iduser}'";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Compte supprimer avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Une erreur inattendue nous empêche de supprimer ce compte.\n Veuiller réessayer ultérieurement.\n", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connexion.Close();
        }

        //PDF éfféctif produit
        public static void pdfuser()
        {
            string date;
            Int32 somme = 0;
            date = DateTime.Now.ToString("yyyy/MM/dd");
            MySqlConnection connexion = connexionbase();
            string sql1 = "SELECT count(iduser) as somme from utilisateur";
            string sql2 = "SELECT iduser,nom,mail,UPPER(status) from utilisateur order by iduser asc";
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);
            MySqlCommand cmd2 = new MySqlCommand(sql2, connexion);
            MySqlDataReader data1 = cmd1.ExecuteReader();
            while (data1.Read())
            {
                somme = Int32.Parse(data1[0].ToString());
            }
            data1.Close();

            Document doc = new Document(PageSize.A4.Rotate());
            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 13, iTextSharp.text.Font.BOLD);
            FileStream os = new FileStream("Effectif utilisateur.pdf", FileMode.Create);
            using (os)
            {
                PdfWriter.GetInstance(doc, os);
                doc.Open();

                Paragraph para = new Paragraph(new Phrase("\"La paix accompagne le pas de ceux qui on le coeur pur\""));
                para.Alignment = Element.ALIGN_CENTER;
                doc.Add(para);
                //A propos facture
                PdfPTable table1 = new PdfPTable(1);
                float[] width = new float[] { 40f, 60f };

                PdfPCell cel1 = new PdfPCell(new Phrase("Date : " + date, f_15_bold));
                PdfPCell cel2 = new PdfPCell(new Phrase("", f_15_bold));
                PdfPCell cel3 = new PdfPCell(new Phrase("", f_15_bold));
                PdfPCell cel4 = new PdfPCell(new Phrase("", f_15_bold));

                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.WidthPercentage = 40;
                table1.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(cel1);
                table1.SpacingAfter = 20;
                table1.SpacingBefore = 50;
                doc.Add(table1);

                //A PROPOS des CLIENT
                table1 = new PdfPTable(1);
                cel1 = new PdfPCell(new Phrase("LISTE DE TOUTS LES utilisateurs", f_15_bold));
                cel2 = new PdfPCell(new Phrase("\nNombre total d'utilisateur : " + somme.ToString(), f_15_bold));

                cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                cel2.HorizontalAlignment = Element.ALIGN_CENTER;

                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;

                table1.AddCell(cel1);
                table1.AddCell(cel2);

                table1.SpacingAfter = 20;
                table1.SpacingBefore = 10;

                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_CENTER;
                table2.WidthPercentage = 40;
                doc.Add(table2);

                //Affichage du contenu de la facture
                string[] txt;
                txt = new string[] { "Identifiant d'utilisateur", "Nom", "Adresse e-mail", "Statut du compte" };
                table1 = new PdfPTable(4);
                for (int j = 0; j < 4; j++)
                {
                    cel1 = new PdfPCell(new Phrase(txt[j], f_12_normal));
                    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);
                }
                MySqlDataReader data2 = cmd2.ExecuteReader();
                while (data2.Read())
                {
                    for (int j = 0; j < 4; j++)
                    {
                        cel1 = new PdfPCell(new Phrase(data2[j].ToString()));
                        cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cel1.FixedHeight = 20;
                        table1.AddCell(cel1);
                    }
                }
                data1.Close();
                table1.WidthPercentage = 100;
                width = new float[] { 100, 100, 100, 100 };
                table1.SetWidths(width);
                table1.SpacingBefore = 20;
                doc.Add(table1);

                doc.Close();
                //Ouvrir le PDF après création
                System.Diagnostics.Process.Start(@"Effectif utilisateur.pdf");
            }
        }
    }
}
