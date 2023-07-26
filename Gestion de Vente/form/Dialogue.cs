using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using MySql.Data.MySqlClient;
namespace Gestion_de_Vente.form
{
    public partial class Dialogue : Form
    {
        public string numcli, nom, ville, contact,date,idfact;
        public Int32 total=0;
        public Dialogue()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //Quitter
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Dialogue_Load(object sender, EventArgs e)
        {
            classe.classecommande.remplircombo("commande","numcli",inputnumcli);
           
        }

        //Générer la facture en PDF
        private void btnvalider_Click(object sender, EventArgs e)
        {
            classe.classefacture.autoID(txtvar, txtID, lblvar);
            date = DateTime.Now.ToString("yyyy/MM/dd");
             classe.classefacture fact = new classe.classefacture(inputnumcli.Text.Trim(),txtID.Text.Trim(),date);
             classe.classefacture.ajout_fact(fact);
            //Création des donnée du PDF
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
           
            string sql1 = $"SELECT produit.codepro, commande.libelle, commande.date,commande.time,produit.pu,commande.qte_com,(produit.pu*commande.qte_com) as montant from produit,commande where (produit.libelle = commande.libelle) and commande.numcli = '{inputnumcli.Text.Trim()}' group by produit.codepro order by commande.date DESC";
            string sql2 = $"SELECT * from client where numcli = '{inputnumcli.Text.Trim()}'";
            MySqlCommand cmd1 = new MySqlCommand(sql1, connexion);
            MySqlCommand cmd2 = new MySqlCommand(sql2, connexion);
            MySqlDataReader data2 = cmd2.ExecuteReader();
            while (data2.Read())
            {
                numcli = data2[0].ToString();
                nom = data2[1].ToString();
                ville = data2[2].ToString();
                contact = data2[3].ToString();
            }
            data2.Close();
            Document doc = new Document(PageSize.A4.Rotate());


            BaseFont arial = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font f_15_bold = new iTextSharp.text.Font(arial, 15, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font f_12_normal = new iTextSharp.text.Font(arial, 13, iTextSharp.text.Font.BOLD);
            FileStream os = new FileStream("Facture"+txtID.Text.Trim()+inputnumcli.Text.Trim()+ ".pdf", FileMode.Create);
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

                PdfPCell cel1 = new PdfPCell(new Phrase("Date : "+date, f_15_bold));
                PdfPCell cel2 = new PdfPCell(new Phrase("Facture n° : "+txtID.Text.Trim(), f_15_bold));
                PdfPCell cel3 = new PdfPCell(new Phrase("", f_15_bold));
                PdfPCell cel4 = new PdfPCell(new Phrase("", f_15_bold));

                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel1.HorizontalAlignment = Element.ALIGN_LEFT;
                cel2.HorizontalAlignment = Element.ALIGN_LEFT;
                cel3.HorizontalAlignment = Element.ALIGN_LEFT;
                cel4.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.WidthPercentage = 40;
                table1.HorizontalAlignment = Element.ALIGN_LEFT;
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.SpacingAfter = 20;
                table1.SpacingBefore = 50;
                doc.Add(table1);

                //A PROPOS CLIENT
                table1 = new PdfPTable(1);
                cel1 = new PdfPCell(new Phrase("Identifiant client:    "+numcli, f_15_bold));
                cel2 = new PdfPCell(new Phrase("Nom :  "+nom.ToUpper(), f_15_bold));
                cel3 = new PdfPCell(new Phrase("Adresse :  " + ville.ToUpper(), f_15_bold));
                cel4 = new PdfPCell(new Phrase("Contact :  " + contact, f_15_bold));

                cel1.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel2.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel3.HorizontalAlignment = Element.ALIGN_JUSTIFIED;
                cel4.HorizontalAlignment = Element.ALIGN_JUSTIFIED;

                cel1.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel2.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel3.Border = iTextSharp.text.Rectangle.NO_BORDER;
                cel4.Border = iTextSharp.text.Rectangle.NO_BORDER;

                table1.AddCell(cel1);
                table1.AddCell(cel2);
                table1.AddCell(cel3);
                table1.AddCell(cel4);

                table1.SpacingAfter = 20;
                table1.SpacingBefore = 10;

                PdfPTable table2 = new PdfPTable(1);
                table2.AddCell(table1);
                table2.HorizontalAlignment = Element.ALIGN_RIGHT;
                table2.WidthPercentage = 40;
                doc.Add(table2);

                //Affichage du contenu de la facture
                string[] txt;
                txt = new string[] {"Référence Produit","Libellé","Date du commande","Heure", "Qte", "PU", "Montant"};
                table1 = new PdfPTable(7);
                for (int j = 0; j < 7; j++)
                {
                    cel1 = new PdfPCell(new Phrase(txt[j],f_12_normal));
                    cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                    cel1.FixedHeight = 20;
                    table1.AddCell(cel1);
                }
                MySqlDataReader data1 = cmd1.ExecuteReader();
                while (data1.Read())
                {
                    for (int j = 0; j < 7; j++)
                    {
                        cel1 = new PdfPCell(new Phrase(data1[j].ToString()));
                        cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cel1.FixedHeight = 20;
                        table1.AddCell(cel1);
                    }
                    total += Int32.Parse(data1[6].ToString());
                }
                data1.Close();
                table1.WidthPercentage = 100;
                width = new float[] { 100, 100,100,100, 100,100,100};
                table1.SetWidths(width);
                table1.SpacingBefore = 20;
               doc.Add(table1);

                //TOTAL
                table1 = new PdfPTable(2);
                cel1 = new PdfPCell(new Phrase("TOTAL", f_15_bold));
                cel2 = new PdfPCell(new Phrase(total.ToString(), f_15_bold));
                cel1.HorizontalAlignment = Element.ALIGN_CENTER;
                cel2.HorizontalAlignment = Element.ALIGN_RIGHT;
                cel1.FixedHeight = 30;
                cel2.FixedHeight = 30;
                table1.WidthPercentage = 29;
                table1.HorizontalAlignment = Element.ALIGN_RIGHT;
                width = new float[] { 100, 100 };
                table1.SetWidths(width);
                table1.AddCell(cel1);
                table1.AddCell(cel2);
                doc.Add(table1);

                //Signature

                doc.Close();
                //Ouvrir le PDF après création
                System.Diagnostics.Process.Start(@"Facture" + txtID.Text.Trim()+inputnumcli.Text.Trim()+".pdf");
            }
            this.Hide();

        }
    }
}
