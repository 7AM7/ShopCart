namespace ShopCart
{
    partial class Login
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
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.password_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.email_txt = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.sigin_btn = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.remember_chk = new Bunifu.Framework.UI.BunifuCheckbox();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(139)))), ((int)(((byte)(212)))));
            this.panel2.Controls.Add(this.password_txt);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(80, 240);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(282, 41);
            this.panel2.TabIndex = 0;
            // 
            // password_txt
            // 
            this.password_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.password_txt.ForeColor = System.Drawing.Color.White;
            this.password_txt.HintForeColor = System.Drawing.Color.White;
            this.password_txt.HintText = "";
            this.password_txt.isPassword = true;
            this.password_txt.LineFocusedColor = System.Drawing.Color.Transparent;
            this.password_txt.LineIdleColor = System.Drawing.Color.Transparent;
            this.password_txt.LineMouseHoverColor = System.Drawing.Color.Transparent;
            this.password_txt.LineThickness = 3;
            this.password_txt.Location = new System.Drawing.Point(4, 4);
            this.password_txt.Margin = new System.Windows.Forms.Padding(4);
            this.password_txt.Name = "password_txt";
            this.password_txt.Size = new System.Drawing.Size(274, 33);
            this.password_txt.TabIndex = 0;
            this.password_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.password_txt.OnValueChanged += new System.EventHandler(this.bunifuMaterialTextbox2_OnValueChanged);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(81, 114);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(45, 18);
            this.bunifuCustomLabel1.TabIndex = 1;
            this.bunifuCustomLabel1.Text = "Email";
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(81, 222);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(64, 18);
            this.bunifuCustomLabel2.TabIndex = 2;
            this.bunifuCustomLabel2.Text = "Passwod";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(139)))), ((int)(((byte)(212)))));
            this.panel3.Controls.Add(this.email_txt);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(80, 144);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(282, 41);
            this.panel3.TabIndex = 0;
            // 
            // email_txt
            // 
            this.email_txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.email_txt.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_txt.ForeColor = System.Drawing.Color.White;
            this.email_txt.HintForeColor = System.Drawing.Color.White;
            this.email_txt.HintText = "";
            this.email_txt.isPassword = false;
            this.email_txt.LineFocusedColor = System.Drawing.Color.Transparent;
            this.email_txt.LineIdleColor = System.Drawing.Color.Transparent;
            this.email_txt.LineMouseHoverColor = System.Drawing.Color.Transparent;
            this.email_txt.LineThickness = 3;
            this.email_txt.Location = new System.Drawing.Point(4, 4);
            this.email_txt.Margin = new System.Windows.Forms.Padding(4);
            this.email_txt.Name = "email_txt";
            this.email_txt.Size = new System.Drawing.Size(274, 33);
            this.email_txt.TabIndex = 0;
            this.email_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Constantia", 10.25F);
            this.bunifuCustomLabel3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(77, 437);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(158, 17);
            this.bunifuCustomLabel3.TabIndex = 5;
            this.bunifuCustomLabel3.Text = "You don\'t have account?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.linkLabel1.Font = new System.Drawing.Font("Constantia", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.White;
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.LinkVisited = true;
            this.linkLabel1.Location = new System.Drawing.Point(241, 436);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 18);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Sign up Now !";
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Snow;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // sigin_btn
            // 
            this.sigin_btn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(139)))), ((int)(((byte)(212)))));
            this.sigin_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(139)))), ((int)(((byte)(212)))));
            this.sigin_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sigin_btn.BorderRadius = 0;
            this.sigin_btn.ButtonText = "Sign In";
            this.sigin_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sigin_btn.DisabledColor = System.Drawing.Color.Gray;
            this.sigin_btn.Iconcolor = System.Drawing.Color.Transparent;
            this.sigin_btn.Iconimage = null;
            this.sigin_btn.Iconimage_right = null;
            this.sigin_btn.Iconimage_right_Selected = null;
            this.sigin_btn.Iconimage_Selected = null;
            this.sigin_btn.IconMarginLeft = 0;
            this.sigin_btn.IconMarginRight = 0;
            this.sigin_btn.IconRightVisible = true;
            this.sigin_btn.IconRightZoom = 0D;
            this.sigin_btn.IconVisible = true;
            this.sigin_btn.IconZoom = 90D;
            this.sigin_btn.IsTab = false;
            this.sigin_btn.Location = new System.Drawing.Point(80, 326);
            this.sigin_btn.Name = "sigin_btn";
            this.sigin_btn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(139)))), ((int)(((byte)(212)))));
            this.sigin_btn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(149)))), ((int)(((byte)(212)))));
            this.sigin_btn.OnHoverTextColor = System.Drawing.Color.White;
            this.sigin_btn.selected = false;
            this.sigin_btn.Size = new System.Drawing.Size(274, 52);
            this.sigin_btn.TabIndex = 8;
            this.sigin_btn.Text = "Sign In";
            this.sigin_btn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sigin_btn.Textcolor = System.Drawing.Color.White;
            this.sigin_btn.TextFont = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sigin_btn.Click += new System.EventHandler(this.sigin_btn_Click);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(163)))), ((int)(((byte)(248)))));
            this.bunifuImageButton1.Image = global::ShopCart.Properties.Resources._1496080748_basics_05;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(12, 12);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(50, 50);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 4;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Constantia", 10.25F);
            this.bunifuCustomLabel4.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(106, 396);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(99, 17);
            this.bunifuCustomLabel4.TabIndex = 10;
            this.bunifuCustomLabel4.Text = "Remember Me";
            // 
            // remember_chk
            // 
            this.remember_chk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.remember_chk.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.remember_chk.Checked = false;
            this.remember_chk.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.remember_chk.ForeColor = System.Drawing.Color.White;
            this.remember_chk.Location = new System.Drawing.Point(80, 393);
            this.remember_chk.Name = "remember_chk";
            this.remember_chk.Size = new System.Drawing.Size(20, 20);
            this.remember_chk.TabIndex = 11;
            this.remember_chk.OnChange += new System.EventHandler(this.bunifuCheckbox1_OnChange);
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton2.Image = global::ShopCart.Properties.Resources.error;
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(380, 12);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(34, 33);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bunifuImageButton2.TabIndex = 12;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 50;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(163)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(426, 485);
            this.Controls.Add(this.bunifuImageButton2);
            this.Controls.Add(this.remember_chk);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Controls.Add(this.sigin_btn);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuImageButton1);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form2_MouseDown);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.Panel panel2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox password_txt;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel panel3;
        private Bunifu.Framework.UI.BunifuMaterialTextbox email_txt;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuFlatButton sigin_btn;
        #endregion

        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCheckbox remember_chk;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
    }
}

