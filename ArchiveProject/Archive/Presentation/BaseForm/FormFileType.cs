using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Archive
{
    public partial class FormFileType : Telerik.WinControls.UI.RadForm
    {
        bool _isFirst;
        string _oldValue;
        public FormFileType()
        {
            InitializeComponent();
        }

        private void radButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormFileType_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {

            using (ArchiveEntities _context = new ArchiveEntities())
            {
                List<FileType> list = _context.FileTypes.ToList();
                List<ContentType> contentTypeList = _context.ContentTypes.ToList();
                radGridViewFileType.DataSource = list;
                Telerik.WinControls.UI.GridViewComboBoxColumn comboBoxColumn = (Telerik.WinControls.UI.GridViewComboBoxColumn)radGridViewFileType.Columns["ContentTypeId"];

                comboBoxColumn.DataSource = contentTypeList;
                comboBoxColumn.DisplayMember = "ContentTypeTitle";
                comboBoxColumn.ValueMember = "contentTypeID";
            }
        }

        private void RemoveRecord(GridViewRowInfo currentRow)
        {
            using (ArchiveEntities _context = new ArchiveEntities())
            {
                try
                {
                    if (radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value == null)
                    {
                        MessageBox.Show("شناسه یافت نشد");
                        return;
                    }

                    int FileTypeId = int.Parse(radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value.ToString());
                    var usageCount = _context.Files.Where(c => c.FileTypeId == FileTypeId).Count();
                    if (usageCount > 0)
                    {
                        MessageBox.Show("مقدار مورد نظر، در حال استفاده بوده و قابل حذف نیست");
                        return;
                    }
                    var FileType = _context.FileTypes.FirstOrDefault(x => x.FileTypeId == FileTypeId);
                    if (FileType == null)
                    {
                        MessageBox.Show("در انجام عملیات، اشکالی رخ داده است");
                        return;
                    }
                    _context.FileTypes.Remove(FileType);
                    _context.SaveChanges();
                    //new FormMessage("عملیات با موفقیت انجام شد", FormMessage.MessageType.Information, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("موفق");
                }
                catch
                {
                    MessageBox.Show("عملیات حذف، امکان‌پذیر نیست");
                }
            }
            FillGrid();
        }

        private void AddRecord(GridViewRowInfo currentRow)
        {
            using (ArchiveEntities _context = new ArchiveEntities())
            {
                try
                {
                    if (radGridViewFileType.CurrentRow.Cells["FileTypeTitle"].Value == null || radGridViewFileType.CurrentRow.Cells["FileTypeTitle"].Value.ToString() == "")
                    {
                        MessageBox.Show("مقدار صحیحی برای نوع فایل وارد نشده است");
                        return;
                    }

                    if (radGridViewFileType.CurrentRow.Cells["ContentTypeId"].Value == null || radGridViewFileType.CurrentRow.Cells["ContentTypeId"].Value.ToString() == "")
                    {
                        MessageBox.Show("مقدار صحیحی برای نوع محتوا وارد نشده است");
                        return;
                    }

                    var FileType = new FileType
                    {
                        FileTypeTitle = radGridViewFileType.CurrentRow.Cells["FileTypeTitle"].Value.ToString(),
                        ContentTypeId = int.Parse(radGridViewFileType.CurrentRow.Cells["ContentTypeId"].Value.ToString()),
                        FileTypeTitlePersian = radGridViewFileType.CurrentRow.Cells["FileTypeTitlePersian"].Value?.ToString()
                    };
                    if (CheckExistance(FileType.FileTypeTitle, FileType.ContentTypeId.Value))
                    {
                        MessageBox.Show("مورد تکراری");
                        _isFirst = true;
                        radGridViewFileType.CurrentRow.Cells["FileTypeTitle"].Value = "";
                        _isFirst = false;
                        return;
                    }
                    _context.FileTypes.Add(FileType);
                    _context.SaveChanges();
                    _isFirst = true;
                    radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value = FileType.FileTypeId;
                    _isFirst = false;
                    //new FormMessage("عملیات با موفقیت انجام شد", FormMessage.MessageType.Information, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("موفق");
                    return;
                }
                catch
                {
                    MessageBox.Show(@"خطا");
                }
            }
        }

        private bool CheckExistance(string title, int contentTypeId)
        {
            using (ArchiveEntities _context = new ArchiveEntities())
            {
                var count = _context.FileTypes.Where(x => x.FileTypeTitle == title && x.ContentTypeId == contentTypeId).Count();
                return (count > 0);
            }
        }

        private void UpdateRecord(GridViewRowInfo row)
        {
            try
            {
                var FileTypeId = int.Parse(row.Cells["FileTypeId"].Value.ToString());
                var fileTypeTitle = row.Cells["FileTypeTitle"].Value.ToString();
                int.TryParse(row.Cells["ContentTypeId"].Value.ToString(), out int contentTypeId);
                if (fileTypeTitle == _oldValue)   //   مقدار تغییری نکرده است لذا نیازی به آپدیت نیست
                {
                    MessageBox.Show("تغییری برای به روز رسانی مشاهده نشد");
                    return;
                }
                if (CheckExistance(fileTypeTitle, contentTypeId))
                {
                    MessageBox.Show("مورد تکراری");
                    return;
                }
                using (ArchiveEntities context = new ArchiveEntities())
                {
                    var FileType = context.FileTypes.FirstOrDefault(x => x.FileTypeId == FileTypeId);
                    FileType.FileTypeTitle = row.Cells["FileTypeTitle"].Value.ToString();
                    FileType.ContentTypeId = int.Parse(row.Cells["ContentTypeId"].Value.ToString());
                    context.SaveChanges();
                    _isFirst = true;
                    radGridViewFileType.CurrentRow.Cells["FileTypeTitle"].Value = fileTypeTitle;
                    radGridViewFileType.CurrentRow.Cells["ContentTypeId"].Value = contentTypeId;
                    _isFirst = false;

                    //new FormMessage("عملیات با موفقیت انجام شد", FormMessage.MessageType.Information, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("موفق");
                }
            }
            catch (Exception)
            {
                //new FormMessage("در انجام فرایند خطایی رخ داده است", FormMessage.MessageType.Information, FormMessage.OutputType.Ok).ShowDialog();//new FormMessage("در انجام فرایند خطایی رخ داده است", FormMessage.MessageType.Information, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("خطا");
            }
        }

        private void radGridView1_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name.ToLower() == "confirm")
            {
                if (radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value == null)
                    AddRecord(radGridViewFileType.CurrentRow);
                else
                    UpdateRecord(radGridViewFileType.CurrentRow);
                return;
            }

            if (e.Column.Name.ToLower() == "remove")
            {
                RemoveRecord(radGridViewFileType.CurrentRow);
                return;
            }
        }

        private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            //if (!_isFirst && radGridViewFileType.CurrentRow != null)
            //{
            //    if (radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value == null
            //        || radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value.ToString() == "0")
            //        AddRecord(radGridViewFileType.CurrentRow);
            //    else
            //        UpdateRecord(radGridViewFileType.CurrentRow);
            //}
        }

        private void radGridView1_Enter(object sender, EventArgs e)
        {
            if (radGridViewFileType.CurrentRow == null || radGridViewFileType.CurrentRow.Cells["FileTypeTitle"].Value == null)
                return;
            _oldValue = radGridViewFileType.CurrentRow.Cells["FileTypeTitle"].Value.ToString();
        }

        private void radGridViewFileType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (!_isFirst && radGridViewFileType.CurrentRow != null)
            {
                if (radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value == null
                    || radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value.ToString() == "0")
                    AddRecord(radGridViewFileType.CurrentRow);
                else
                    UpdateRecord(radGridViewFileType.CurrentRow);
            }
        }

        private void radGridViewFileType_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            // اگر این متد باشد، هرکدام از فیلدها که تکمیل شود پیام میدهد که آن یکی تکمیکل نشده است
            /*            if (radGridViewFileType.CurrentRow.Cells["FileTypeTitle"].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show(@"نوع فایل مشخص نشده است");
                            return;
                        }

                        if (radGridViewFileType.CurrentRow.Cells["ContentTypeId"].Value == null
                            || radGridViewFileType.CurrentRow.Cells["ContentTypeId"].Value?.ToString().Trim() == "")

                        {
                            MessageBox.Show(@"نوع محتوا مشخص نشده است");
                            return;
                        }

                        if (radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value == null
                            || radGridViewFileType.CurrentRow.Cells["FileTypeId"].Value.ToString() == "0")
                            AddRecord(radGridViewFileType.CurrentRow);
                        else
                            UpdateRecord(radGridViewFileType.CurrentRow);*/
        }
    }
}
