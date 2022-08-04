using DevExpress.Data.Mask;
using DevExpress.Utils.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con;
        string Conn;
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(Application.StartupPath + "\\..\\BilsetData\\dbServer.txt", Encoding.Default);
            txtServer.Text = sr.ReadLine();
            button1.Enabled = false;
            button2.Enabled = false;
        }
        string TableName;
        List<string> ColumnNames = new List<string>();
        private void cmbTbl_SelectedIndexChanged(object sender, EventArgs e)
        {

            dbView.Columns.Clear();
            DataTable DBTBL = new DataTable();
            if (cmbTbl.SelectedItem.ToString() == "Cari Tablosu")
            {
                TableName = "TBLCari";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Cari Hareket Tablosu")
            {
                TableName = "TBLCari_Hareket";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Stok Tablosu")
            {
                TableName = "TBLStok";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Stok Hareket Tablosu")
            {
                TableName = "TBLStok_Hareket";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Alış Faturası")
            {
                TableName = "TBLA_Fatura";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Satış Faturası")
            {
                TableName = "TBLS_Fatura";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Alış İrsaliyesi")
            {
                TableName = "TBLA_Irs";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Sevk İrsaliyesi")
            {
                TableName = "TBLS_Irs";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Borç Çek Hareket Tablosu")
            {
                TableName = "TBLBSenet_Har";
            }
            else if (cmbTbl.SelectedItem.ToString() == "Müşteri Çek Hareket Tablosu")
            {
                TableName = "TBLMSenet_Har";
            }
            else
            {
                TableName = "TBLKasaHar";
            }
            con.Close();
            con.ConnectionString = "Data Source =.\\SQLEXPRESS; Initial Catalog =" + cmbDb.SelectedText + "; Persist Security Info = True; User ID = bilset; Password = Bilset1234; ";
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
                DBTBL.Columns.Add(ColumnNames[i].ToString());
            }
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
        private void button1_Click(object sender, EventArgs e)
        {
            FileLoc();
            csvView.Columns.Clear();
            if (!string.IsNullOrEmpty(CSVLoc))
            {
                csvGrid.DataSource = ReadCsvFile(CSVHEADEREXIST);
                txtCsvLoc.Text = CSVLoc;
            }
        }
        void createIni()
        {
            string path = Path.GetDirectoryName(CSVLoc) + "\\Schema.ini";

            // This text is added only once to the file.

            // Create a file to write to.
            string createText = "[" + Path.GetFileName(CSVLoc) + "]" + Environment.NewLine;
            string addSetting = "Format=Delimited(" + txtDelimiter.Text + ")";
            File.WriteAllText(path, createText);
            File.AppendAllText(path, addSetting);
        }
        static DataTable GetDataTableFromCsv(string path, bool isFirstRowHeader)
        {
            string header = isFirstRowHeader ? "Yes" : "No";

            string pathOnly = Path.GetDirectoryName(path);
            string fileName = Path.GetFileName(path);

            string sql = @"SELECT * FROM [" + fileName + "]";

            using (OleDbConnection connection = new OleDbConnection(
                      @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathOnly +
                      ";Extended Properties=\"Text;HDR=" + header + "\""))
            using (OleDbCommand command = new OleDbCommand(sql, connection))
            using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                dataTable.Locale = CultureInfo.CurrentCulture;
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public DataTable ConvertCSVtoDataTable(string strFilePath, bool isFirstRowHeader)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(txtDelimiter.Text.ToCharArray(0, 1));
            DataTable dt = new DataTable();
            if (isFirstRowHeader)
            {
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
            }

            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                dt.Locale = CultureInfo.CurrentCulture;
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable ReadCsvFile2(bool IsFirstRowHeader)
        {

            DataTable dtCsv = new DataTable();
            dtCsv.Locale = CultureInfo.CurrentCulture;
            string Fulltext;
            using (StreamReader sr = new StreamReader(CSVLoc))
            {
                while (!sr.EndOfStream)
                {
                    Fulltext = sr.ReadToEnd().ToString(); //read full file text  
                    string[] rows = Fulltext.Split('\n'); //split full file text into rows  
                    for (int i = 0; i < rows.Count() - 1; i++)
                    {
                        string[] rowValues = rows[i].Split(txtDelimiter.Text.ToCharArray(0, 1)); //split each row with comma to get individual values  
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
                                    for (int j = 0; j < rowValues.Count(); j++)
                                    {
                                        int c = Convert.ToInt32(j + 1);
                                        dtCsv.Columns.Add("Column " + c); //add headers  
                                        DataRow dr = dtCsv.NewRow();
                                        dr[j] = rowValues[j].ToString();
                                    }
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
                    }
                }
            }

            dtCsv.Locale = CultureInfo.CurrentCulture;
            return dtCsv;
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

                        string[] rowValues = Fulltext.Split(txtDelimiter.Text.ToCharArray(0, 1)); //split each row with comma to get individual values  
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
                    MessageBox.Show("Verilerin aktarıldığı kaynak dosyadaki bir kaydınız bozuk.\nLütfen kontrol ediniz!", Convert.ToInt32(i + 1) + ". kayıt sorunlu");
                    return null;
                }
            }
        }
        bool CSVHEADEREXIST = true;
        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.SelectedText == "Evet")
            {
                CSVHEADEREXIST = true;
            }
            else { CSVHEADEREXIST = false; }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPass.Enabled == true && txtServer.Enabled == true && txtUserName.Enabled == true)
            {
                MessageBox.Show("Lütfen aktarımı başlatmadan önce SQL'e bağlanınız.");
                return;
            }
            if (csvView.VisibleColumns.Count != dbView.VisibleColumns.Count)
            {
                MessageBox.Show("Grid Kolon sayıları aynı değil lütfen kontrol ediniz.");
                return;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
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
            //DataTable dt = gridControl1.DataSource as DataTable;
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
                MessageBox.Show(Values);
                Values = CommandText;
                MessageBox.Show(Values);
            }
            //cmd.CommandText = $"insert into{cmbTbl.SelectedText}(ogrenci_no,ogrenci_ad,ogrenci_soyad,ogrenci_sehir) values ('{}','{}','{}','{}')";
            //cmd.ExecuteNonQuery();
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
            Conn = "Data Source =" + txtServer.Text + "; Initial Catalog =" + cmbDb.SelectedItem.ToString() + "; Persist Security Info = True; User ID =" + txtUserName.Text + "; Password = " + txtPass.Text + "; ";
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
                cmbTbl.Properties.Items.Add("Cari Tablosu");
                cmbTbl.Properties.Items.Add("Cari Hareket Tablosu");
                cmbTbl.Properties.Items.Add("Stok Tablosu");
                cmbTbl.Properties.Items.Add("Stok Hareket Tablosu");
                cmbTbl.Properties.Items.Add("Alış Faturası");
                cmbTbl.Properties.Items.Add("Satış Faturası");
                cmbTbl.Properties.Items.Add("Alış İrsaliyesi");
                cmbTbl.Properties.Items.Add("Sevk İrsaliyesi");
                cmbTbl.Properties.Items.Add("Borç Çek Hareket Tablosu");
                cmbTbl.Properties.Items.Add("Müşteri Çek Hareket Tablosu");
                cmbTbl.Properties.Items.Add("Kasa Hareket Tablosu");
            }
            else
            {
                cmbTbl.Properties.Items.Clear();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                Conn = "Data Source =" + txtServer.Text + "; Initial Catalog =BILSET_MASTER; Persist Security Info = True; User ID =" + txtUserName.Text + "; Password = " + txtPass.Text + "; ";
                con = new SqlConnection(Conn);
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            i++;
                            if (i > 4)
                            {
                                cmbDb.Properties.Items.Add(dr[0].ToString());
                            }
                        }
                    }
                }
                if (cmbDb.Properties.Items.Count > 1)
                {
                    MessageBox.Show("SQL'e bağlantı sağlandı.", "Başarılı.");
                    txtServer.Enabled = false;
                    txtUserName.Enabled = false;
                    txtPass.Enabled = false;
                    button3.Enabled = false;
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
