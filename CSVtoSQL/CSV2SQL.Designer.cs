namespace CSVtoSQL
{
    partial class CSV2SQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSV2SQL));
            this.csvGrid = new DevExpress.XtraGrid.GridControl();
            this.csvView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmbDb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbTbl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dbGrid = new DevExpress.XtraGrid.GridControl();
            this.dbView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCsvLoc = new DevExpress.XtraEditors.TextEdit();
            this.cmbSQLServerName = new DevExpress.XtraEditors.ComboBoxEdit();
            this.CSVFirstRowHeader = new DevExpress.XtraEditors.ToggleSwitch();
            this.CSVGozat = new DevExpress.XtraEditors.SimpleButton();
            this.Aktar = new DevExpress.XtraEditors.SimpleButton();
            this.cmb_txtDelimiter = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.csvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.csvView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTbl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCsvLoc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSQLServerName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSVFirstRowHeader.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_txtDelimiter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // csvGrid
            // 
            this.csvGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.csvGrid.Location = new System.Drawing.Point(12, 196);
            this.csvGrid.MainView = this.csvView;
            this.csvGrid.Name = "csvGrid";
            this.csvGrid.Size = new System.Drawing.Size(1132, 380);
            this.csvGrid.TabIndex = 0;
            this.csvGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.csvView});
            // 
            // csvView
            // 
            this.csvView.GridControl = this.csvGrid;
            this.csvView.Name = "csvView";
            this.csvView.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.csvView_CustomDrawRowIndicator);
            // 
            // cmbDb
            // 
            this.cmbDb.Location = new System.Drawing.Point(112, 70);
            this.cmbDb.Name = "cmbDb";
            this.cmbDb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDb.Size = new System.Drawing.Size(310, 20);
            this.cmbDb.TabIndex = 4;
            this.cmbDb.SelectedIndexChanged += new System.EventHandler(this.cmbDb_SelectedIndexChanged);
            // 
            // cmbTbl
            // 
            this.cmbTbl.Location = new System.Drawing.Point(112, 96);
            this.cmbTbl.Name = "cmbTbl";
            this.cmbTbl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTbl.Size = new System.Drawing.Size(310, 20);
            this.cmbTbl.TabIndex = 5;
            this.cmbTbl.SelectedIndexChanged += new System.EventHandler(this.cmbTbl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SQL Veri Tabanı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL Tablosu :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(599, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kolonlar arası Ayraç karakteri";
            // 
            // dbGrid
            // 
            this.dbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbGrid.Location = new System.Drawing.Point(12, 168);
            this.dbGrid.MainView = this.dbView;
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.Size = new System.Drawing.Size(1132, 22);
            this.dbGrid.TabIndex = 7;
            this.dbGrid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dbView});
            // 
            // dbView
            // 
            this.dbView.GridControl = this.dbGrid;
            this.dbView.Name = "dbView";
            this.dbView.OptionsView.ShowGroupPanel = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(599, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "CSV nin ilk satırı başlık (header) mı ?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "SQL Server Adı :";
            // 
            // txtUserName
            // 
            this.txtUserName.EditValue = "bilset";
            this.txtUserName.Location = new System.Drawing.Point(112, 40);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(133, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "SQL Kullanıcı Adı :";
            // 
            // txtPass
            // 
            this.txtPass.EditValue = "Bilset1234";
            this.txtPass.Location = new System.Drawing.Point(301, 40);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.UseSystemPasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(121, 20);
            this.txtPass.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(259, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Şifre :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "CSV Dosya yolu :";
            // 
            // txtCsvLoc
            // 
            this.txtCsvLoc.Enabled = false;
            this.txtCsvLoc.Location = new System.Drawing.Point(112, 132);
            this.txtCsvLoc.Name = "txtCsvLoc";
            this.txtCsvLoc.Size = new System.Drawing.Size(310, 20);
            this.txtCsvLoc.TabIndex = 6;
            // 
            // cmbSQLServerName
            // 
            this.cmbSQLServerName.Location = new System.Drawing.Point(112, 12);
            this.cmbSQLServerName.Name = "cmbSQLServerName";
            this.cmbSQLServerName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSQLServerName.Size = new System.Drawing.Size(310, 20);
            this.cmbSQLServerName.TabIndex = 1;
            this.cmbSQLServerName.Leave += new System.EventHandler(this.cmbSqlServerName_Leave);
            // 
            // CSVFirstRowHeader
            // 
            this.CSVFirstRowHeader.EditValue = true;
            this.CSVFirstRowHeader.Location = new System.Drawing.Point(776, 115);
            this.CSVFirstRowHeader.Name = "CSVFirstRowHeader";
            this.CSVFirstRowHeader.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Default;
            this.CSVFirstRowHeader.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Default;
            this.CSVFirstRowHeader.Properties.OffText = "Hayır";
            this.CSVFirstRowHeader.Properties.OnText = "Evet";
            this.CSVFirstRowHeader.Size = new System.Drawing.Size(100, 24);
            this.CSVFirstRowHeader.TabIndex = 12;
            this.CSVFirstRowHeader.Modified += new System.EventHandler(this.CSVFirstRowHeader_Modified);
            // 
            // CSVGozat
            // 
            this.CSVGozat.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CSVGozat.Appearance.Options.UseFont = true;
            this.CSVGozat.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("CSVGozat.ImageOptions.Image")));
            this.CSVGozat.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.CSVGozat.Location = new System.Drawing.Point(428, 120);
            this.CSVGozat.Name = "CSVGozat";
            this.CSVGozat.Size = new System.Drawing.Size(147, 42);
            this.CSVGozat.TabIndex = 104;
            this.CSVGozat.Text = "&CSV Gözat";
            this.CSVGozat.Click += new System.EventHandler(this.CSVGozat_Click);
            // 
            // Aktar
            // 
            this.Aktar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Aktar.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Aktar.Appearance.Options.UseFont = true;
            this.Aktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Aktar.ImageOptions.Image")));
            this.Aktar.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightCenter;
            this.Aktar.Location = new System.Drawing.Point(942, 43);
            this.Aktar.Name = "Aktar";
            this.Aktar.Size = new System.Drawing.Size(184, 75);
            this.Aktar.TabIndex = 9;
            this.Aktar.Text = "Verileri Aktar";
            this.Aktar.Click += new System.EventHandler(this.Aktar_Click);
            // 
            // cmb_txtDelimiter
            // 
            this.cmb_txtDelimiter.EditValue = ";";
            this.cmb_txtDelimiter.Location = new System.Drawing.Point(776, 141);
            this.cmb_txtDelimiter.Name = "cmb_txtDelimiter";
            this.cmb_txtDelimiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_txtDelimiter.Properties.Items.AddRange(new object[] {
            ";",
            "~"});
            this.cmb_txtDelimiter.Size = new System.Drawing.Size(67, 20);
            this.cmb_txtDelimiter.TabIndex = 105;
            // 
            // CSV2SQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 588);
            this.Controls.Add(this.cmb_txtDelimiter);
            this.Controls.Add(this.CSVGozat);
            this.Controls.Add(this.CSVFirstRowHeader);
            this.Controls.Add(this.cmbSQLServerName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCsvLoc);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Aktar);
            this.Controls.Add(this.dbGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTbl);
            this.Controls.Add(this.cmbDb);
            this.Controls.Add(this.csvGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CSV2SQL";
            this.Text = "CSV to SQL";
            this.Load += new System.EventHandler(this.CSV2SQL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.csvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.csvView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTbl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCsvLoc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSQLServerName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CSVFirstRowHeader.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_txtDelimiter.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl csvGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView csvView;
        private DevExpress.XtraEditors.ComboBoxEdit cmbDb;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl dbGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView dbView;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton Aktar;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtCsvLoc;
        private DevExpress.XtraEditors.ComboBoxEdit cmbSQLServerName;
        private DevExpress.XtraEditors.ToggleSwitch CSVFirstRowHeader;
        private DevExpress.XtraEditors.SimpleButton CSVGozat;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_txtDelimiter;
    }
}

