using Archive.BusinessObject;
using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace Archive
{
    public partial class FormPublisher : Telerik.WinControls.UI.RadForm
    {
        bool _isFirst;
        string _oldValue;
        public FormPublisher()
        {
            InitializeComponent();
        }

        private void radButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormPublisher_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {

            using (ArchiveEntities _context = new ArchiveEntities())
            {
                List<Publisher> list = _context.Publishers.ToList();
                radGridView1.DataSource = list;
            }
        }

        private void RemoveRecord(GridViewRowInfo currentRow)
        {
            using (ArchiveEntities _context = new ArchiveEntities())
            {
                try
                {
                    if (radGridView1.CurrentRow.Cells["PublisherId"].Value == null)
                    {
                        MessageBox.Show("شناسه یافت نشد");
                        return;
                    }

                    int PublisherId = int.Parse(radGridView1.CurrentRow.Cells["PublisherId"].Value.ToString());
                    var usageCount = _context.Publishers.Where(c => c.PublisherId == PublisherId).Count();
                    if (usageCount > 0)
                    {
                        MessageBox.Show("مقدار مورد نظر، در حال استفاده بوده و قابل حذف نیست");
                        return;
                    }
                    var Publisher = _context.Publishers.FirstOrDefault(x => x.PublisherId == PublisherId);
                    if (Publisher == null)
                    {
                        MessageBox.Show("در انجام عملیات، اشکالی رخ داده است");
                        return;
                    }
                    _context.Publishers.Remove(Publisher);
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
                    if (radGridView1.CurrentRow.Cells["PublisherTitle"].Value == null || radGridView1.CurrentRow.Cells["PublisherTitle"].Value.ToString() == "")
                    {
                        MessageBox.Show("مقدار صحیحی وارد نشده است");
                        return;
                    }
                    var sampleTitle = Common.Sample(radGridView1.CurrentRow.Cells["PublisherTitle"].Value.ToString());
                    var Publisher = new Publisher
                    {
                        PublisherTitle = radGridView1.CurrentRow.Cells["PublisherTitle"].Value.ToString(),
                        SamplePublisherTitle = sampleTitle
                    };
                    if (CheckExistance(sampleTitle))
                    {
                        MessageBox.Show("مورد تکراری");
                        //radGridView1.Rows.Remove(radGridView1.Rows[radGridView1.Rows.Count - 1]);
                        _isFirst = true;
                        radGridView1.CurrentRow.Cells["PublisherTitle"].Value = "";
                        _isFirst = false;
                        return;
                    }
                    _context.Publishers.Add(Publisher);
                    _context.SaveChanges();
                    _isFirst = true;
                    radGridView1.CurrentRow.Cells["PublisherId"].Value = Publisher.PublisherId;
                    radGridView1.CurrentRow.Cells["SamplePublisherTitle"].Value = sampleTitle;
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

        private bool CheckExistance(string sampleTitle)
        {
            using (ArchiveEntities _context = new ArchiveEntities())
            {
                var count = _context.Publishers.Where(x => x.SamplePublisherTitle == sampleTitle).Count();
                return (count > 0);
            }
        }

        private void UpdateRecord(GridViewRowInfo row)
        {
            try
            {
                var PublisherId = int.Parse(row.Cells["PublisherId"].Value.ToString());
                var sampleTitle = Common.Sample(row.Cells["PublisherTitle"].Value.ToString());
                if (sampleTitle == _oldValue)   //   مقدار تغییری نکرده است لذا نیازی به آپدیت نیست
                {
                    MessageBox.Show("تغییری برای به روز رسانی مشاهده نشد");
                    return;
                }

                if (CheckExistance(sampleTitle))
                {
                    MessageBox.Show("مورد تکراری");
                    return;
                }
                using (ArchiveEntities context = new ArchiveEntities())
                {
                    var Publisher = context.Publishers.FirstOrDefault(x => x.PublisherId == PublisherId);
                    Publisher.PublisherTitle = row.Cells["PublisherTitle"].Value.ToString();
                    context.SaveChanges();
                    _isFirst = true;
                    radGridView1.CurrentRow.Cells["SamplePublisherTitle"].Value = sampleTitle;
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
                if (radGridView1.CurrentRow.Cells["PublisherId"].Value == null)
                    AddRecord(radGridView1.CurrentRow);
                else
                    UpdateRecord(radGridView1.CurrentRow);
                return;
            }

            if (e.Column.Name.ToLower() == "remove")
            {
                RemoveRecord(radGridView1.CurrentRow);
                return;
            }
        }

        private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (!_isFirst && radGridView1.CurrentRow != null)
            {
                if (radGridView1.CurrentRow.Cells["PublisherId"].Value == null
                    || radGridView1.CurrentRow.Cells["PublisherId"].Value.ToString() == "0")
                    AddRecord(radGridView1.CurrentRow);
                else
                    UpdateRecord(radGridView1.CurrentRow);
            }
        }

        private void radGridView1_Enter(object sender, EventArgs e)
        {
            if (radGridView1.CurrentRow == null || radGridView1.CurrentRow.Cells["SamplePublisherTitle"].Value == null)
                return;
            _oldValue = radGridView1.CurrentRow.Cells["SamplePublisherTitle"].Value.ToString();
        }
    }
}
