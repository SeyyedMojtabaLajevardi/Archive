using System;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using Telerik.WinControls.UI;
using System.Web.UI.WebControls;
using System.Linq;

namespace Archive.BusinessObject
{
    public class Common
    {
        //public static string AttachmentMainPath = @"e:\Out_Project\Abutorab\AbutorabAttachment\";
        public static string AttachmentMainPath { get; set; }

        #region Method
        public static void SetInputLanguage(string languageCulture)
        {
            foreach (InputLanguage languages in InputLanguage.InstalledInputLanguages)
                if (languages.Culture.Name == languageCulture)
                    InputLanguage.CurrentInputLanguage = languages;
        }

        public string GetShamsiDate()
        {
            var persianCalendar = new PersianCalendar();

            var today = persianCalendar.GetYear(DateTime.Now) + "/";

            today += persianCalendar.GetMonth(DateTime.Now).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + "/";

            today += persianCalendar.GetDayOfMonth(DateTime.Now).ToString(CultureInfo.InvariantCulture).PadLeft(2, '0');
            return today;
        }

        public string GetShamsiDayOfWeek()
        {
            var persianCalendar = new PersianCalendar();
            var today = "";
            switch (persianCalendar.GetDayOfWeek(DateTime.Now).ToString())
            {
                case "Saturday":
                    today = "شنبه";
                    break;

                case "Sunday":
                    today = "یکشنبه";
                    break;

                case "Monday":
                    today = "دوشنبه";
                    break;

                case "Tuesday":
                    today = "سه شنبه";
                    break;

                case "Wednesday":
                    today = "چهارشنبه";
                    break;

                case "Thursday":
                    today = "پنجشنبه";
                    break;

                case "Friday":
                    today = "جمعه";
                    break;
            }
            return today;
        }

        public static string Sample(string strInput)
        {
            strInput = strInput.Replace('آ', 'ا');
            strInput = strInput.Replace('أ', 'ا');
            strInput = strInput.Replace('إ', 'ا');
            //strInput = strInput.Replace('ٱ', 'ا');
            strInput = strInput.Replace('ٲ', 'ا');
            strInput = strInput.Replace('ٳ', 'ا');
            strInput = strInput.Replace('ﺁ', 'ا');
            //strInput = strInput.Replace('ﺂ', 'ا');
            strInput = strInput.Replace('ﺃ', 'ا');
            //strInput = strInput.Replace('ﺄ', 'ا');
            strInput = strInput.Replace('ﺇ', 'ا');
            //strInput = strInput.Replace('ﺈ', 'ا');
            //strInput = strInput.Replace('ﺎ', 'ا');
            Regex rgxErab = new Regex(@"ًٌٍَُِّ");
            strInput = rgxErab.Replace(strInput, "");
            strInput = strInput.Replace("ً", string.Empty);
            strInput = strInput.Replace("ٌ", string.Empty);
            strInput = strInput.Replace("ٍ", string.Empty);
            strInput = strInput.Replace("َ", string.Empty);
            strInput = strInput.Replace("ُ", string.Empty);
            strInput = strInput.Replace("ِ", string.Empty);
            strInput = strInput.Replace("ّ", string.Empty);

            strInput = strInput.Replace('ة', 'ه');
            strInput = strInput.Replace('ۀ', 'ه');
            strInput = strInput.Replace('ہ', 'ه');
            strInput = strInput.Replace('ﺔ', 'ه');
            strInput = strInput.Replace('ؤ', 'و');
            strInput = strInput.Replace('ﺅ', 'و');
            strInput = strInput.Replace('ﺆ', 'و');
            strInput = strInput.Replace('ك', 'ک');
            strInput = strInput.Replace('ﻙ', 'ک');
            strInput = strInput.Replace('ئ', 'ی');
            strInput = strInput.Replace('ى', 'ی');
            strInput = strInput.Replace('ي', 'ی');
            strInput = strInput.Replace('ﺉ', 'ی');
            strInput = strInput.Replace('ﺊ', 'ی');
            return strInput;
        }

        public static string SampleForSort(string strInput)
        {
            strInput = strInput.Replace('ك', 'ک');
            strInput = strInput.Replace('ﻙ', 'ک');
            strInput = strInput.Replace('ئ', 'ی');
            strInput = strInput.Replace('ى', 'ی');
            strInput = strInput.Replace('ي', 'ی');
            strInput = strInput.Replace('ﺉ', 'ی');
            strInput = strInput.Replace('ﺊ', 'ی');
            return strInput;
        }

        public static void databaseFilePut(string varFilePath)
        {
            byte[] file;
            using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream))
                {
                    file = reader.ReadBytes((int)stream.Length);
                }
            }
            //using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
            //using (var sqlWrite = new SqlCommand("INSERT INTO Raporty (RaportPlik) Values(@File)", varConnection))
            //{
            //    sqlWrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
            //    sqlWrite.ExecuteNonQuery();
            //}
        }

        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable ConvertGridToDataTable(RadGridView grid, bool isFullColumns = false)
        {
            DataTable dt = new DataTable();
            int start = isFullColumns ? 1 : 2;
            for (int i = start; i < grid.Columns.Count - 1; i++)
            {
                dt.Columns.Add(grid.Columns[i].HeaderText);
            }
            foreach (var row in grid.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int j = start; j < grid.Columns.Count - 1; j++)
                {
                    dr[grid.Columns[j].HeaderText] = row.Cells[j].Value;
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }

        public static bool ValidationNumber(string str, Control control, out string message)
        {
            message = "";
            if (str == "") return true;
            if (!control.Enabled) return true;
            if (Regex.Replace(str, @"\d+", "").Length > 0)
            {
                message = "فقط مقادیر عددی مجاز هستند";
                return false;
            }
            if (control.Name.ToLower().ToLower().Contains("mellicode") && str.Length != 10)
            {
                message = "برای کد ملی، ده رقم باید وارد شود";
                return false;
            }
            return true;
        }

        public static void EmptyControls(System.Windows.Forms.Panel panelInformation)
        {
            var controls = GetAll(panelInformation);

            foreach (Control item in controls)
            {
                var type = item.GetType();
                if (type.Name.ToLower().Contains("text") || type.Name.ToLower().Contains("combo") || type.Name.ToLower().Contains("list"))
                    item.Text = "";
            }
        }
        private static IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl)).Concat(controls);
        }


        #endregion
    }
}
