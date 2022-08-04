using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVtoSQL
{
    public partial class CSV2SQL : XtraForm
    {
        public CSV2SQL()
        {
            InitializeComponent();
        }
        SqlConnection con;
        string Conn;
        public static string DBServerFileName = "";
        bool CSVHEADEREXIST = true;

        private void CSV2SQL_Load(object sender, EventArgs e)
        {

            DBServerFileName = AppDomain.CurrentDomain.BaseDirectory + @"\..\BilsetData\dbServer.txt";

            if (File.Exists(DBServerFileName))
            {
                StreamReader sr = new StreamReader(DBServerFileName, Encoding.Default);

                string s = sr.ReadLine();
                while (s != null)
                {
                    cmbSQLServerName.Properties.Items.Add(s);
                    s = sr.ReadLine();
                }
                if (string.IsNullOrEmpty(cmbSQLServerName.Text))
                {
                    InstanceGetir();
                }
            }
            else
            {
                InstanceGetir();
            }

            cmbSQLServerName.SelectedIndex = 0;
            cmbSQLServerName.Focus();

            CSVGozat.Enabled = false;
            Aktar.Enabled = false;
        }
        private void InstanceGetir()
        {
            var instances = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow instance in instances.AsEnumerable())
            {
                if (instance["InstanceName"].ToString() != "")
                {
                    cmbSQLServerName.Properties.Items.Add(instance["ServerName"] + "\\" + instance["InstanceName"]);
                }
                else
                    cmbSQLServerName.Properties.Items.Add(instance["ServerName"]);
                cmbSQLServerName.SelectedIndex = 0;
            }
        }

        private void cmbSqlServerName_Leave(object sender, EventArgs e)
        {
            cmbDb.Properties.Items.Clear();
            try
            {
                SqlConnection SourceConnection1 = new SqlConnection($"Data Source ={cmbSQLServerName.Text}; Initial Catalog =BILSET_MASTER; Persist Security Info = True; User ID =bilset; Password = Bilset1234;");
                SourceConnection1.Open();

                //BILSET_MASTER'dan Firma Bilgilerini oku
                SqlCommand cmd = new SqlCommand("select DATABASE_ADI from FIRMA_HAR WHERE AKTIFMI=1", SourceConnection1);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cmbDb.Properties.Items.Add(rdr["DATABASE_ADI"].ToString());
                }
                rdr.Close();
                cmbDb.SelectedIndex = 0;
            }
            catch
            {
                XtraMessageBox.Show("BİLSET MASTER tablosuna bağlanamadı. \n\n Güvenlik Duvarı ayarlarını ve SQL Server'ın çalıştığını kontrol ediniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        string TableName;
        List<string> ColumnNames = new List<string>();
        private void cmbTbl_SelectedIndexChanged(object sender, EventArgs e)
        {

            dbView.Columns.Clear();
            DataTable DBTBL = new DataTable();
            switch (cmbTbl.SelectedItem.ToString())
            {
                case "Cari Sabit Tablosu":
                    TableName = "TBLCari";
                    break;
                case "Cari Hareket Tablosu":
                    TableName = "TBLCari_Hareket";
                    break;
                case "Stok Sabit Tablosu":
                    TableName = "TBLStok";
                    break;
                case "Stok Hareket Tablosu":
                    TableName = "TBLStok_Hareket";
                    break;
                case "Alış Faturası":
                    TableName = "TBLA_Fatura";
                    break;
                case "Satış Faturası":
                    TableName = "TBLS_Fatura";
                    break;
                case "Alış İrsaliyesi":
                    TableName = "TBLA_Irs";
                    break;
                case "Sevk İrsaliyesi":
                    TableName = "TBLS_Irs";
                    break;
                case "Borç Çekleri":
                    TableName = "TBLBCek_Har";
                    break;
                case "Müşteri Çekleri":
                    TableName = "TBLMCek_Har";
                    break;
                case "Borç Senetleri":
                    TableName = "TBLBSenet_Har";
                    break;
                case "Müşteri Senetleri":
                    TableName = "TBLMSenet_Har";
                    break;
                case "Kasa":
                    TableName = "TBLKasaHar";
                    break;
            }
            con.Close();
            con.ConnectionString = $"Data Source = {cmbSQLServerName.Text}; Initial Catalog ={cmbDb.Text}; Persist Security Info = True; User ID = bilset; Password = Bilset1234; ";
            con.Open();
            using (SqlCommand cmd = new SqlCommand("EXEC sp_columns '" + TableName + "'", con))
            {
                using (IDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ColumnNames.Add(dr["COLUMN_NAME"].ToString());
                    }
                }
            }
            for (int i = 0; i < ColumnNames.Count; i++)
            {
                DBTBL.Columns.Add(ColumnNames[i]);
            }

            CSVGozat.Enabled = true;
            dbGrid.DataSource = DBTBL;
            ColumnNames.Clear();
        }

        string CSVLoc;
        void FileLoc()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                CSVLoc = openFileDialog1.FileName;
            }
        }
        public DataTable ReadCsvFile(bool IsFirstRowHeader)
        {
            DataTable dtCsv = new DataTable();
            string Fulltext;
            using (StreamReader sr = new StreamReader(CSVLoc, Encoding.Default))
            {
                int i = 0;
                try
                {
                    while (!sr.EndOfStream)
                    {
                        Fulltext = sr.ReadLine().ToString(); //read full file text  

                        string[] rowValues = Fulltext.Split(cmb_txtDelimiter.Text.ToCharArray(0, 1)); //split each row with comma to get individual values  
                        {
                            if (i == 0)
                            {
                                if (IsFirstRowHeader)
                                {
                                    for (int j = 0; j < rowValues.Count(); j++)
                                    {
                                        dtCsv.Columns.Add(rowValues[j]); //add headers  
                                    }
                                }
                                else
                                {
                                    DataRow dr = dtCsv.NewRow();
                                    for (int j = 0; j < rowValues.Count(); j++)
                                    {
                                        dtCsv.Columns.Add("Kolon " + Convert.ToInt32(j + 1)); //add headers  
                                        dr[j] = rowValues[j].ToString();
                                    }
                                    dtCsv.Rows.Add(dr);
                                }
                            }
                            else
                            {
                                DataRow dr = dtCsv.NewRow();
                                for (int k = 0; k < rowValues.Count(); k++)
                                {
                                    dr[k] = rowValues[k].ToString();
                                }
                                dtCsv.Rows.Add(dr); //add other rows  
                            }
                        }
                        i++;
                    }

                    dtCsv.Locale = CultureInfo.CurrentCulture;
                    return dtCsv;
                }
                catch
                {
                    XtraMessageBox.Show($"Verilerin aktarıldığı kaynak CSV dosyasındaki {Convert.ToInt32(i + 1)}. kayıt sorunlu.\nLütfen kontrol ediniz!\n", "HATA");
                    return null;
                }
            }
        }
        private void Aktar_Click(object sender, EventArgs e)
        {
            if (csvView.VisibleColumns.Count != dbView.VisibleColumns.Count)
            {
                XtraMessageBox.Show("Grid Kolon sayıları aynı değil lütfen kontrol ediniz.");
                return;
            }
            string CommandText;
            CommandText = $"insert into {TableName}(";
            for (int i = 0; i < dbView.VisibleColumns.Count; i++)
            {
                if (i + 1 == dbView.VisibleColumns.Count)
                {
                    CommandText += dbView.VisibleColumns[i] + ") values ('";
                }
                else
                {
                    CommandText += dbView.VisibleColumns[i] + ",";
                }
            }
            string Values = CommandText;
            for (int i = 0; i < csvView.RowCount; i++)
            {
                for (int j = 0; j < csvView.VisibleColumns.Count; j++)
                {
                    if (j + 1 == csvView.VisibleColumns.Count)
                    {
                        Values += csvView.GetRowCellValue(i, csvView.VisibleColumns[j]) + "')";
                    }
                    else
                    {
                        Values += csvView.GetRowCellValue(i, csvView.VisibleColumns[j]) + "','";
                    }
                }
                SqlCommand cmd = new SqlCommand(Values,con);
                cmd.ExecuteNonQuery();
                Values = CommandText;
            }
            hareketIDEdit();
        }
        void hareketIDEdit()
        {
            SqlCommand komut;
            if (TableName == "TBLCari_Hareket")
            {
                string carihareket_cariid = "BEGIN TRANSACTION;  UPDATE TBLCari_Hareket  SET TBLCari_Hareket.cari_Id = (select TBLCari.cari_Id from TBLCari where TBLCari.cari_Kod = TBLCari_Hareket.cari_kod )  FROM TBLCari, TBLCari_Hareket  WHERE TBLCari.cari_Kod = TBLCari_Hareket.cari_kod; COMMIT; ";
                komut = new SqlCommand(carihareket_cariid, con);
                komut.ExecuteNonQuery();
            }

            else if (TableName == "TBLStok_Hareket")
            {
                string stokhareket_stokid = "BEGIN TRANSACTION; UPDATE TBLStok_Hareket  SET TBLStok_Hareket.stok_Id = (select TBLStok.stok_Id from TBLStok where TBLStok.stok_Kod = TBLStok_Hareket.stok_kod )  FROM TBLStok, TBLStok_Hareket  WHERE TBLStok.stok_Kod = TBLStok_Hareket.stok_kod; COMMIT; ";
                komut = new SqlCommand(stokhareket_stokid, con);
                komut.ExecuteNonQuery();
            }
        }
        private void csvView_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            csvView.IndicatorWidth = 50;

            if (e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
        }

        private void cmbDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> tables = new List<string>();
            Conn = "Data Source =" + cmbSQLServerName.Text + "; Initial Catalog =" + cmbDb.SelectedItem.ToString() + "; Persist Security Info = True; User ID =" + txtUserName.Text + "; Password = " + txtPass.Text + "; ";
            con = new SqlConnection(Conn);
            con.Open();
            DataTable dt = con.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }
            if (tables.Contains("TBLCari"))
            {
                cmbTbl.Properties.Items.Clear();
                cmbTbl.Properties.Items.Add("Cari Sabit Tablosu");
                cmbTbl.Properties.Items.Add("Cari Hareket Tablosu");
                cmbTbl.Properties.Items.Add("Stok Sabit Tablosu");
                cmbTbl.Properties.Items.Add("Stok Hareket Tablosu");
                cmbTbl.Properties.Items.Add("Alış Faturası");
                cmbTbl.Properties.Items.Add("Satış Faturası");
                cmbTbl.Properties.Items.Add("Alış İrsaliyesi");
                cmbTbl.Properties.Items.Add("Sevk İrsaliyesi");
                cmbTbl.Properties.Items.Add("Borç Çekleri");
                cmbTbl.Properties.Items.Add("Müşteri Çekleri");
                cmbTbl.Properties.Items.Add("Borç Senetleri");
                cmbTbl.Properties.Items.Add("Müşteri Senetleri");
                cmbTbl.Properties.Items.Add("Kasa");
                cmbTbl.SelectedIndex = 0;
            }
            else
            {
                cmbTbl.Properties.Items.Clear();
            }
        }

        private void CSVFirstRowHeader_Modified(object sender, EventArgs e)
        {
            CSVHEADEREXIST = CSVFirstRowHeader.IsOn ? true : false;
        }

        private void CSVGozat_Click(object sender, EventArgs e)
        {
            FileLoc();
            csvView.Columns.Clear();
            if (!string.IsNullOrEmpty(CSVLoc))
            {
                csvGrid.DataSource = ReadCsvFile(CSVHEADEREXIST);
                txtCsvLoc.Text = CSVLoc;
                Aktar.Enabled = true;
            }
        }
    }
}
