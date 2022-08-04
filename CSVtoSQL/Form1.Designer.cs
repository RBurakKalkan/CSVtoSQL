namespace CSVtoSQL
{
    partial class Form1
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
            this.csvGrid = new DevExpress.XtraGrid.GridControl();
            this.csvView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cmbDb = new DevExpress.XtraEditors.ComboBoxEdit();
            this.cmbTbl = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dbGrid = new DevExpress.XtraGrid.GridControl();
            this.dbView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txtServer = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCsvLoc = new DevExpress.XtraEditors.TextEdit();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.csvGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.csvView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTbl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCsvLoc.Properties)).BeginInit();
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
            this.csvGrid.Size = new System.Drawing.Size(796, 309);
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
            this.cmbDb.Location = new System.Drawing.Point(112, 90);
            this.cmbDb.Name = "cmbDb";
            this.cmbDb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDb.Size = new System.Drawing.Size(100, 20);
            this.cmbDb.TabIndex = 1;
            this.cmbDb.SelectedIndexChanged += new System.EventHandler(this.cmbDb_SelectedIndexChanged);
            // 
            // cmbTbl
            // 
            this.cmbTbl.Location = new System.Drawing.Point(112, 116);
            this.cmbTbl.Name = "cmbTbl";
            this.cmbTbl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTbl.Size = new System.Drawing.Size(172, 20);
            this.cmbTbl.TabIndex = 1;
            this.cmbTbl.SelectedIndexChanged += new System.EventHandler(this.cmbTbl_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "SQL Veri Tabanı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "SQL Tablosu :";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(733, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "CSV Gözat";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDelimiter
            // 
            this.txtDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDelimiter.Location = new System.Drawing.Point(652, 136);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(75, 20);
            this.txtDelimiter.TabIndex = 4;
            this.txtDelimiter.Text = ";";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(562, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ayraç :";
            // 
            // dbGrid
            // 
            this.dbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbGrid.Location = new System.Drawing.Point(12, 168);
            this.dbGrid.MainView = this.dbView;
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.Size = new System.Drawing.Size(796, 22);
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
            // comboBoxEdit1
            // 
            this.comboBoxEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxEdit1.EditValue = "Evet";
            this.comboBoxEdit1.Location = new System.Drawing.Point(708, 108);
            this.comboBoxEdit1.Name = "comboBoxEdit1";
            this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "Evet",
            "Hayır"});
            this.comboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.comboBoxEdit1.TabIndex = 8;
            this.comboBoxEdit1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEdit1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(562, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "CSV nin ilk satırı header mı ?";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(428, 139);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Aktar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(112, 12);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(172, 20);
            this.txtServer.TabIndex = 10;
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
            this.txtUserName.Location = new System.Drawing.Point(112, 38);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(100, 20);
            this.txtUserName.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "SQL Kullanıcı Adı :";
            // 
            // txtPass
            // 
            this.txtPass.EditValue = "Bilset1234";
            this.txtPass.Location = new System.Drawing.Point(112, 64);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.UseSystemPasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Şifre :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 143);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "CSV Dosya yolu :";
            // 
            // txtCsvLoc
            // 
            this.txtCsvLoc.Enabled = false;
            this.txtCsvLoc.Location = new System.Drawing.Point(112, 140);
            this.txtCsvLoc.Name = "txtCsvLoc";
            this.txtCsvLoc.Size = new System.Drawing.Size(310, 20);
            this.txtCsvLoc.TabIndex = 10;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(428, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Bağlan";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 517);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCsvLoc);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxEdit1);
            this.Controls.Add(this.dbGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDelimiter);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTbl);
            this.Controls.Add(this.cmbDb);
            this.Controls.Add(this.csvGrid);
            this.Name = "Form1";
            this.Text = "CSV to SQL";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.csvGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.csvView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTbl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCsvLoc.Properties)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.GridControl dbGrid;
        private DevExpress.XtraGrid.Views.Grid.GridView dbView;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.TextEdit txtServer;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtCsvLoc;
        private System.Windows.Forms.Button button3;
    }
}

