namespace Gestion_de_Vente.form
{
    partial class principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(principal));
            Bunifu.UI.WinForms.BunifuAnimatorNS.Animation animation1 = new Bunifu.UI.WinForms.BunifuAnimatorNS.Animation();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.header = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnreduire = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnagrandir = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnclose = new Bunifu.Framework.UI.BunifuImageButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlmenu = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pnldeplace = new System.Windows.Forms.Panel();
            this.btnutilisateur = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnproduit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btncommande = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnclient = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnaffiche = new Bunifu.Framework.UI.BunifuImageButton();
            this.pnlaffichertout = new System.Windows.Forms.Panel();
            this.bunifuGradientPanel1 = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.panelanimation = new Bunifu.UI.WinForms.BunifuTransition(this.components);
            this.header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnreduire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnagrandir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnaffiche)).BeginInit();
            this.pnlaffichertout.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.header;
            this.bunifuDragControl1.Vertical = true;
            // 
            // header
            // 
            this.header.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("header.BackgroundImage")));
            this.header.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.header.Controls.Add(this.bunifuImageButton1);
            this.header.Controls.Add(this.btnreduire);
            this.header.Controls.Add(this.btnagrandir);
            this.header.Controls.Add(this.btnclose);
            this.header.Controls.Add(this.pictureBox2);
            this.header.Controls.Add(this.bunifuCustomLabel1);
            this.panelanimation.SetDecoration(this.header, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.GradientBottomLeft = System.Drawing.Color.Silver;
            this.header.GradientBottomRight = System.Drawing.Color.White;
            this.header.GradientTopLeft = System.Drawing.Color.SkyBlue;
            this.header.GradientTopRight = System.Drawing.Color.PaleTurquoise;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Quality = 10;
            this.header.Size = new System.Drawing.Size(1491, 41);
            this.header.TabIndex = 1;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.panelanimation.SetDecoration(this.bunifuImageButton1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(1350, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(40, 38);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 1;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // btnreduire
            // 
            this.btnreduire.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnreduire.BackColor = System.Drawing.Color.Transparent;
            this.panelanimation.SetDecoration(this.btnreduire, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnreduire.Image = global::Gestion_de_Vente.Properties.Resources.icons8_macos_minimize_20px;
            this.btnreduire.ImageActive = null;
            this.btnreduire.Location = new System.Drawing.Point(1407, 9);
            this.btnreduire.Name = "btnreduire";
            this.btnreduire.Size = new System.Drawing.Size(20, 20);
            this.btnreduire.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnreduire.TabIndex = 3;
            this.btnreduire.TabStop = false;
            this.btnreduire.Zoom = 10;
            this.btnreduire.Click += new System.EventHandler(this.btnreduire_Click);
            // 
            // btnagrandir
            // 
            this.btnagrandir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnagrandir.BackColor = System.Drawing.Color.Transparent;
            this.panelanimation.SetDecoration(this.btnagrandir, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnagrandir.Image = global::Gestion_de_Vente.Properties.Resources.icons8_macos_full_screen_20px;
            this.btnagrandir.ImageActive = null;
            this.btnagrandir.Location = new System.Drawing.Point(1433, 9);
            this.btnagrandir.Name = "btnagrandir";
            this.btnagrandir.Size = new System.Drawing.Size(20, 20);
            this.btnagrandir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnagrandir.TabIndex = 2;
            this.btnagrandir.TabStop = false;
            this.btnagrandir.Zoom = 10;
            this.btnagrandir.Click += new System.EventHandler(this.btnagrandir_Click);
            // 
            // btnclose
            // 
            this.btnclose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnclose.BackColor = System.Drawing.Color.Transparent;
            this.panelanimation.SetDecoration(this.btnclose, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnclose.Image = global::Gestion_de_Vente.Properties.Resources.icons8_macos_close_20px_1;
            this.btnclose.ImageActive = null;
            this.btnclose.Location = new System.Drawing.Point(1459, 9);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(20, 20);
            this.btnclose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnclose.TabIndex = 2;
            this.btnclose.TabStop = false;
            this.btnclose.Zoom = 10;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.panelanimation.SetDecoration(this.pictureBox2, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pictureBox2.Image = global::Gestion_de_Vente.Properties.Resources.icons8_circled_menu_32px;
            this.pictureBox2.Location = new System.Drawing.Point(12, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 28);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.BackColor = System.Drawing.Color.Transparent;
            this.panelanimation.SetDecoration(this.bunifuCustomLabel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(49, 9);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(168, 22);
            this.bunifuCustomLabel1.TabIndex = 0;
            this.bunifuCustomLabel1.Text = "Gestion de VENTE";
            // 
            // pnlmenu
            // 
            this.pnlmenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlmenu.BackgroundImage")));
            this.pnlmenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlmenu.Controls.Add(this.pnldeplace);
            this.pnlmenu.Controls.Add(this.btnutilisateur);
            this.pnlmenu.Controls.Add(this.btnproduit);
            this.pnlmenu.Controls.Add(this.btncommande);
            this.pnlmenu.Controls.Add(this.btnclient);
            this.pnlmenu.Controls.Add(this.btnaffiche);
            this.panelanimation.SetDecoration(this.pnlmenu, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnlmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlmenu.GradientBottomLeft = System.Drawing.Color.Fuchsia;
            this.pnlmenu.GradientBottomRight = System.Drawing.Color.Purple;
            this.pnlmenu.GradientTopLeft = System.Drawing.Color.Silver;
            this.pnlmenu.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlmenu.Location = new System.Drawing.Point(0, 41);
            this.pnlmenu.Name = "pnlmenu";
            this.pnlmenu.Quality = 10;
            this.pnlmenu.Size = new System.Drawing.Size(261, 851);
            this.pnlmenu.TabIndex = 0;
            // 
            // pnldeplace
            // 
            this.pnldeplace.BackColor = System.Drawing.Color.PowderBlue;
            this.panelanimation.SetDecoration(this.pnldeplace, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnldeplace.Location = new System.Drawing.Point(1, 145);
            this.pnldeplace.Name = "pnldeplace";
            this.pnldeplace.Size = new System.Drawing.Size(10, 56);
            this.pnldeplace.TabIndex = 0;
            // 
            // btnutilisateur
            // 
            this.btnutilisateur.Active = false;
            this.btnutilisateur.Activecolor = System.Drawing.Color.Transparent;
            this.btnutilisateur.BackColor = System.Drawing.Color.Transparent;
            this.btnutilisateur.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnutilisateur.BorderRadius = 0;
            this.btnutilisateur.ButtonText = "  Utilisateur";
            this.btnutilisateur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelanimation.SetDecoration(this.btnutilisateur, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnutilisateur.DisabledColor = System.Drawing.Color.Gray;
            this.btnutilisateur.Font = new System.Drawing.Font("Bell MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnutilisateur.ForeColor = System.Drawing.SystemColors.Info;
            this.btnutilisateur.Iconcolor = System.Drawing.Color.Transparent;
            this.btnutilisateur.Iconimage = global::Gestion_de_Vente.Properties.Resources.customer_service_icon;
            this.btnutilisateur.Iconimage_right = null;
            this.btnutilisateur.Iconimage_right_Selected = null;
            this.btnutilisateur.Iconimage_Selected = null;
            this.btnutilisateur.IconMarginLeft = 20;
            this.btnutilisateur.IconMarginRight = 0;
            this.btnutilisateur.IconRightVisible = true;
            this.btnutilisateur.IconRightZoom = 0D;
            this.btnutilisateur.IconVisible = true;
            this.btnutilisateur.IconZoom = 90D;
            this.btnutilisateur.IsTab = true;
            this.btnutilisateur.Location = new System.Drawing.Point(1, 560);
            this.btnutilisateur.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnutilisateur.Name = "btnutilisateur";
            this.btnutilisateur.Normalcolor = System.Drawing.Color.Transparent;
            this.btnutilisateur.OnHovercolor = System.Drawing.Color.Gainsboro;
            this.btnutilisateur.OnHoverTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnutilisateur.selected = false;
            this.btnutilisateur.Size = new System.Drawing.Size(260, 56);
            this.btnutilisateur.TabIndex = 5;
            this.btnutilisateur.Text = "  Utilisateur";
            this.btnutilisateur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnutilisateur.Textcolor = System.Drawing.Color.White;
            this.btnutilisateur.TextFont = new System.Drawing.Font("Bell MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnutilisateur.Click += new System.EventHandler(this.btnutilisateur_Click);
            // 
            // btnproduit
            // 
            this.btnproduit.Active = false;
            this.btnproduit.Activecolor = System.Drawing.Color.Transparent;
            this.btnproduit.BackColor = System.Drawing.Color.Transparent;
            this.btnproduit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnproduit.BorderRadius = 0;
            this.btnproduit.ButtonText = "  Produit";
            this.btnproduit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelanimation.SetDecoration(this.btnproduit, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnproduit.DisabledColor = System.Drawing.Color.Gray;
            this.btnproduit.Font = new System.Drawing.Font("Bell MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproduit.ForeColor = System.Drawing.SystemColors.Info;
            this.btnproduit.Iconcolor = System.Drawing.Color.Transparent;
            this.btnproduit.Iconimage = global::Gestion_de_Vente.Properties.Resources.shop_cart_add_icon;
            this.btnproduit.Iconimage_right = null;
            this.btnproduit.Iconimage_right_Selected = null;
            this.btnproduit.Iconimage_Selected = null;
            this.btnproduit.IconMarginLeft = 20;
            this.btnproduit.IconMarginRight = 0;
            this.btnproduit.IconRightVisible = true;
            this.btnproduit.IconRightZoom = 0D;
            this.btnproduit.IconVisible = true;
            this.btnproduit.IconZoom = 90D;
            this.btnproduit.IsTab = true;
            this.btnproduit.Location = new System.Drawing.Point(1, 282);
            this.btnproduit.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnproduit.Name = "btnproduit";
            this.btnproduit.Normalcolor = System.Drawing.Color.Transparent;
            this.btnproduit.OnHovercolor = System.Drawing.Color.Gainsboro;
            this.btnproduit.OnHoverTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnproduit.selected = false;
            this.btnproduit.Size = new System.Drawing.Size(260, 56);
            this.btnproduit.TabIndex = 4;
            this.btnproduit.Text = "  Produit";
            this.btnproduit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproduit.Textcolor = System.Drawing.Color.White;
            this.btnproduit.TextFont = new System.Drawing.Font("Bell MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproduit.Click += new System.EventHandler(this.btnproduit_Click);
            // 
            // btncommande
            // 
            this.btncommande.Active = false;
            this.btncommande.Activecolor = System.Drawing.Color.Transparent;
            this.btncommande.BackColor = System.Drawing.Color.Transparent;
            this.btncommande.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btncommande.BorderRadius = 0;
            this.btncommande.ButtonText = "  Commande";
            this.btncommande.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelanimation.SetDecoration(this.btncommande, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btncommande.DisabledColor = System.Drawing.Color.Gray;
            this.btncommande.Font = new System.Drawing.Font("Bell MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncommande.ForeColor = System.Drawing.SystemColors.Info;
            this.btncommande.Iconcolor = System.Drawing.Color.Transparent;
            this.btncommande.Iconimage = global::Gestion_de_Vente.Properties.Resources.shopping_icon;
            this.btncommande.Iconimage_right = null;
            this.btncommande.Iconimage_right_Selected = null;
            this.btncommande.Iconimage_Selected = null;
            this.btncommande.IconMarginLeft = 20;
            this.btncommande.IconMarginRight = 0;
            this.btncommande.IconRightVisible = true;
            this.btncommande.IconRightZoom = 0D;
            this.btncommande.IconVisible = true;
            this.btncommande.IconZoom = 90D;
            this.btncommande.IsTab = true;
            this.btncommande.Location = new System.Drawing.Point(1, 418);
            this.btncommande.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btncommande.Name = "btncommande";
            this.btncommande.Normalcolor = System.Drawing.Color.Transparent;
            this.btncommande.OnHovercolor = System.Drawing.Color.Gainsboro;
            this.btncommande.OnHoverTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btncommande.selected = false;
            this.btncommande.Size = new System.Drawing.Size(260, 56);
            this.btncommande.TabIndex = 3;
            this.btncommande.Text = "  Commande";
            this.btncommande.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncommande.Textcolor = System.Drawing.Color.White;
            this.btncommande.TextFont = new System.Drawing.Font("Bell MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncommande.Click += new System.EventHandler(this.btncommande_Click);
            // 
            // btnclient
            // 
            this.btnclient.Active = false;
            this.btnclient.Activecolor = System.Drawing.Color.Transparent;
            this.btnclient.BackColor = System.Drawing.Color.Transparent;
            this.btnclient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnclient.BorderRadius = 0;
            this.btnclient.ButtonText = "  Client";
            this.btnclient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelanimation.SetDecoration(this.btnclient, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnclient.DisabledColor = System.Drawing.Color.Gray;
            this.btnclient.Font = new System.Drawing.Font("Bell MT", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclient.ForeColor = System.Drawing.SystemColors.Info;
            this.btnclient.Iconcolor = System.Drawing.Color.Transparent;
            this.btnclient.Iconimage = global::Gestion_de_Vente.Properties.Resources.Office_Client_Male_Light_icon;
            this.btnclient.Iconimage_right = null;
            this.btnclient.Iconimage_right_Selected = null;
            this.btnclient.Iconimage_Selected = null;
            this.btnclient.IconMarginLeft = 20;
            this.btnclient.IconMarginRight = 0;
            this.btnclient.IconRightVisible = true;
            this.btnclient.IconRightZoom = 0D;
            this.btnclient.IconVisible = true;
            this.btnclient.IconZoom = 90D;
            this.btnclient.IsTab = true;
            this.btnclient.Location = new System.Drawing.Point(1, 145);
            this.btnclient.Margin = new System.Windows.Forms.Padding(8, 8, 8, 8);
            this.btnclient.Name = "btnclient";
            this.btnclient.Normalcolor = System.Drawing.Color.Transparent;
            this.btnclient.OnHovercolor = System.Drawing.Color.Gainsboro;
            this.btnclient.OnHoverTextColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnclient.selected = false;
            this.btnclient.Size = new System.Drawing.Size(260, 56);
            this.btnclient.TabIndex = 2;
            this.btnclient.Text = "  Client";
            this.btnclient.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnclient.Textcolor = System.Drawing.Color.White;
            this.btnclient.TextFont = new System.Drawing.Font("Bell MT", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclient.Click += new System.EventHandler(this.btnclient_Click);
            // 
            // btnaffiche
            // 
            this.btnaffiche.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnaffiche.BackColor = System.Drawing.Color.Transparent;
            this.panelanimation.SetDecoration(this.btnaffiche, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.btnaffiche.Image = ((System.Drawing.Image)(resources.GetObject("btnaffiche.Image")));
            this.btnaffiche.ImageActive = null;
            this.btnaffiche.Location = new System.Drawing.Point(204, 6);
            this.btnaffiche.Name = "btnaffiche";
            this.btnaffiche.Size = new System.Drawing.Size(51, 50);
            this.btnaffiche.TabIndex = 1;
            this.btnaffiche.TabStop = false;
            this.btnaffiche.Zoom = 10;
            this.btnaffiche.Click += new System.EventHandler(this.btnaffiche_Click);
            // 
            // pnlaffichertout
            // 
            this.pnlaffichertout.Controls.Add(this.bunifuGradientPanel1);
            this.panelanimation.SetDecoration(this.pnlaffichertout, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.pnlaffichertout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlaffichertout.Location = new System.Drawing.Point(261, 41);
            this.pnlaffichertout.Name = "pnlaffichertout";
            this.pnlaffichertout.Size = new System.Drawing.Size(1230, 851);
            this.pnlaffichertout.TabIndex = 2;
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelanimation.SetDecoration(this.bunifuGradientPanel1, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.Silver;
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.White;
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.Aquamarine;
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.DarkCyan;
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 840);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(1230, 11);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // panelanimation
            // 
            this.panelanimation.AnimationType = Bunifu.UI.WinForms.BunifuAnimatorNS.AnimationType.Transparent;
            this.panelanimation.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.panelanimation.DefaultAnimation = animation1;
            // 
            // principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1491, 892);
            this.Controls.Add(this.pnlaffichertout);
            this.Controls.Add(this.pnlmenu);
            this.Controls.Add(this.header);
            this.panelanimation.SetDecoration(this, Bunifu.UI.WinForms.BunifuTransition.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "principal";
            this.Text = "3.6";
            this.Load += new System.EventHandler(this.principal_Load);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnreduire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnagrandir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnclose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnaffiche)).EndInit();
            this.pnlaffichertout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlmenu;
        private Bunifu.Framework.UI.BunifuGradientPanel header;
        private Bunifu.Framework.UI.BunifuImageButton btnaffiche;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuImageButton btnreduire;
        private Bunifu.Framework.UI.BunifuImageButton btnagrandir;
        private Bunifu.Framework.UI.BunifuImageButton btnclose;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private Bunifu.Framework.UI.BunifuFlatButton btnclient;
        private Bunifu.Framework.UI.BunifuFlatButton btnutilisateur;
        private Bunifu.Framework.UI.BunifuFlatButton btnproduit;
        private Bunifu.Framework.UI.BunifuFlatButton btncommande;
        private System.Windows.Forms.Panel pnlaffichertout;
        private Bunifu.UI.WinForms.BunifuTransition panelanimation;
        private System.Windows.Forms.Panel pnldeplace;
        private Bunifu.Framework.UI.BunifuGradientPanel bunifuGradientPanel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
    }
}