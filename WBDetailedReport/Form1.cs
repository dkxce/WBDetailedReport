using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CsvHelper;
using System.Globalization;
using System.Runtime.InteropServices;
using static WBDetailedReport.Native;
using System.Net.Http;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace WBDetailedReport
{
    public partial class Form1 : Form
    {
        private DateTime currRun = DateTime.MinValue;
        private DateTime nextRun = DateTime.MinValue;
        private string taskPath = string.Empty;
        private string user = "0";

        public Form1()
        {
            InitializeComponent();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Form1_DragEnter);
            this.DragDrop += new DragEventHandler(Form1_DragDrop);
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (file.Contains("_ERR.json")) continue;
                string ext = Path.GetExtension(file).ToLower();
                if (ext == ".json")
                {
                    bool ex = false;
                    for (int i = 0; i < fileBox.Items.Count; i++)
                        if (((FileName)fileBox.Items[i]).path == file) ex = true;
                    if (!ex)
                     fileBox.Items.Add(new FileName(file));
                };
                if(ext == ".txt")
                {
                    LoadToken(file);
                    return;
                };
            };
            if (fileBox.Items.Count > 0)
            {
                fileBox.Sorted = true;
            };
            statusText.Text = "";
        }

        private void LoadToken(string file)
        {
            try
            {
                string key = File.ReadAllText(file);
                if (string.IsNullOrEmpty(key)) return;
                if (!key.StartsWith("ey")) return;
                tokenEdit.Text = key;
                UpdateHeader();
            }
            catch { };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string x = jsonToCSV();
        }

        public static DataTable JsonFileToDataTable(string fName = @"C:\Downloads\TEMP\xxx.json")
        {
            string fileDate = File.ReadAllText(fName);
            
            // fix empty dates
            fileDate = fileDate.Replace("\"fix_tariff_date_from\":\"\"", "\"fix_tariff_date_from\":null").Replace("\"fix_tariff_date_to\":\"\"", "\"fix_tariff_date_to\":null");
            
            DataTable dt = JsonConvert.DeserializeObject<DataTable>(fileDate);
            return dt;
        }

        public static string jsonToCSV()
        {
            StringWriter csvString = new StringWriter();
            using (var csv = new CsvHelper.CsvWriter(csvString,CultureInfo.InvariantCulture))
            {
                using (var dt = JsonFileToDataTable())
                {
                    foreach (DataColumn column in dt.Columns)
                    {
                        csv.WriteField(column.ColumnName);
                    }
                    csv.NextRecord();

                    foreach (DataRow row in dt.Rows)
                    {
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            csv.WriteField(row[i]);
                        }
                        csv.NextRecord();
                    }
                }
            }
            return csvString.ToString();
        }

        public string generateCipher()
        {
            Random rand = new Random();
            byte[] bytes = new byte[60];
            rand.NextBytes(bytes);
            string symPass = Convert.ToBase64String(bytes);
            int xl = symPass.Length;
            return symPass;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // generateCipher();
            try { tokenEdit.Text = File.ReadAllText(Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), "WBToken.txt")); } catch { };
            UpdateHeader();
        }

        private void UpdateHeader()
        {
            if (!tokenEdit.Text.StartsWith("ey"))
            {
                Text = $"WBDetailerReport";
                tInfo.Clear();
                return;
            };
            try
            {
                string payload = tokenEdit.Text.Split('.')[1];
                while (payload.Length % 4 != 0) payload += "=";
                byte[] data = Convert.FromBase64String(payload);
                string decodedString = System.Text.Encoding.UTF8.GetString(data);
                JObject jobj = JsonConvert.DeserializeObject<JObject>(decodedString);
                user = jobj["uid"].ToString();
                Text = $"WBDetailerReport: {user}";

                tInfo.Clear();
                tInfo.Text += $"id : {jobj["id"]?.ToString()} \r\n";
                tInfo.Text += $"iid: {jobj["iid"]?.ToString()} \r\n";
                tInfo.Text += $"oid: {jobj["oid"]?.ToString()} \r\n";
                tInfo.Text += $"s  : {jobj["s"]?.ToString()} \r\n";
                tInfo.Text += $"sid: {jobj["sid"]?.ToString()} \r\n";
                tInfo.Text += $"t  : {jobj["t"]?.ToString()} \r\n";
                tInfo.Text += $"uid: {jobj["uid"]?.ToString()} \r\n";
                string exp = UnixTimeStampToDateTime(double.Parse(jobj["exp"]?.ToString())).ToString("HH:mm:ss dd.MM.yyyy");
                tInfo.Text += $"exp: {exp} ({jobj["exp"]?.ToString()}) \r\n";

                Text += $" - (токен истекает {exp})";
            }
            catch { };
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }

        private void tokenEdit_Leave(object sender, EventArgs e)
        {
            tokenEdit.PasswordChar = '*';
        }

        private void tokenEdit_Enter(object sender, EventArgs e)
        {
            tokenEdit.PasswordChar = (char)0;
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            tokenEdit.Text = tokenEdit.Text.Trim();
            if (string.IsNullOrEmpty(tokenEdit.Text)) return;
            int totalDays = (int)(tillEdit.Value - fromEdit.Value).TotalDays + 1;
            if (totalDays <= 0) return;

            currRun = fromEdit.Value;
            nextRun = DateTime.UtcNow;
            SetLogText($"{DateTime.Now}: СТАРТ\r\n\r\n",true);            
            prepareDir();
            SetState(false);
            fileBox.Items.Clear();
        }

        private void prepareDir()
        {
            taskPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "T_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + $"_{user}");
            Directory.CreateDirectory(taskPath);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            doProc();
        }

        private void doProc()
        {
            // no run

            if (startBtn.Enabled) return;
            if (nextRun > DateTime.UtcNow) return;
            timer1.Enabled = false;

            // no sleep
            Native.SetThreadExecutionState(EXECUTION_STATE.ES_DISPLAY_REQUIRED);

            // prepare

            string fDate = currRun.ToString("yyyy-MM-dd");
            DateTime till = currRun.AddDays((int)daysEdit.Value - 1);
            if (till > tillEdit.Value) till = tillEdit.Value;
            string tDate = till.ToString("yyyy-MM-dd");

            string baseUrl = "https://statistics-api.wildberries.ru/api/v5/supplier/reportDetailByPeriod";
            string url = baseUrl + $"?dateFrom={fDate}&dateTo={tDate}&limit={maxEdit.Value}";
            string txt = $"{DateTime.Now}: {fDate} .. {tDate} :: {url} ... ";
            SetLogText($"{txt}");

            // processing url ++
            processUrl(url, tokenEdit.Text,$"{fDate}_{tDate}");
            // -- processing url

            txt = "";
            SetLogText($"{txt}\r\n\r\n");
            

            // next           
            nextRun = DateTime.UtcNow.AddSeconds((int)delayEdit.Value);
            currRun = currRun.AddDays((int)daysEdit.Value);
            if (currRun > tillEdit.Value)
            {
                stopBtn_Click(this, null);
            };
            timer1.Enabled = true;
        }

        private void processUrl(string url, string token, string fileName)
        {
            // 200, 400, 401, 429

            // File.Copy(@"C:\Downloads\TEMP\xxx.json", Path.Combine(taskPath, $"{fileName}.json"));
            // doLog("200 Ok\r\n");

            string responseString = null;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Authorization", token);
            try
            {
                int countOf = 0;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();                
                using (Stream stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                        responseString = reader.ReadToEnd();

                string s2 = "";
                if (!string.IsNullOrEmpty(responseString))
                {
                    countOf = Regex.Matches(responseString, "report_id").Count;
                    string fName = Path.Combine(taskPath, $"{fileName}.json");
                    File.WriteAllText(fName, responseString);
                    FileName fn = new FileName(fName);
                    fName = fn.ShortInfo();
                    s2 = $" --> {fName} [записей: {countOf}]";
                    Add2List(fn);
                };
                SetLogText($"{(int)response.StatusCode} {response.StatusDescription}{s2}\r\n");
            }
            catch (WebException we)
            {
                string ext = "txt";
                HttpWebResponse response = (HttpWebResponse)we.Response;
                if((response.ContentType != null) && response.ContentType.Contains("json")) ext = "json";
                using (Stream stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream))
                        responseString = reader.ReadToEnd();

                string s2 = "";
                if (!string.IsNullOrEmpty(responseString))
                {
                    string ff = $"{fileName}_ERR.{ext}";
                    File.WriteAllText(Path.Combine(taskPath, ff), responseString);
                    s2 = $" --> {ff}";

                    if (ext == "json")
                    {
                        try { s2 += " ---> `" + JsonConvert.DeserializeObject<JObject>(responseString)["detail"].ToString() + "`"; } catch { };
                        if (responseString.Contains("token problem")) currRun = currRun.AddYears(1);
                    };
                };
                SetLogText($"{(int)response.StatusCode} {response.StatusDescription}{s2}\r\n");

                // File.Copy(@"C:\Downloads\TEMP\xxx.json", Path.Combine(taskPath, $"{fileName}_CC.json"));
            }
            catch (Exception e)
            {
                SetLogText($"ERROR: {e}\r\n");
            };
        }

        private void Add2List(FileName fn)
        {
            bool ex = false;
            for (int i = 0; i < fileBox.Items.Count; i++)
                if (((FileName)fileBox.Items[i]).path == fn.path) ex = true;
            if (!ex)
                fileBox.Items.Add(fn);
        }

        private void SetLogText(string text, bool clear = false)
        {
            if (clear) logEdit.Clear();
            logEdit.Text += text;
            logEdit.SelectionStart = logEdit.TextLength;
            logEdit.ScrollToCaret();
            Application.DoEvents();
        }

        private void SetStatusText(string text)
        {
            statusText.Text = text;
            Application.DoEvents();
        }

        private void SetState(bool state)
        {
            tokenEdit.Enabled = fromEdit.Enabled = tillEdit.Enabled = daysEdit.Enabled = delayEdit.Enabled = maxEdit.Enabled = state;
            stopBtn.Enabled = !state;
            startBtn.Enabled = state;
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            string txt = $"{DateTime.Now}: СТОП";
            logEdit.Text += $"{txt}\r\n";
            SetState(true);
            File.WriteAllText(Path.Combine(taskPath, "log.txt"), logEdit.Text);
        }

        private void clsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileBox.Items.Clear();
            statusText.Text = "";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            clsBtn.Enabled = fileBox.Items.Count > 0;
            mrgBtn.Enabled = fileBox.Items.Count > 0;
        }

        private void mrgBtn_Click(object sender, EventArgs e)
        {
            if (fileBox.Items.Count == 0) return;

            string ofn = null;
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV Files (*.csv)|*.csv";
                sfd.DefaultExt = ".csv";
                if (sfd.ShowDialog() == DialogResult.OK) ofn = sfd.FileName;
                sfd.Dispose();
                if (string.IsNullOrEmpty(ofn)) return;
            };

            ulong ttlRecs = 0;
            SetStatusText($"Обработка {fileBox.Items.Count} файлов ...");

            FileStream fs = new FileStream(ofn, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);
            {
                using (CsvWriter csv = new CsvWriter(sw, CultureInfo.InvariantCulture))
                {
                    for (int iFile = 0; iFile < fileBox.Items.Count; iFile++)
                    {
                        SetStatusText($"Обработка {iFile + 1}/{fileBox.Items.Count} файла ...");
                        using (DataTable dt = JsonFileToDataTable(((FileName)fileBox.Items[iFile]).path))
                        {
                            if (iFile == 0)
                            {
                                SetStatusText($"Обработка {iFile + 1}/{fileBox.Items.Count} файла, заголовки ...");
                                foreach (DataColumn column in dt.Columns) csv.WriteField(column.ColumnName);
                                csv.NextRecord();
                            };

                            int iRow = 0;
                            foreach (DataRow row in dt.Rows)
                            {
                                if(iRow % 100 == 0)
                                    SetStatusText($"Обработка {iFile + 1}/{fileBox.Items.Count} файла, запись {iRow + 1}/{dt.Rows.Count} [{ttlRecs}  всего]...");
                                iRow++;

                                for (var iCol = 0; iCol < dt.Columns.Count; iCol++) csv.WriteField(row[iCol]);
                                csv.NextRecord();
                                ttlRecs++;
                            };
                            SetStatusText($"Обработка {iFile + 1}/{fileBox.Items.Count} файла, запись {iRow + 1}/{dt.Rows.Count} [{ttlRecs}  всего]...");
                        };
                    };
                };
            };
            sw.Close();
            fs.Close();

            string msg = $"Обработка {fileBox.Items.Count} файлов завершена: {ttlRecs} записей обработано";
            SetStatusText(msg);
            // if(ttlRecs > 0) fileBox.Items.Clear();
            MessageBox.Show(msg, "Обработка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);            
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath), "*.txt");
            if (files == null || files.Length == 0) return;

            fMenu.Items.Clear();
            foreach(string f in files)
                fMenu.Items.Add(Path.GetFileNameWithoutExtension(f)).Click += (ss, ee) => LoadToken(f);
            fMenu.Show(tabPage1.PointToScreen(new Point(bLoad.Location.X, bLoad.Location.Y + bLoad.Height)));
        }

    }

    public class FileName
    {
        public string path;

        public override string ToString()
        {
            FileInfo fi = new FileInfo(path);

            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = fi.Length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            };
            string result = String.Format("{0:0.##} {1}", len, sizes[order]);

            string txt = $"{fi.Name} \t\t{fi.Extension.ToUpper().Trim('.')}\t {result}";
            return txt;
        }

        public string ShortInfo()
        {
            FileInfo fi = new FileInfo(path);

            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            double len = fi.Length;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            };
            string result = String.Format("{0:0.##} {1}", len, sizes[order]);

            string txt = $"{fi.Name} {result}";
            return txt;
        }

        public FileName(string path) { this.path = path; }
    }

    public class Native
    {
        public enum EXECUTION_STATE : uint
        {
            ES_AWAYMODE_REQUIRED = 0x00000040,
            ES_CONTINUOUS = 0x80000000,
            ES_DISPLAY_REQUIRED = 0x00000002,
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);
    }

    public class CustomDateTimeJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer
        serializer)
        {
            // implement in case you're serializing it back
        }

        public override object ReadJson(JsonReader reader, Type objectType, object
          existingValue,
          JsonSerializer serializer)
        {
            string dateString = (string)reader.Value;
            // one way to handle empty/invalid dates
            return DateTime.TryParse(dateString, out var dateValue) ? dateValue : DateTime.MinValue;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
}
