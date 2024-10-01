namespace HastaneOtomasyon
{
    partial class login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.gunaPanel1 = new Guna.UI.WinForms.GunaPanel();
            this.gunaLabel5 = new Guna.UI.WinForms.GunaLabel();
            this.gunaShadowPanel5 = new Guna.UI.WinForms.GunaShadowPanel();
            this.gunaShadowPanel4 = new Guna.UI.WinForms.GunaShadowPanel();
            this.gunaShadowPanel3 = new Guna.UI.WinForms.GunaShadowPanel();
            this.gunaLabel3 = new Guna.UI.WinForms.GunaLabel();
            this.gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
            this.grbBoxLoginDoktorGiris = new Guna.UI.WinForms.GunaGroupBox();
            this.txtBoxLoginDoktorPassword = new Guna.UI.WinForms.GunaTextBox();
            this.txtBoxLoginDoktorKullaniciAdi = new Guna.UI.WinForms.GunaTextBox();
            this.btnLoginDoktorGirisyap = new Guna.UI.WinForms.GunaButton();
            this.gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
            this.txtBoxLoginHastaPassword = new Guna.UI.WinForms.GunaTextBox();
            this.txtBoxLoginHastaTcno = new Guna.UI.WinForms.GunaTextBox();
            this.btnLoginHastaGirisyap = new Guna.UI.WinForms.GunaButton();
            this.gunaLabel1 = new Guna.UI.WinForms.GunaLabel();
            this.gunaLabel2 = new Guna.UI.WinForms.GunaLabel();
            this.gunaDragControlLogin = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaShadowPanel2 = new Guna.UI.WinForms.GunaShadowPanel();
            this.gunaLabel4 = new Guna.UI.WinForms.GunaLabel();
            this.gunaShadowPanel1 = new Guna.UI.WinForms.GunaShadowPanel();
            this.groupBoxHastaGiris = new Guna.UI.WinForms.GunaGroupBox();
            this.gunaLinkLabel1 = new Guna.UI.WinForms.GunaLinkLabel();
            this.gunaGroupBox1 = new Guna.UI.WinForms.GunaGroupBox();
            this.btnPersonelLogin = new Guna.UI.WinForms.GunaButton();
            this.btnDoktorLogin = new Guna.UI.WinForms.GunaButton();
            this.btnHastaLogin = new Guna.UI.WinForms.GunaButton();
            this.grbBoxLoginPersonelGiris = new Guna.UI.WinForms.GunaGroupBox();
            this.txtBoxLoginPersonelPassword = new Guna.UI.WinForms.GunaTextBox();
            this.txtBoxLoginPersonelKullaniciAdi = new Guna.UI.WinForms.GunaTextBox();
            this.btnLoginPersonelGirisyap = new Guna.UI.WinForms.GunaButton();
            this.gunaPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).BeginInit();
            this.grbBoxLoginDoktorGiris.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).BeginInit();
            this.groupBoxHastaGiris.SuspendLayout();
            this.gunaGroupBox1.SuspendLayout();
            this.grbBoxLoginPersonelGiris.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaPanel1
            // 
            this.gunaPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.gunaPanel1.BackgroundImage = global::HastaneOtomasyon.Properties.Resources.login;
            this.gunaPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gunaPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gunaPanel1.Controls.Add(this.gunaLabel5);
            this.gunaPanel1.Controls.Add(this.gunaShadowPanel5);
            this.gunaPanel1.Controls.Add(this.gunaShadowPanel4);
            this.gunaPanel1.Controls.Add(this.gunaShadowPanel3);
            this.gunaPanel1.Controls.Add(this.gunaLabel3);
            this.gunaPanel1.Controls.Add(this.gunaPictureBox2);
            this.gunaPanel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.gunaPanel1.Location = new System.Drawing.Point(387, 0);
            this.gunaPanel1.Name = "gunaPanel1";
            this.gunaPanel1.Size = new System.Drawing.Size(633, 585);
            this.gunaPanel1.TabIndex = 0;
            this.gunaPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.gunaPanel1_Paint);
            // 
            // gunaLabel5
            // 
            this.gunaLabel5.AutoSize = true;
            this.gunaLabel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gunaLabel5.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gunaLabel5.ForeColor = System.Drawing.Color.CadetBlue;
            this.gunaLabel5.Location = new System.Drawing.Point(599, 0);
            this.gunaLabel5.Name = "gunaLabel5";
            this.gunaLabel5.Size = new System.Drawing.Size(27, 28);
            this.gunaLabel5.TabIndex = 14;
            this.gunaLabel5.Text = "x";
            this.gunaLabel5.Click += new System.EventHandler(this.gunaLabel5_Click);
            // 
            // gunaShadowPanel5
            // 
            this.gunaShadowPanel5.BackColor = System.Drawing.Color.Transparent;
            this.gunaShadowPanel5.BaseColor = System.Drawing.Color.White;
            this.gunaShadowPanel5.Location = new System.Drawing.Point(573, 100);
            this.gunaShadowPanel5.Name = "gunaShadowPanel5";
            this.gunaShadowPanel5.ShadowColor = System.Drawing.Color.CadetBlue;
            this.gunaShadowPanel5.Size = new System.Drawing.Size(21, 377);
            this.gunaShadowPanel5.TabIndex = 13;
            // 
            // gunaShadowPanel4
            // 
            this.gunaShadowPanel4.BackColor = System.Drawing.Color.White;
            this.gunaShadowPanel4.BaseColor = System.Drawing.Color.White;
            this.gunaShadowPanel4.Location = new System.Drawing.Point(534, -11);
            this.gunaShadowPanel4.Name = "gunaShadowPanel4";
            this.gunaShadowPanel4.ShadowColor = System.Drawing.Color.CadetBlue;
            this.gunaShadowPanel4.Size = new System.Drawing.Size(97, 26);
            this.gunaShadowPanel4.TabIndex = 14;
            // 
            // gunaShadowPanel3
            // 
            this.gunaShadowPanel3.BackColor = System.Drawing.Color.Transparent;
            this.gunaShadowPanel3.BaseColor = System.Drawing.Color.White;
            this.gunaShadowPanel3.Location = new System.Drawing.Point(534, 564);
            this.gunaShadowPanel3.Name = "gunaShadowPanel3";
            this.gunaShadowPanel3.ShadowColor = System.Drawing.Color.CadetBlue;
            this.gunaShadowPanel3.Size = new System.Drawing.Size(97, 34);
            this.gunaShadowPanel3.TabIndex = 13;
            // 
            // gunaLabel3
            // 
            this.gunaLabel3.AutoSize = true;
            this.gunaLabel3.BackColor = System.Drawing.Color.Transparent;
            this.gunaLabel3.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gunaLabel3.ForeColor = System.Drawing.Color.White;
            this.gunaLabel3.Location = new System.Drawing.Point(108, 442);
            this.gunaLabel3.Name = "gunaLabel3";
            this.gunaLabel3.Size = new System.Drawing.Size(366, 84);
            this.gunaLabel3.TabIndex = 10;
            this.gunaLabel3.Text = "Hasta Güvenliği ve\r\nSağlığı Önceliğimizdir";
            // 
            // gunaPictureBox2
            // 
            this.gunaPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.gunaPictureBox2.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox2.Image")));
            this.gunaPictureBox2.Location = new System.Drawing.Point(45, -34);
            this.gunaPictureBox2.Name = "gunaPictureBox2";
            this.gunaPictureBox2.Size = new System.Drawing.Size(586, 560);
            this.gunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gunaPictureBox2.TabIndex = 9;
            this.gunaPictureBox2.TabStop = false;
            // 
            // grbBoxLoginDoktorGiris
            // 
            this.grbBoxLoginDoktorGiris.BackColor = System.Drawing.Color.White;
            this.grbBoxLoginDoktorGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grbBoxLoginDoktorGiris.BaseColor = System.Drawing.SystemColors.Control;
            this.grbBoxLoginDoktorGiris.BorderColor = System.Drawing.SystemColors.Control;
            this.grbBoxLoginDoktorGiris.Controls.Add(this.txtBoxLoginDoktorPassword);
            this.grbBoxLoginDoktorGiris.Controls.Add(this.txtBoxLoginDoktorKullaniciAdi);
            this.grbBoxLoginDoktorGiris.Controls.Add(this.btnLoginDoktorGirisyap);
            this.grbBoxLoginDoktorGiris.LineColor = System.Drawing.SystemColors.Control;
            this.grbBoxLoginDoktorGiris.Location = new System.Drawing.Point(12, 248);
            this.grbBoxLoginDoktorGiris.Name = "grbBoxLoginDoktorGiris";
            this.grbBoxLoginDoktorGiris.Size = new System.Drawing.Size(369, 285);
            this.grbBoxLoginDoktorGiris.TabIndex = 15;
            this.grbBoxLoginDoktorGiris.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // txtBoxLoginDoktorPassword
            // 
            this.txtBoxLoginDoktorPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxLoginDoktorPassword.BaseColor = System.Drawing.Color.White;
            this.txtBoxLoginDoktorPassword.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBoxLoginDoktorPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxLoginDoktorPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBoxLoginDoktorPassword.FocusedBorderColor = System.Drawing.Color.CadetBlue;
            this.txtBoxLoginDoktorPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxLoginDoktorPassword.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxLoginDoktorPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBoxLoginDoktorPassword.Location = new System.Drawing.Point(24, 108);
            this.txtBoxLoginDoktorPassword.Name = "txtBoxLoginDoktorPassword";
            this.txtBoxLoginDoktorPassword.PasswordChar = '\0';
            this.txtBoxLoginDoktorPassword.Radius = 15;
            this.txtBoxLoginDoktorPassword.Size = new System.Drawing.Size(320, 46);
            this.txtBoxLoginDoktorPassword.TabIndex = 3;
            this.txtBoxLoginDoktorPassword.Text = "Password";
            this.txtBoxLoginDoktorPassword.Enter += new System.EventHandler(this.txtBoxLoginDoktorPassword_Enter);
            this.txtBoxLoginDoktorPassword.Leave += new System.EventHandler(this.txtBoxLoginDoktorPassword_Leave);
            // 
            // txtBoxLoginDoktorKullaniciAdi
            // 
            this.txtBoxLoginDoktorKullaniciAdi.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxLoginDoktorKullaniciAdi.BaseColor = System.Drawing.Color.White;
            this.txtBoxLoginDoktorKullaniciAdi.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBoxLoginDoktorKullaniciAdi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxLoginDoktorKullaniciAdi.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBoxLoginDoktorKullaniciAdi.FocusedBorderColor = System.Drawing.Color.CadetBlue;
            this.txtBoxLoginDoktorKullaniciAdi.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxLoginDoktorKullaniciAdi.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxLoginDoktorKullaniciAdi.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBoxLoginDoktorKullaniciAdi.Location = new System.Drawing.Point(24, 33);
            this.txtBoxLoginDoktorKullaniciAdi.Name = "txtBoxLoginDoktorKullaniciAdi";
            this.txtBoxLoginDoktorKullaniciAdi.PasswordChar = '\0';
            this.txtBoxLoginDoktorKullaniciAdi.Radius = 15;
            this.txtBoxLoginDoktorKullaniciAdi.Size = new System.Drawing.Size(320, 49);
            this.txtBoxLoginDoktorKullaniciAdi.TabIndex = 4;
            this.txtBoxLoginDoktorKullaniciAdi.Enter += new System.EventHandler(this.txtBoxLoginDoktorKullaniciAdi_Enter);
            this.txtBoxLoginDoktorKullaniciAdi.Leave += new System.EventHandler(this.txtBoxLoginDoktorKullaniciAdi_Leave);
            // 
            // btnLoginDoktorGirisyap
            // 
            this.btnLoginDoktorGirisyap.AnimationHoverSpeed = 0.07F;
            this.btnLoginDoktorGirisyap.AnimationSpeed = 0.03F;
            this.btnLoginDoktorGirisyap.BackColor = System.Drawing.Color.Transparent;
            this.btnLoginDoktorGirisyap.BaseColor = System.Drawing.Color.CadetBlue;
            this.btnLoginDoktorGirisyap.BorderColor = System.Drawing.Color.Black;
            this.btnLoginDoktorGirisyap.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoginDoktorGirisyap.ForeColor = System.Drawing.Color.White;
            this.btnLoginDoktorGirisyap.Image = null;
            this.btnLoginDoktorGirisyap.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLoginDoktorGirisyap.Location = new System.Drawing.Point(168, 230);
            this.btnLoginDoktorGirisyap.Name = "btnLoginDoktorGirisyap";
            this.btnLoginDoktorGirisyap.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnLoginDoktorGirisyap.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLoginDoktorGirisyap.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnLoginDoktorGirisyap.OnHoverImage = null;
            this.btnLoginDoktorGirisyap.OnPressedColor = System.Drawing.Color.Black;
            this.btnLoginDoktorGirisyap.Radius = 15;
            this.btnLoginDoktorGirisyap.Size = new System.Drawing.Size(160, 42);
            this.btnLoginDoktorGirisyap.TabIndex = 5;
            this.btnLoginDoktorGirisyap.Text = "Giriş Yap";
            this.btnLoginDoktorGirisyap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLoginDoktorGirisyap.Click += new System.EventHandler(this.btnLoginDoktorGirisyap_Click);
            // 
            // gunaPictureBox1
            // 
            this.gunaPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gunaPictureBox1.BaseColor = System.Drawing.Color.White;
            this.gunaPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("gunaPictureBox1.Image")));
            this.gunaPictureBox1.Location = new System.Drawing.Point(36, -104);
            this.gunaPictureBox1.Name = "gunaPictureBox1";
            this.gunaPictureBox1.Size = new System.Drawing.Size(345, 342);
            this.gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.gunaPictureBox1.TabIndex = 1;
            this.gunaPictureBox1.TabStop = false;
            // 
            // txtBoxLoginHastaPassword
            // 
            this.txtBoxLoginHastaPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxLoginHastaPassword.BaseColor = System.Drawing.Color.White;
            this.txtBoxLoginHastaPassword.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBoxLoginHastaPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxLoginHastaPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBoxLoginHastaPassword.FocusedBorderColor = System.Drawing.Color.CadetBlue;
            this.txtBoxLoginHastaPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxLoginHastaPassword.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxLoginHastaPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBoxLoginHastaPassword.Location = new System.Drawing.Point(24, 108);
            this.txtBoxLoginHastaPassword.Name = "txtBoxLoginHastaPassword";
            this.txtBoxLoginHastaPassword.PasswordChar = '\0';
            this.txtBoxLoginHastaPassword.Radius = 15;
            this.txtBoxLoginHastaPassword.Size = new System.Drawing.Size(320, 46);
            this.txtBoxLoginHastaPassword.TabIndex = 3;
            this.txtBoxLoginHastaPassword.Text = "Password";
            this.txtBoxLoginHastaPassword.Enter += new System.EventHandler(this.txtBoxLoginHastaPassword_Enter);
            this.txtBoxLoginHastaPassword.Leave += new System.EventHandler(this.txtBoxLoginHastaPassword_Leave);
            // 
            // txtBoxLoginHastaTcno
            // 
            this.txtBoxLoginHastaTcno.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxLoginHastaTcno.BaseColor = System.Drawing.Color.White;
            this.txtBoxLoginHastaTcno.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBoxLoginHastaTcno.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxLoginHastaTcno.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBoxLoginHastaTcno.FocusedBorderColor = System.Drawing.Color.CadetBlue;
            this.txtBoxLoginHastaTcno.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxLoginHastaTcno.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxLoginHastaTcno.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBoxLoginHastaTcno.Location = new System.Drawing.Point(24, 33);
            this.txtBoxLoginHastaTcno.Name = "txtBoxLoginHastaTcno";
            this.txtBoxLoginHastaTcno.PasswordChar = '\0';
            this.txtBoxLoginHastaTcno.Radius = 15;
            this.txtBoxLoginHastaTcno.Size = new System.Drawing.Size(320, 49);
            this.txtBoxLoginHastaTcno.TabIndex = 4;
            this.txtBoxLoginHastaTcno.Text = "TC Kimlik No";
            this.txtBoxLoginHastaTcno.Enter += new System.EventHandler(this.txtBoxLoginHastaTcno_Enter);
            this.txtBoxLoginHastaTcno.Leave += new System.EventHandler(this.txtBoxLoginHastaTcno_Leave);
            // 
            // btnLoginHastaGirisyap
            // 
            this.btnLoginHastaGirisyap.AnimationHoverSpeed = 0.07F;
            this.btnLoginHastaGirisyap.AnimationSpeed = 0.03F;
            this.btnLoginHastaGirisyap.BackColor = System.Drawing.Color.Transparent;
            this.btnLoginHastaGirisyap.BaseColor = System.Drawing.Color.CadetBlue;
            this.btnLoginHastaGirisyap.BorderColor = System.Drawing.Color.Black;
            this.btnLoginHastaGirisyap.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoginHastaGirisyap.ForeColor = System.Drawing.Color.White;
            this.btnLoginHastaGirisyap.Image = null;
            this.btnLoginHastaGirisyap.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLoginHastaGirisyap.Location = new System.Drawing.Point(168, 230);
            this.btnLoginHastaGirisyap.Name = "btnLoginHastaGirisyap";
            this.btnLoginHastaGirisyap.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnLoginHastaGirisyap.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLoginHastaGirisyap.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnLoginHastaGirisyap.OnHoverImage = null;
            this.btnLoginHastaGirisyap.OnPressedColor = System.Drawing.Color.Black;
            this.btnLoginHastaGirisyap.Radius = 15;
            this.btnLoginHastaGirisyap.Size = new System.Drawing.Size(160, 42);
            this.btnLoginHastaGirisyap.TabIndex = 5;
            this.btnLoginHastaGirisyap.Text = "Giriş Yap";
            this.btnLoginHastaGirisyap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLoginHastaGirisyap.Click += new System.EventHandler(this.btnLoginHastaGirisyap_Click);
            // 
            // gunaLabel1
            // 
            this.gunaLabel1.AutoSize = true;
            this.gunaLabel1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gunaLabel1.ForeColor = System.Drawing.Color.Gray;
            this.gunaLabel1.Location = new System.Drawing.Point(102, 102);
            this.gunaLabel1.Name = "gunaLabel1";
            this.gunaLabel1.Size = new System.Drawing.Size(105, 20);
            this.gunaLabel1.TabIndex = 7;
            this.gunaLabel1.Text = "Hoşgeldiniz ";
            // 
            // gunaLabel2
            // 
            this.gunaLabel2.AutoSize = true;
            this.gunaLabel2.Font = new System.Drawing.Font("Bahnschrift", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gunaLabel2.ForeColor = System.Drawing.Color.CadetBlue;
            this.gunaLabel2.Location = new System.Drawing.Point(213, 100);
            this.gunaLabel2.Name = "gunaLabel2";
            this.gunaLabel2.Size = new System.Drawing.Size(95, 22);
            this.gunaLabel2.TabIndex = 8;
            this.gunaLabel2.Text = "DünyaMed";
            // 
            // gunaDragControlLogin
            // 
            this.gunaDragControlLogin.TargetControl = this;
            // 
            // gunaShadowPanel2
            // 
            this.gunaShadowPanel2.BackColor = System.Drawing.Color.Transparent;
            this.gunaShadowPanel2.BaseColor = System.Drawing.Color.White;
            this.gunaShadowPanel2.Location = new System.Drawing.Point(0, -9);
            this.gunaShadowPanel2.Name = "gunaShadowPanel2";
            this.gunaShadowPanel2.ShadowColor = System.Drawing.Color.CadetBlue;
            this.gunaShadowPanel2.Size = new System.Drawing.Size(481, 26);
            this.gunaShadowPanel2.TabIndex = 12;
            // 
            // gunaLabel4
            // 
            this.gunaLabel4.AutoSize = true;
            this.gunaLabel4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaLabel4.Location = new System.Drawing.Point(-19, -19);
            this.gunaLabel4.Name = "gunaLabel4";
            this.gunaLabel4.Size = new System.Drawing.Size(86, 20);
            this.gunaLabel4.TabIndex = 13;
            this.gunaLabel4.Text = "gunaLabel4";
            // 
            // gunaShadowPanel1
            // 
            this.gunaShadowPanel1.BackColor = System.Drawing.Color.White;
            this.gunaShadowPanel1.BaseColor = System.Drawing.Color.White;
            this.gunaShadowPanel1.Cursor = System.Windows.Forms.Cursors.No;
            this.gunaShadowPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gunaShadowPanel1.Location = new System.Drawing.Point(0, 566);
            this.gunaShadowPanel1.Name = "gunaShadowPanel1";
            this.gunaShadowPanel1.ShadowColor = System.Drawing.Color.CadetBlue;
            this.gunaShadowPanel1.Size = new System.Drawing.Size(481, 27);
            this.gunaShadowPanel1.TabIndex = 11;
            // 
            // groupBoxHastaGiris
            // 
            this.groupBoxHastaGiris.BackColor = System.Drawing.Color.White;
            this.groupBoxHastaGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxHastaGiris.BaseColor = System.Drawing.SystemColors.Control;
            this.groupBoxHastaGiris.BorderColor = System.Drawing.SystemColors.Control;
            this.groupBoxHastaGiris.Controls.Add(this.gunaLinkLabel1);
            this.groupBoxHastaGiris.Controls.Add(this.txtBoxLoginHastaPassword);
            this.groupBoxHastaGiris.Controls.Add(this.txtBoxLoginHastaTcno);
            this.groupBoxHastaGiris.Controls.Add(this.btnLoginHastaGirisyap);
            this.groupBoxHastaGiris.LineColor = System.Drawing.SystemColors.Control;
            this.groupBoxHastaGiris.Location = new System.Drawing.Point(12, 248);
            this.groupBoxHastaGiris.Name = "groupBoxHastaGiris";
            this.groupBoxHastaGiris.Size = new System.Drawing.Size(369, 285);
            this.groupBoxHastaGiris.TabIndex = 14;
            this.groupBoxHastaGiris.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // gunaLinkLabel1
            // 
            this.gunaLinkLabel1.AutoSize = true;
            this.gunaLinkLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.gunaLinkLabel1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gunaLinkLabel1.LinkColor = System.Drawing.Color.Gray;
            this.gunaLinkLabel1.Location = new System.Drawing.Point(20, 203);
            this.gunaLinkLabel1.Name = "gunaLinkLabel1";
            this.gunaLinkLabel1.Size = new System.Drawing.Size(132, 20);
            this.gunaLinkLabel1.TabIndex = 7;
            this.gunaLinkLabel1.TabStop = true;
            this.gunaLinkLabel1.Text = "Kaydın Yok Mu?";
            this.gunaLinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gunaLinkLabel1_LinkClicked);
            // 
            // gunaGroupBox1
            // 
            this.gunaGroupBox1.BackColor = System.Drawing.Color.White;
            this.gunaGroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gunaGroupBox1.BaseColor = System.Drawing.SystemColors.Control;
            this.gunaGroupBox1.BorderColor = System.Drawing.SystemColors.Control;
            this.gunaGroupBox1.Controls.Add(this.btnPersonelLogin);
            this.gunaGroupBox1.Controls.Add(this.btnDoktorLogin);
            this.gunaGroupBox1.Controls.Add(this.btnHastaLogin);
            this.gunaGroupBox1.LineColor = System.Drawing.SystemColors.Control;
            this.gunaGroupBox1.Location = new System.Drawing.Point(12, 160);
            this.gunaGroupBox1.Name = "gunaGroupBox1";
            this.gunaGroupBox1.Size = new System.Drawing.Size(369, 54);
            this.gunaGroupBox1.TabIndex = 15;
            this.gunaGroupBox1.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // btnPersonelLogin
            // 
            this.btnPersonelLogin.AnimationHoverSpeed = 0.07F;
            this.btnPersonelLogin.AnimationSpeed = 0.03F;
            this.btnPersonelLogin.BaseColor = System.Drawing.Color.White;
            this.btnPersonelLogin.BorderColor = System.Drawing.Color.Black;
            this.btnPersonelLogin.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPersonelLogin.ForeColor = System.Drawing.Color.Black;
            this.btnPersonelLogin.Image = null;
            this.btnPersonelLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.btnPersonelLogin.Location = new System.Drawing.Point(239, 0);
            this.btnPersonelLogin.Name = "btnPersonelLogin";
            this.btnPersonelLogin.OnHoverBaseColor = System.Drawing.Color.CadetBlue;
            this.btnPersonelLogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnPersonelLogin.OnHoverForeColor = System.Drawing.Color.White;
            this.btnPersonelLogin.OnHoverImage = null;
            this.btnPersonelLogin.OnPressedColor = System.Drawing.Color.RosyBrown;
            this.btnPersonelLogin.Size = new System.Drawing.Size(119, 54);
            this.btnPersonelLogin.TabIndex = 2;
            this.btnPersonelLogin.Text = "PERSONEL";
            this.btnPersonelLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnPersonelLogin.Click += new System.EventHandler(this.btnPersonelLogin_Click);
            // 
            // btnDoktorLogin
            // 
            this.btnDoktorLogin.AnimationHoverSpeed = 0.07F;
            this.btnDoktorLogin.AnimationSpeed = 0.03F;
            this.btnDoktorLogin.BaseColor = System.Drawing.Color.White;
            this.btnDoktorLogin.BorderColor = System.Drawing.Color.Black;
            this.btnDoktorLogin.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDoktorLogin.ForeColor = System.Drawing.Color.Black;
            this.btnDoktorLogin.Image = null;
            this.btnDoktorLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.btnDoktorLogin.Location = new System.Drawing.Point(118, 0);
            this.btnDoktorLogin.Name = "btnDoktorLogin";
            this.btnDoktorLogin.OnHoverBaseColor = System.Drawing.Color.CadetBlue;
            this.btnDoktorLogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnDoktorLogin.OnHoverForeColor = System.Drawing.Color.White;
            this.btnDoktorLogin.OnHoverImage = null;
            this.btnDoktorLogin.OnPressedColor = System.Drawing.Color.RosyBrown;
            this.btnDoktorLogin.Size = new System.Drawing.Size(115, 54);
            this.btnDoktorLogin.TabIndex = 1;
            this.btnDoktorLogin.Text = "DOKTOR";
            this.btnDoktorLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnDoktorLogin.Click += new System.EventHandler(this.btnDoktorLogin_Click);
            // 
            // btnHastaLogin
            // 
            this.btnHastaLogin.AnimationHoverSpeed = 0.07F;
            this.btnHastaLogin.AnimationSpeed = 0.03F;
            this.btnHastaLogin.BaseColor = System.Drawing.Color.White;
            this.btnHastaLogin.BorderColor = System.Drawing.Color.Black;
            this.btnHastaLogin.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHastaLogin.ForeColor = System.Drawing.Color.Black;
            this.btnHastaLogin.Image = null;
            this.btnHastaLogin.ImageSize = new System.Drawing.Size(20, 20);
            this.btnHastaLogin.Location = new System.Drawing.Point(0, 0);
            this.btnHastaLogin.Name = "btnHastaLogin";
            this.btnHastaLogin.OnHoverBaseColor = System.Drawing.Color.CadetBlue;
            this.btnHastaLogin.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnHastaLogin.OnHoverForeColor = System.Drawing.Color.White;
            this.btnHastaLogin.OnHoverImage = null;
            this.btnHastaLogin.OnPressedColor = System.Drawing.Color.RosyBrown;
            this.btnHastaLogin.Size = new System.Drawing.Size(112, 54);
            this.btnHastaLogin.TabIndex = 0;
            this.btnHastaLogin.Text = "HASTA";
            this.btnHastaLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnHastaLogin.Click += new System.EventHandler(this.btnHastaLogin_Click);
            // 
            // grbBoxLoginPersonelGiris
            // 
            this.grbBoxLoginPersonelGiris.BackColor = System.Drawing.Color.White;
            this.grbBoxLoginPersonelGiris.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.grbBoxLoginPersonelGiris.BaseColor = System.Drawing.SystemColors.Control;
            this.grbBoxLoginPersonelGiris.BorderColor = System.Drawing.SystemColors.Control;
            this.grbBoxLoginPersonelGiris.Controls.Add(this.txtBoxLoginPersonelPassword);
            this.grbBoxLoginPersonelGiris.Controls.Add(this.txtBoxLoginPersonelKullaniciAdi);
            this.grbBoxLoginPersonelGiris.Controls.Add(this.btnLoginPersonelGirisyap);
            this.grbBoxLoginPersonelGiris.LineColor = System.Drawing.SystemColors.Control;
            this.grbBoxLoginPersonelGiris.Location = new System.Drawing.Point(12, 248);
            this.grbBoxLoginPersonelGiris.Name = "grbBoxLoginPersonelGiris";
            this.grbBoxLoginPersonelGiris.Size = new System.Drawing.Size(355, 285);
            this.grbBoxLoginPersonelGiris.TabIndex = 16;
            this.grbBoxLoginPersonelGiris.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // txtBoxLoginPersonelPassword
            // 
            this.txtBoxLoginPersonelPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxLoginPersonelPassword.BaseColor = System.Drawing.Color.White;
            this.txtBoxLoginPersonelPassword.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBoxLoginPersonelPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxLoginPersonelPassword.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBoxLoginPersonelPassword.FocusedBorderColor = System.Drawing.Color.CadetBlue;
            this.txtBoxLoginPersonelPassword.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxLoginPersonelPassword.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxLoginPersonelPassword.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBoxLoginPersonelPassword.Location = new System.Drawing.Point(24, 108);
            this.txtBoxLoginPersonelPassword.Name = "txtBoxLoginPersonelPassword";
            this.txtBoxLoginPersonelPassword.PasswordChar = '\0';
            this.txtBoxLoginPersonelPassword.Radius = 15;
            this.txtBoxLoginPersonelPassword.Size = new System.Drawing.Size(320, 46);
            this.txtBoxLoginPersonelPassword.TabIndex = 3;
            this.txtBoxLoginPersonelPassword.Text = "Password";
            this.txtBoxLoginPersonelPassword.Enter += new System.EventHandler(this.txtBoxLoginPersonelPassword_Enter);
            this.txtBoxLoginPersonelPassword.Leave += new System.EventHandler(this.txtBoxLoginPersonelPassword_Leave);
            // 
            // txtBoxLoginPersonelKullaniciAdi
            // 
            this.txtBoxLoginPersonelKullaniciAdi.BackColor = System.Drawing.Color.Transparent;
            this.txtBoxLoginPersonelKullaniciAdi.BaseColor = System.Drawing.Color.White;
            this.txtBoxLoginPersonelKullaniciAdi.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtBoxLoginPersonelKullaniciAdi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxLoginPersonelKullaniciAdi.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBoxLoginPersonelKullaniciAdi.FocusedBorderColor = System.Drawing.Color.CadetBlue;
            this.txtBoxLoginPersonelKullaniciAdi.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBoxLoginPersonelKullaniciAdi.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBoxLoginPersonelKullaniciAdi.ForeColor = System.Drawing.Color.DarkGray;
            this.txtBoxLoginPersonelKullaniciAdi.Location = new System.Drawing.Point(24, 33);
            this.txtBoxLoginPersonelKullaniciAdi.Name = "txtBoxLoginPersonelKullaniciAdi";
            this.txtBoxLoginPersonelKullaniciAdi.PasswordChar = '\0';
            this.txtBoxLoginPersonelKullaniciAdi.Radius = 15;
            this.txtBoxLoginPersonelKullaniciAdi.Size = new System.Drawing.Size(320, 49);
            this.txtBoxLoginPersonelKullaniciAdi.TabIndex = 4;
            this.txtBoxLoginPersonelKullaniciAdi.Text = "Kullanıcı Adı";
            this.txtBoxLoginPersonelKullaniciAdi.Enter += new System.EventHandler(this.txtBoxLoginPersonelKullaniciAdi_Enter);
            this.txtBoxLoginPersonelKullaniciAdi.Leave += new System.EventHandler(this.txtBoxLoginPersonelKullaniciAdi_Leave);
            // 
            // btnLoginPersonelGirisyap
            // 
            this.btnLoginPersonelGirisyap.AnimationHoverSpeed = 0.07F;
            this.btnLoginPersonelGirisyap.AnimationSpeed = 0.03F;
            this.btnLoginPersonelGirisyap.BackColor = System.Drawing.Color.Transparent;
            this.btnLoginPersonelGirisyap.BaseColor = System.Drawing.Color.CadetBlue;
            this.btnLoginPersonelGirisyap.BorderColor = System.Drawing.Color.Black;
            this.btnLoginPersonelGirisyap.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLoginPersonelGirisyap.ForeColor = System.Drawing.Color.White;
            this.btnLoginPersonelGirisyap.Image = null;
            this.btnLoginPersonelGirisyap.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLoginPersonelGirisyap.Location = new System.Drawing.Point(168, 230);
            this.btnLoginPersonelGirisyap.Name = "btnLoginPersonelGirisyap";
            this.btnLoginPersonelGirisyap.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnLoginPersonelGirisyap.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLoginPersonelGirisyap.OnHoverForeColor = System.Drawing.Color.Black;
            this.btnLoginPersonelGirisyap.OnHoverImage = null;
            this.btnLoginPersonelGirisyap.OnPressedColor = System.Drawing.Color.Black;
            this.btnLoginPersonelGirisyap.Radius = 15;
            this.btnLoginPersonelGirisyap.Size = new System.Drawing.Size(160, 42);
            this.btnLoginPersonelGirisyap.TabIndex = 5;
            this.btnLoginPersonelGirisyap.Text = "Giriş Yap";
            this.btnLoginPersonelGirisyap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLoginPersonelGirisyap.Click += new System.EventHandler(this.btnLoginPersonelGirisyap_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1020, 585);
            this.Controls.Add(this.grbBoxLoginDoktorGiris);
            this.Controls.Add(this.gunaGroupBox1);
            this.Controls.Add(this.grbBoxLoginPersonelGiris);
            this.Controls.Add(this.groupBoxHastaGiris);
            this.Controls.Add(this.gunaLabel4);
            this.Controls.Add(this.gunaShadowPanel2);
            this.Controls.Add(this.gunaShadowPanel1);
            this.Controls.Add(this.gunaLabel2);
            this.Controls.Add(this.gunaLabel1);
            this.Controls.Add(this.gunaPictureBox1);
            this.Controls.Add(this.gunaPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "login";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.login_Load);
            this.LocationChanged += new System.EventHandler(this.login_LocationChanged);
            this.gunaPanel1.ResumeLayout(false);
            this.gunaPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox2)).EndInit();
            this.grbBoxLoginDoktorGiris.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gunaPictureBox1)).EndInit();
            this.groupBoxHastaGiris.ResumeLayout(false);
            this.groupBoxHastaGiris.PerformLayout();
            this.gunaGroupBox1.ResumeLayout(false);
            this.grbBoxLoginPersonelGiris.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPanel gunaPanel1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaTextBox txtBoxLoginHastaPassword;
        private Guna.UI.WinForms.GunaTextBox txtBoxLoginHastaTcno;
        private Guna.UI.WinForms.GunaButton btnLoginHastaGirisyap;
        private Guna.UI.WinForms.GunaLabel gunaLabel1;
        private Guna.UI.WinForms.GunaLabel gunaLabel2;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private Guna.UI.WinForms.GunaLabel gunaLabel3;
        private Guna.UI.WinForms.GunaDragControl gunaDragControlLogin;
        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel2;
        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel5;
        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel4;
        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel3;
        private Guna.UI.WinForms.GunaLabel gunaLabel5;
        private Guna.UI.WinForms.GunaLabel gunaLabel4;
        private Guna.UI.WinForms.GunaShadowPanel gunaShadowPanel1;
        private Guna.UI.WinForms.GunaGroupBox groupBoxHastaGiris;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox1;
        private Guna.UI.WinForms.GunaButton btnHastaLogin;
        private Guna.UI.WinForms.GunaButton btnDoktorLogin;
        private Guna.UI.WinForms.GunaButton btnPersonelLogin;
        private Guna.UI.WinForms.GunaGroupBox grbBoxLoginDoktorGiris;
        private Guna.UI.WinForms.GunaTextBox txtBoxLoginDoktorPassword;
        private Guna.UI.WinForms.GunaTextBox txtBoxLoginDoktorKullaniciAdi;
        private Guna.UI.WinForms.GunaButton btnLoginDoktorGirisyap;
        private Guna.UI.WinForms.GunaGroupBox grbBoxLoginPersonelGiris;
        private Guna.UI.WinForms.GunaTextBox txtBoxLoginPersonelPassword;
        private Guna.UI.WinForms.GunaTextBox txtBoxLoginPersonelKullaniciAdi;
        private Guna.UI.WinForms.GunaButton btnLoginPersonelGirisyap;
        private Guna.UI.WinForms.GunaLinkLabel gunaLinkLabel1;
    }
}

