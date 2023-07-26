using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using Bunifu.Framework.UI;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace Gestion_de_Vente.classe
{
    class classeproduit
    {

        //Accesseur
        public string Numpro { set; get; }
        public string Libelle { set; get; }
        public string Pu { set; get; }
        public string Stock { set; get; }

        //Constructeur de la classe CLIENT
        public classeproduit(string numpro, string libelle, string pu, string stock)
        {
            Numpro = numpro;
            Libelle = libelle;
            Pu = pu;
            Stock = stock;
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

        //Ajouter un PRODUIT
        public static void ajout_produit(classeproduit produit)
        {
            string sql1 = $"INSERT INTO produit VALUES ('{produit.Numpro}','{produit.Libelle}','{produit.Pu}','{produit.Stock}')";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);

            try
            {
                cmd1.ExecuteNonQuery();
                MessageBox.Show("Ajouter avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur d'ajout\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connexion.Close();
        }

        //Modifier un PRODUIT
        public static void modif_produit(classeproduit produit, string numpro)
        {
            string sql = $"UPDATE produit SET libelle='{produit.Libelle}', pu ='{produit.Pu}', quantite ='{produit.Stock}' WHERE codepro='{numpro}' ";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Modifier avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de modification\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connexion.Close();
        }

        //Supprimer un PRODUIT
        public static void supprime_produit(string libelle)
        {
            string sql = $"DELETE FROM produit WHERE libelle='{libelle}'";
            string sql1 = $"DELETE FROM commande WHERE libelle='{libelle}'";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);
            try
            {
                cmd1.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Supprimer avec succès", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de suppression\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connexion.Close();
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

        //Remplir les ComboBox
        public static void remplircombo(string table, string champAfficher, ComboBox cmbx)
        {
            MySqlConnection connexion = connexionbase();
            string sql = $"SELECT {champAfficher} FROM {table}";
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            DataTable tbl = new DataTable();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(tbl);
            cmbx.DataSource = tbl;
            cmbx.DisplayMember = champAfficher;
            connexion.Close();
        }

        //Autoncremmente codepro
        public static void autoID(TextBox txt, BunifuMaterialTextbox txtID, Label var)
        {
            string sql = "SELECT codepro from produit order by codepro desc";
            MySqlConnection connexion = connexionbase();
            MySqlCommand cmd = new MySqlCommand(sql, connexion);
            DataSet data = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            adp.Fill(data);
            if (data.Tables[0].Rows.Count > 0)
            {
                txt.Text = data.Tables[0].Rows[0]["codepro"].ToString();
            }
            else
            {
                txt.Text = "PDT000";
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
                txtID.Text = ID.ToString("PDT000");
            }
        }


        //PDF éfféctif produit
        public static void pdfproduit()
        {
            string date;
            Int32 somme = 0;
            date = DateTime.Now.ToString("yyyy/MM/dd");
            MySqlConnection connexion = connexionbase();
            string sql1 = "SELECT count(codepro) as somme from produit";
            string sql2 = "SELECT codepro,UPPER(libelle),pu,quantite from produit order by codepro asc";
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
            FileStream os = new FileStream("Effectif produit.pdf", FileMode.Create);
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
                cel1 = new PdfPCell(new Phrase("LISTE DE TOUTS LES PRODUITS", f_15_bold));
                cel2 = new PdfPCell(new Phrase("\nNombre total de produit : " + somme.ToString(), f_15_bold));

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
                txt = new string[] { "Identifiant du produit", "Libellé", "Prix unitaire", "Quantité en stock" };
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
                System.Diagnostics.Process.Start(@"Effectif produit.pdf");
            }
        }
    }
}
