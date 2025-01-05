using AbutorabAutomation.PresentationLayer.DateEntryForms;
using AbutorabAutomation.BLL;
using AbutorabAutomation.BO;
using AbutorabAutomation.Models;
using Dapper;
using Noor.Data;
using Noor.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace AbutorabAutomation.PresentationLayer.DateEntryForms
{
    public partial class FormArchive : Telerik.WinControls.UI.RadForm
    {
        private int _personId = 0, _id = 0;
        UserControlPerson userControlPerson = new UserControlPerson();
        public FormArchive(bool isViewOnly)
        {
            InitializeComponent();
            radPanel1.Controls.Add(userControlPerson);
            radPanel1.Controls[userControlPerson.Name].Dock = DockStyle.Fill;
            radGridView1.Columns["Remove"].IsVisible = !isViewOnly;
            radButtonEdit.Enabled = !isViewOnly;
            radButtonOk.Enabled = !isViewOnly;

            radButton1.Enabled = !isViewOnly;
            radButton4.Enabled = !isViewOnly;
        }

        #region افزودن یک رکورد جدید به دیتابیس
        private void radButtonOk_Click(object sender, EventArgs e)
        {
            if (_personId < 1)
            {
                new FormMessage("هیچ فردی انتخاب نشده است", FormMessage.MessageType.Error, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("هیچ فردی انتخاب نشده است");
                return;
            }
            try
            {

                int? interviewTypeId = null,
                    publishPermissionId = null,
                    adventureCompleteStateId = null,
                    MediaTypeId = null,
                    languageId = null,
                    bayanScoreId = null,
                    interviewScoreId = null;



                var subjects = radTextBoxSubjects.Text.Trim();

                if (radDropDownListInterviewType.SelectedItem != null && radDropDownListInterviewType.SelectedItem.Value.ToString() != "")
                    interviewTypeId = int.Parse(radDropDownListInterviewType.SelectedItem.Value.ToString());

                if (radDropDownListPublishPermission.SelectedItem != null && radDropDownListPublishPermission.SelectedItem.Value.ToString() != "")
                    publishPermissionId = int.Parse(radDropDownListPublishPermission.SelectedItem.Value.ToString());

                if (radDropDownListAdventureCompleteState.SelectedItem != null && radDropDownListAdventureCompleteState.SelectedItem.Value.ToString() != "")
                    adventureCompleteStateId = int.Parse(radDropDownListAdventureCompleteState.SelectedItem.Value.ToString());

                if (radDropDownListMediaType.SelectedItem != null && radDropDownListMediaType.SelectedItem.Value.ToString() != "")
                    MediaTypeId = int.Parse(radDropDownListMediaType.SelectedItem.Value.ToString());

                if (radDropDownListLanguage.SelectedItem != null && radDropDownListLanguage.SelectedItem.Value.ToString() != "")
                    languageId = int.Parse(radDropDownListLanguage.SelectedItem.Value.ToString());

                if (radDropDownListBayanScore.SelectedItem != null && radDropDownListBayanScore.SelectedItem.Value.ToString() != "")
                    bayanScoreId = int.Parse(radDropDownListBayanScore.SelectedItem.Value.ToString());

                if (radDropDownListInterviewScore.SelectedItem != null && radDropDownListInterviewScore.SelectedItem.Value.ToString() != "")
                    interviewScoreId = int.Parse(radDropDownListInterviewScore.SelectedItem.Value.ToString());
                //var interviewTypeId = radDropDownListInterviewType.SelectedItem != null && radDropDownListInterviewType.SelectedItem.Value.ToString() != ""
                //    ? int.Parse(radDropDownListInterviewType.SelectedItem.Value.ToString())
                //    : -1;
                //var publishPermissionId = radDropDownListPublishPermission.SelectedItem != null && radDropDownListPublishPermission.SelectedItem.Value.ToString() != ""
                //    ? int.Parse(radDropDownListPublishPermission.SelectedItem.Value.ToString())
                //    : -1;
                //var adventureCompleteStateId = radDropDownListAdventureCompleteState.SelectedItem != null && radDropDownListAdventureCompleteState.SelectedItem.Value.ToString() != ""
                //    ? int.Parse(radDropDownListAdventureCompleteState.SelectedItem.Value.ToString())
                //    : -1;
                //var MediaTypeId = radDropDownListMediaType.SelectedItem != null && radDropDownListMediaType.SelectedItem.Value.ToString() != ""
                //    ? int.Parse(radDropDownListMediaType.SelectedItem.Value.ToString())
                //    : -1;
                //var languageId = radDropDownListLanguage.SelectedItem != null && radDropDownListLanguage.SelectedItem.Value.ToString() != ""
                //    ? int.Parse(radDropDownListLanguage.SelectedItem.Value.ToString())
                //    : -1;
                //var bayanScoreId = radDropDownListBayanScore.SelectedItem != null && radDropDownListBayanScore.SelectedItem.Value.ToString() != ""
                //    ? int.Parse(radDropDownListBayanScore.SelectedItem.Value.ToString())
                //    : -1;
                //var interviewScoreId = radDropDownListInterviewScore.SelectedItem != null && radDropDownListInterviewScore.SelectedItem.Value.ToString() != ""
                //    ? int.Parse(radDropDownListInterviewScore.SelectedItem.Value.ToString())
                //    : -1;

                using (AbutorabEntities _context = new AbutorabEntities())
                {
                    Archive archive;
                    if (((Control)sender).Name.ToUpper().Contains("OK"))
                    {
                        archive = new Archive()
                        {
                            PersonId = _personId,
                            AdventureCompleteStateId = adventureCompleteStateId,
                            BayanScoreId = bayanScoreId,
                            InterviewScoreId = interviewScoreId,
                            LanguageId = languageId,
                            InterviewTypeId = interviewTypeId,
                            MediaTypeId = MediaTypeId,
                            PublishPermissionId = publishPermissionId,
                            Subjects = subjects
                        };
                        _context.Archives.Add(archive);
                    }
                    else if (((Control)sender).Name.ToUpper().Contains("EDIT"))
                    {
                        archive = _context.Archives.FirstOrDefault(r => r.ArchiveId == _id);
                        if (archive == null) return;
                        archive.PersonId = _personId;
                        archive.AdventureCompleteStateId = adventureCompleteStateId;
                        archive.BayanScoreId = bayanScoreId;
                        archive.InterviewScoreId = interviewScoreId;
                        archive.LanguageId = languageId;
                        archive.InterviewTypeId = interviewTypeId;
                        archive.MediaTypeId = MediaTypeId;
                        archive.PublishPermissionId = publishPermissionId;
                        archive.Subjects = subjects;
                    }
                    _context.SaveChanges();
                    new FormMessage("عملیات با موفقیت انجام شد", FormMessage.MessageType.Information, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("موفق");
                    FillGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion افزودن یک رکورد جدید به دیتابیس

        #region پرکردن اطلاعات پایه و گرید
        private void FormArchive_Load(object sender, EventArgs e)
        {
            //PanelInformation.Enabled = (_personId != 0);
            FillPrimaryInformation.FillInterviewType(radDropDownListInterviewType);
            FillPrimaryInformation.FillPublishPermission(radDropDownListPublishPermission);
            FillPrimaryInformation.FillMediaType(radDropDownListMediaType);
            FillPrimaryInformation.FillAdventureCompleteState(radDropDownListAdventureCompleteState);
            FillPrimaryInformation.FillScore(radDropDownListBayanScore);
            FillPrimaryInformation.FillLanguage(radDropDownListLanguage);
            FillPrimaryInformation.FillScore(radDropDownListInterviewScore);
            FillGrid();
            radDropDownListInterviewType.SelectedIndex = -1;
            radDropDownListPublishPermission.SelectedIndex = -1;
            radDropDownListMediaType.SelectedIndex = -1;
            radDropDownListAdventureCompleteState.SelectedIndex = -1;
            radDropDownListBayanScore.SelectedIndex = -1;
            radDropDownListLanguage.SelectedIndex = -1;
            radDropDownListInterviewScore.SelectedIndex = -1;
        }
        #endregion پرکردن اطلاعات پایه و گرید

        #region پرکردن گرید با اطلاعات موجود در دیتابیس
        List<ArchiveDTO> list = new List<ArchiveDTO>();
        private void FillGrid()
        {
            int index = 0;
            if (radGridView1.CurrentRow != null)
                index = radGridView1.CurrentRow.Index;
            list = GetInformation();
            radGridView1.DataSource = list;
            if (radGridView1.RowCount > 0) radGridView1.CurrentRow = radGridView1.Rows[index];
        }

        private List<ArchiveDTO> GetInformation()
        {
            using (AbutorabEntities context = new AbutorabEntities())
            {
                List<ArchiveDTO> archives = new List<ArchiveDTO>();
                using (var db = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    archives = db.Query<ArchiveDTO>("abutorab_GetArchive", commandType: CommandType.StoredProcedure).ToList();
                }

                //var archives = context.Database.SqlQuery<ArchiveDTO>("abutorab_GetArchive").ToList();
                return archives;
                //var archiveDtoList = archives.Select(x => new ArchiveDTO
                //{
                //    PersonId = _personId,
                //    ArchiveId = x.ArchiveId,
                //    PersonName = x.PersonName,
                //    AdventureCompleteStateTitle = x.AdventureCompleteStateTitle,
                //    BayanScore = x.BayanScore,
                //    InterviewScore = x.InterviewScore,
                //    InterviewTypeTitle = x.InterviewTypeTitle,
                //    LanguageTitle = x.LanguageTitle,
                //    MediaTypeTitle = x.MediaTypeTitle,
                //    PublishPermissionTitle = x.PublishPermissionTitle
                //}).ToList();
                //return archiveDtoList;
            }
        }
        #endregion پرکردن گرید با اطلاعات موجود در دیتابیس

        #region پرکردن باکسها جهت نمایش و به روز رسانی
        private void radGridView1_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e.CurrentRow == null)
                return;
            FillBoxes(e.CurrentRow);
        }

        private void FillBoxes(GridViewRowInfo row)
        {
            userControlPerson.radDropDownListLastName.Text = row.Cells["PersonName"] != null ? row.Cells["PersonName"].Value.ToString().Trim() : "";
            userControlPerson.radToggleSwitch1.Value = true;
            radButtonEdit.Enabled = true;
            _personId = int.Parse(row.Cells["PersonId"].Value.ToString());


            radDropDownListInterviewType.Text = row.Cells["InterviewTypeTitle"] != null && row.Cells["InterviewTypeTitle"].Value != null ? row.Cells["InterviewTypeTitle"].Value.ToString().Trim() : "";
            radDropDownListPublishPermission.Text = row.Cells["PublishPermissionTitle"] != null && row.Cells["PublishPermissionTitle"].Value != null ? row.Cells["PublishPermissionTitle"].Value.ToString().Trim() : "";
            radDropDownListAdventureCompleteState.Text = row.Cells["AdventureCompleteStateTitle"] != null && row.Cells["AdventureCompleteStateTitle"].Value != null ? row.Cells["AdventureCompleteStateTitle"].Value.ToString().Trim() : "";
            radDropDownListMediaType.Text = row.Cells["MediaTypeTitle"] != null && row.Cells["MediaTypeTitle"].Value != null ? row.Cells["MediaTypeTitle"].Value.ToString().Trim() : "";
            radDropDownListLanguage.Text = row.Cells["LanguageTitle"] != null && row.Cells["LanguageTitle"].Value != null ? row.Cells["LanguageTitle"].Value.ToString().Trim() : "";
            radDropDownListBayanScore.Text = row.Cells["BayanScore"] != null && row.Cells["BayanScore"].Value != null ? row.Cells["BayanScore"].Value.ToString().Trim() : "";
            radDropDownListInterviewScore.Text = row.Cells["InterviewScore"] != null && row.Cells["InterviewScore"].Value != null ? row.Cells["InterviewScore"].Value.ToString().Trim() : "";
            radTextBoxSubjects.Text = row.Cells["Subjects"].Value.ToString().Trim();
            _id = int.Parse(row.Cells["ArchiveId"].Value.ToString());

            try
            {
                userControlPerson._isFirst = true;
                userControlPerson.radDropDownListLastName.SelectedIndex = userControlPerson.radDropDownListLastName.FindStringExact(userControlPerson.radDropDownListLastName.Text);
                userControlPerson._isFirst = false;

                radDropDownListInterviewType.SelectedIndex = radDropDownListInterviewType.FindStringExact(radDropDownListInterviewType.Text);
                radDropDownListPublishPermission.SelectedIndex = radDropDownListPublishPermission.FindStringExact(radDropDownListPublishPermission.Text);
                radDropDownListAdventureCompleteState.SelectedIndex = radDropDownListAdventureCompleteState.FindStringExact(radDropDownListAdventureCompleteState.Text);
                radDropDownListMediaType.SelectedIndex = radDropDownListMediaType.FindStringExact(radDropDownListMediaType.Text);
                radDropDownListLanguage.SelectedIndex = radDropDownListLanguage.FindStringExact(radDropDownListLanguage.Text);
                radDropDownListBayanScore.SelectedIndex = radDropDownListBayanScore.FindStringExact(radDropDownListBayanScore.Text);
                radDropDownListInterviewScore.SelectedIndex = radDropDownListInterviewScore.FindStringExact(radDropDownListInterviewScore.Text);
            }
            catch
            {
            }
        }
        #endregion پرکردن باکسها جهت نمایش و به روز رسانی

        #region حذف اطلاعات
        private void radGridView1_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                _id = int.Parse(e.Row.Cells["ArchiveId"].Value.ToString());
                if (e.Column.Name.ToLower() != "remove")
                {
                    if (radGridView1.CurrentRow != null)
                        FillBoxes(radGridView1.CurrentRow);
                    return;
                }

                var formMessage = new FormMessage("آیا از حذف این رکورد اطمینان دارید؟", FormMessage.MessageType.Question, FormMessage.OutputType.YesNo);
                formMessage.ShowDialog();
                if (formMessage.Result.ToString().ToLower() == "no")
                    return;
                using (AbutorabEntities context = new AbutorabEntities())
                {
                    var archive = context.Archives.Where(x => x.ArchiveId == _id).FirstOrDefault();
                    context.Archives.Remove(archive);
                    context.SaveChanges();
                }
                radGridView1.Rows.RemoveAt(radGridView1.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper() != @"INPUT STRING WAS NOT IN A CORRECT FORMAT.")
                    new FormMessage("مقدار مورد نظر، در حال استفاده بوده و قابل حذف نیست", FormMessage.MessageType.Alarm, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("موفق");
            }
        }
        #endregion حذف اطلاعات

        private void radButtonSendToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                if (saveFileDialog1.ShowDialog() != DialogResult.OK) return;
                var filePath = saveFileDialog1.FileName;
                saveFileDialog1.Dispose();
                var dir = Path.GetDirectoryName(filePath);
                var fileName = Path.GetFileNameWithoutExtension(filePath) + ".xlsx";
                //DataTable dt = GetInformation().ToDataTable();
                var dt = Common.ConvertGridToDataTable(radGridView1);
                dt.ToExcel(dir, false, fileName);
                new FormMessage("فرایند انتقال به اکسل با موفقیت انجام شد", FormMessage.MessageType.Information, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("فرایند انتقال به اکسل با موفقیت انجام شد");
            }
            catch
            {
                new FormMessage("فرایند انتقال به اکسل با شکست مواجه شد", FormMessage.MessageType.Error, FormMessage.OutputType.Ok).ShowDialog();//MessageBox.Show("فرایند انتقال به اکسل با شکست مواجه شد");
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            FormInterviewType frm = new FormInterviewType() { StartPosition = FormStartPosition.CenterScreen };
            frm.ShowDialog();
            FillPrimaryInformation.FillInterviewType(radDropDownListInterviewType);
        }

        private void radButton4_Click(object sender, EventArgs e)
        {
            FormMediaType frm = new FormMediaType() { StartPosition = FormStartPosition.CenterScreen };
            frm.ShowDialog();
            FillPrimaryInformation.FillMediaType(radDropDownListMediaType);
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            var searchText = Common.Sample(TextBoxSearch.Text.Trim());
            if (searchText == "")
            {
                radGridView1.DataSource = list;
                return;
            }
            var searchList = list.Where(x => x.SamplePersonName.Contains(searchText)).ToList();
            radGridView1.DataSource = searchList;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (userControlPerson.PersonId != 0 && userControlPerson.PersonId != _personId)
            {
                _personId = userControlPerson.PersonId;
                PanelInformation.Enabled = true;
                if (!userControlPerson.radToggleSwitch1.Value)
                {
                    Common.EmptyControls(PanelInformation);
                    radButtonEdit.Enabled = false;
                }
            }
        }
    }
}
