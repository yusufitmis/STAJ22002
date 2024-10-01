namespace HastaneOtomasyon.DoktorModül.Poliklinik
{
    partial class TanıEkle
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbxSearch = new Guna.UI.WinForms.GunaTextBox();
            this.dgwTanılar = new Guna.UI.WinForms.GunaDataGridView();
            this.btnEkle = new Guna.UI.WinForms.GunaButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTanılar)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxSearch
            // 
            this.tbxSearch.BaseColor = System.Drawing.Color.White;
            this.tbxSearch.BorderColor = System.Drawing.Color.Silver;
            this.tbxSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxSearch.FocusedBaseColor = System.Drawing.Color.White;
            this.tbxSearch.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tbxSearch.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.tbxSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.tbxSearch.Location = new System.Drawing.Point(182, 12);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.PasswordChar = '\0';
            this.tbxSearch.Size = new System.Drawing.Size(296, 32);
            this.tbxSearch.TabIndex = 0;
            this.tbxSearch.TextChanged += new System.EventHandler(this.tbxSearch_TextChanged);
            // 
            // dgwTanılar
            // 
            this.dgwTanılar.AllowUserToAddRows = false;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            this.dgwTanılar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgwTanılar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwTanılar.BackgroundColor = System.Drawing.Color.White;
            this.dgwTanılar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgwTanılar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgwTanılar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwTanılar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgwTanılar.ColumnHeadersHeight = 27;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwTanılar.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgwTanılar.EnableHeadersVisualStyles = false;
            this.dgwTanılar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgwTanılar.Location = new System.Drawing.Point(25, 61);
            this.dgwTanılar.Name = "dgwTanılar";
            this.dgwTanılar.RowHeadersVisible = false;
            this.dgwTanılar.RowHeadersWidth = 51;
            this.dgwTanılar.RowTemplate.Height = 24;
            this.dgwTanılar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwTanılar.Size = new System.Drawing.Size(590, 234);
            this.dgwTanılar.TabIndex = 11;
            this.dgwTanılar.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.Guna;
            this.dgwTanılar.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgwTanılar.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgwTanılar.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgwTanılar.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgwTanılar.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgwTanılar.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgwTanılar.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgwTanılar.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgwTanılar.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgwTanılar.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgwTanılar.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgwTanılar.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgwTanılar.ThemeStyle.HeaderStyle.Height = 27;
            this.dgwTanılar.ThemeStyle.ReadOnly = false;
            this.dgwTanılar.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgwTanılar.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgwTanılar.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.dgwTanılar.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgwTanılar.ThemeStyle.RowsStyle.Height = 24;
            this.dgwTanılar.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgwTanılar.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // btnEkle
            // 
            this.btnEkle.AnimationHoverSpeed = 0.07F;
            this.btnEkle.AnimationSpeed = 0.03F;
            this.btnEkle.BaseColor = System.Drawing.Color.CadetBlue;
            this.btnEkle.BorderColor = System.Drawing.Color.Black;
            this.btnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEkle.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.White;
            this.btnEkle.Image = null;
            this.btnEkle.ImageSize = new System.Drawing.Size(20, 20);
            this.btnEkle.Location = new System.Drawing.Point(455, 301);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.OnHoverBaseColor = System.Drawing.Color.SkyBlue;
            this.btnEkle.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEkle.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEkle.OnHoverImage = null;
            this.btnEkle.OnPressedColor = System.Drawing.Color.Black;
            this.btnEkle.Size = new System.Drawing.Size(160, 42);
            this.btnEkle.TabIndex = 56;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click_1);
            // 
            // TanıEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 352);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.dgwTanılar);
            this.Controls.Add(this.tbxSearch);
            this.Name = "TanıEkle";
            this.Text = "TanıEkle";
            this.Load += new System.EventHandler(this.TanıEkle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTanılar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaTextBox tbxSearch;
        private Guna.UI.WinForms.GunaDataGridView dgwTanılar;
        private Guna.UI.WinForms.GunaButton btnEkle;
    }
}