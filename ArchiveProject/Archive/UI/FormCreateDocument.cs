using Archive.BLL;
using Archive.BLL.Enumerations;
using Archive.DAL;
using Archive.DAL.Dto;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Archive
{
    public partial class FormCreateDocument : Form
    {
        private readonly ArchiveService _archiveService;
        private List<PermissionType> _permissionTypes = new List<PermissionType>();
        private List<PermissionState> _permissionStates = new List<PermissionState>();
        private List<Subject> _subjects = new List<Subject>();
        private List<PublishState> _publishStates = new List<PublishState>();
        private List<Category> _mainCategories = new List<Category>();
        private List<Category> _categories1 = new List<Category>();
        private List<Category> _categories2 = new List<Category>();
        private List<Collection> _collections = new List<Collection>();
        private List<PadidAvar> _padidAvars = new List<PadidAvar>();
        private List<Language> _languages = new List<Language>();
        private List<FileType> _fileTypes = new List<FileType>();
        private bool _isFirst = false;
        private ContentType _contentType = null;
        private FileType _fileType = null;
        private int _mainCategoryId,
            _firstCategoryId,
            _secondCategoryId,
            _permissionStateId,
            _padidAvarId,
            _languageId,
            _publishStateId,
            _documentId,
            _fileTypeId,
            _contentId;
        private string _fileTypeTitle = "";
        private string _resourceTitle = "";
        //Enums enums = new Enums();

        public FormCreateDocument(int mainCategoryId)
        {
            InitializeComponent();
            _mainCategoryId = mainCategoryId;
            _archiveService = new ArchiveService(new ArchiveEntities());
            var width = (ToolStripContentType.Width / 4) - 10;
            ToolStripButtonSound.Width = width;
            ToolStripButtonText.Width = width;
            ToolStripButtonImage.Width = width;
            ToolStripButtonVideo.Width = width;
        }

        public FormCreateDocument()
        {
            this.SuspendLayout();
            InitializeComponent();
            this.ResumeLayout();
            _archiveService = new ArchiveService(new ArchiveEntities());
            var width = (ToolStripContentType.Width / 4) - 10;
            ToolStripButtonSound.Width = width;
            ToolStripButtonText.Width = width;
            ToolStripButtonImage.Width = width;
            ToolStripButtonVideo.Width = width;
        }

        private void FormCreateDocumentSpeach_Load(object sender, EventArgs e)
        {
            //Thread th = new Thread(ControlConfiguration);
            //th.Start();
            _isFirst = true;
            _permissionStates = _archiveService.FillPermissionState();
            _padidAvars = _archiveService.FillPadidAvar();
            _permissionTypes = _archiveService.FillPermissionType();
            _subjects = _archiveService.FillSubject();
            _publishStates = _archiveService.FillPublishState();
            _collections = _archiveService.FillCollection();
            _mainCategories = _archiveService.FillCategory(null, 1);
            _fileTypes = _archiveService.FillFileType();
            _languages = _archiveService.FillLanguage();

            ComboBoxPermissionState.DataSource = _permissionStates;
            ComboBoxPermissionState.DisplayMember = "PermissionStateTitle";
            ComboBoxPermissionState.ValueMember = "PermissionStateId";
            ComboBoxPermissionState.Text = "انتخاب کنید";

            ComboBoxPadidAvar.DataSource = _padidAvars;
            ComboBoxPadidAvar.DisplayMember = "PadidAvarTitle";
            ComboBoxPadidAvar.ValueMember = "PadidAvarId";
            ComboBoxPadidAvar.Text = "انتخاب کنید";

            ComboBoxLanguage.DataSource = _languages;
            ComboBoxLanguage.DisplayMember = "LanguageTitle";
            ComboBoxLanguage.ValueMember = "LanguageId";
            ComboBoxLanguage.Text = "انتخاب کنید";

            ComboBoxMainCategory.DataSource = _mainCategories;
            ComboBoxMainCategory.DisplayMember = "CategoryTitle";
            ComboBoxMainCategory.ValueMember = "CategoryId";
            ComboBoxMainCategory.Text = "انتخاب کنید";
            if (_mainCategoryId > 0)
            {
                var category = _mainCategories.Where(x => x.CategoryId == _mainCategoryId).FirstOrDefault();
                ComboBoxMainCategory.SelectedIndex = category == null ? -1 : category.CategoryId - 1;
                _categories1 = _archiveService.FillCategory(category.CategoryId, 2);
                ComboBoxCategory1.DataSource = _categories1;
                ComboBoxCategory1.DisplayMember = "CategoryTitle";
                ComboBoxCategory1.ValueMember = "CategoryId";
                ComboBoxCategory1.Text = "انتخاب کنید";
            }

            //ComboBoxCollection.DataSource = _collections;
            //ComboBoxCollection.DisplayMember = "CollectionTitle";
            //ComboBoxCollection.ValueMember = "CollectionId";
            //ComboBoxCollection.Text = "انتخاب کنید";

            ComboBoxPublishState.DataSource = _publishStates;
            ComboBoxPublishState.DisplayMember = "PublishStateTitle";
            ComboBoxPublishState.ValueMember = "PublishStateId";
            ComboBoxPublishState.Text = "انتخاب کنید";

            ComboBoxFileType.DataSource = _fileTypes;
            ComboBoxFileType.DisplayMember = "FileTypeTitle";
            ComboBoxFileType.ValueMember = "FileTypeId";
            ComboBoxFileType.Text = "انتخاب کنید";

            //ComboBoxEditor.DataSource = _editors;
            //ComboBoxEditor.DisplayMember = "EditorTitle";
            //ComboBoxEditor.ValueMember = "EditorId";
            //ComboBoxEditor.Text = "انتخاب کنید";

            _isFirst = false;
        }

        private void ControlConfiguration()
        {
            _isFirst = true;
            _permissionStates = _archiveService.FillPermissionState();
            _padidAvars = _archiveService.FillPadidAvar();
            _permissionTypes = _archiveService.FillPermissionType();
            _subjects = _archiveService.FillSubject();
            _publishStates = _archiveService.FillPublishState();
            _collections = _archiveService.FillCollection();
            _mainCategories = _archiveService.FillCategory(null, 1);
            _fileTypes = _archiveService.FillFileType();

            ComboBoxPermissionState.DataSource = _permissionStates;
            ComboBoxPermissionState.DisplayMember = "PermissionStateTitle";
            ComboBoxPermissionState.ValueMember = "PermissionStateId";
            ComboBoxPermissionState.Text = "انتخاب کنید";

            ComboBoxPadidAvar.DataSource = _padidAvars;
            ComboBoxPadidAvar.DisplayMember = "PadidAvarTitle";
            ComboBoxPadidAvar.ValueMember = "PadidAvarId";
            ComboBoxPadidAvar.Text = "انتخاب کنید";

            ComboBoxMainCategory.DataSource = _mainCategories;
            ComboBoxMainCategory.DisplayMember = "CategoryTitle";
            ComboBoxMainCategory.ValueMember = "CategoryId";
            ComboBoxMainCategory.Text = "انتخاب کنید";
            if (_mainCategoryId > 0)
            {
                var category = _mainCategories.Where(x => x.CategoryId == _mainCategoryId).FirstOrDefault();
                ComboBoxMainCategory.SelectedIndex = category == null ? -1 : category.CategoryId - 1;
                _categories1 = _archiveService.FillCategory(category.CategoryId, 2);
                ComboBoxCategory1.DataSource = _categories1;
                ComboBoxCategory1.DisplayMember = "CategoryTitle";
                ComboBoxCategory1.ValueMember = "CategoryId";
                ComboBoxCategory1.Text = "انتخاب کنید";
            }

            //ComboBoxCollection.DataSource = _collections;
            //ComboBoxCollection.DisplayMember = "CollectionTitle";
            //ComboBoxCollection.ValueMember = "CollectionId";
            //ComboBoxCollection.Text = "انتخاب کنید";

            ComboBoxPublishState.DataSource = _publishStates;
            ComboBoxPublishState.DisplayMember = "PublishStateTitle";
            ComboBoxPublishState.ValueMember = "PublishStateId";
            ComboBoxPublishState.Text = "انتخاب کنید";

            ComboBoxFileType.DataSource = _fileTypes;
            ComboBoxFileType.DisplayMember = "FileTypeTitle";
            ComboBoxFileType.ValueMember = "FileTypeId";
            ComboBoxFileType.Text = "انتخاب کنید";

            //ComboBoxEditor.DataSource = _editors;
            //ComboBoxEditor.DisplayMember = "EditorTitle";
            //ComboBoxEditor.ValueMember = "EditorId";
            //ComboBoxEditor.Text = "انتخاب کنید";

            _isFirst = false;
        }

        private void ToolStripButtonSound_Click(object sender, EventArgs e)
        {
            SetButtonState(ToolStripButtonSound, ConentTypeEnum.Sound);
        }

        private void ToolStripButtonText_Click(object sender, EventArgs e)
        {
            SetButtonState(ToolStripButtonText, ConentTypeEnum.Text);
        }

        private void ToolStripButtonImage_Click(object sender, EventArgs e)
        {
            SetButtonState(ToolStripButtonImage, ConentTypeEnum.Image);
        }

        private void ToolStripButtonVideo_Click(object sender, EventArgs e)
        {
            SetButtonState(ToolStripButtonVideo, ConentTypeEnum.Video);
        }

        private void ComboBoxPermissionState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            int.TryParse(ComboBoxPermissionState.SelectedValue?.ToString(), out _permissionStateId);
            _permissionStateId = ((PermissionState)ComboBoxPermissionState.SelectedItem).PermissionStateId;
            var permissionLeveTitle = ((PermissionState)ComboBoxPermissionState.SelectedItem).PermissionStateTitle;

        }

        private void ComboBoxCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            //int.TryParse(ComboBoxCategory1.SelectedValue?.ToString(), out _FirstcategoryId);
            _firstCategoryId = ((Category)ComboBoxCategory1.SelectedItem).CategoryId;
            var categoryTitle = ((Category)ComboBoxCategory1.SelectedItem).CategoryTitle;

            _categories2 = _archiveService.FillCategory(_firstCategoryId, 2);
            ComboBoxCategory2.DataSource = _categories2;
            ComboBoxCategory2.DisplayMember = "CategoryTitle";
            ComboBoxCategory2.ValueMember = "CategoryId";
            ComboBoxCategory2.Text = "انتخاب کنید";
        }

        private void ComboBoxMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            _mainCategoryId = ((Category)ComboBoxMainCategory.SelectedItem).CategoryId;
            var categoryTitle = ((Category)ComboBoxMainCategory.SelectedItem).CategoryTitle;

            _categories1 = _archiveService.FillCategory(_mainCategoryId, 2);
            ComboBoxCategory1.DataSource = _categories1;
            ComboBoxCategory1.DisplayMember = "CategoryTitle";
            ComboBoxCategory1.ValueMember = "CategoryId";
            ComboBoxCategory1.Text = "انتخاب کنید";
        }

        private void SetButtonState(ToolStripButton activeButton, ConentTypeEnum conentTypeEnum)
        {
            ToolStripButtonSound.BackColor = Color.SeaShell;
            ToolStripButtonText.BackColor = Color.SeaShell;
            ToolStripButtonImage.BackColor = Color.SeaShell;
            ToolStripButtonVideo.BackColor = Color.SeaShell;
            ToolStripButtonSound.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            ToolStripButtonText.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            ToolStripButtonImage.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            ToolStripButtonVideo.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            _contentType = new ContentType { ContentTypeTitle = activeButton.Tag.ToString(), ContentTypeId = (int)conentTypeEnum + 1 };

            activeButton.BackColor = Color.GreenYellow;
            activeButton.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            //ButtonDownloadLQ.Visible = conentTypeEnum == ConentTypeEnum.Video;
            ButtonUploadLQ.Visible = conentTypeEnum == ConentTypeEnum.Video;
            LabelCode.Enabled = conentTypeEnum == ConentTypeEnum.Sound;
            TextBoxCode.Enabled = conentTypeEnum == ConentTypeEnum.Sound;

            if (conentTypeEnum == ConentTypeEnum.Video)
            {
                //ButtonDownload.Text = "HQ دانلود";
                ButtonUpload.Text = "HQ آپلود";
            }
            else
            {
                //ButtonDownload.Text = "دانلود";
                ButtonUpload.Text = "آپلود";
            }
        }

        private void ComboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fileTypeId = ((FileType)ComboBoxFileType.SelectedItem).FileTypeId;
            _fileTypeTitle = ((FileType)ComboBoxFileType.SelectedItem).FileTypeTitle;
            //_fileType = new FileType { FileTypeId = fileTypeId, FileTypeTitle = fileTypeTitle };
        }

        private void ButtonSaveTemorary_Click(object sender, EventArgs e)
        {
            var content = GetCurrentContentInfo();
        }

        private object GetCurrentContentInfo()
        {
            return null;
            //var filetype;
        }

        private void ComboBoxCategory2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            //int.TryParse(ComboBoxCategory2.SelectedValue?.ToString(), out _secondCategoryId);
            _secondCategoryId = ((Category)ComboBoxCategory2.SelectedItem).CategoryId;
            var categoryTitle = ((Category)ComboBoxCategory2.SelectedItem).CategoryTitle;
        }

        private void TextBoxSiteCode_Leave(object sender, EventArgs e)
        {
            var siteCode = TextBoxSiteCode.Text.Trim();
            using (ArchiveEntities context = new ArchiveEntities())
            {
                var document = context.Documents.FirstOrDefault(x => x.SiteCode == siteCode);
                if (document == null) return;
                _isFirst = true;
                FillControls(document);
                _isFirst = false;
            }
        }

        private void FillControls(Document document)
        {
            _documentId = document.DocumentId;
            TextBoxSiteCode.Text = document.SiteCode;
            TextBoxOldTitle.Text = document.OldTitle;
            TextBoxNewTitle.Text = document.NewTitle;
            TextBoxSubTitle.Text = document.SubTitle;
            TextBoxComment.Text = document.Comment;
            TextBoxSessionCount.Text = document.SessionCount?.ToString();
            TextBoxSessionNumber.Text = document.SessionNumber?.ToString();
            TextBoxPlace.Text = document.SessionPlace;
            TextBoxLink.Text = document.RelatedLink;
            TextBoxDocumentDescription.Text = document.Description;
            ComboBoxPermissionState.SelectedIndex = ComboBoxPermissionState.FindStringExact(document.PermissionState.PermissionStateTitle);
            ComboBoxPadidAvar.SelectedIndex = ComboBoxPadidAvar.FindStringExact(document.PadidAvar.PadidAvarTitle);
            ComboBoxLanguage.SelectedIndex = ComboBoxLanguage.FindStringExact(document.Language.LanguageTitle);
            ComboBoxPublishState.SelectedIndex = ComboBoxPublishState.FindStringExact(document.PublishState.PublishStateTitle);
            ComboBoxMainCategory.SelectedIndex = ComboBoxMainCategory.FindStringExact(document.Category.CategoryTitle);
            ComboBoxCategory1.SelectedIndex = ComboBoxCategory1.FindStringExact(document.Category.CategoryTitle);
            ComboBoxCategory2.SelectedIndex = ComboBoxCategory2.FindStringExact(document.Category.CategoryTitle);
        }

        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(ComboBoxLanguage.SelectedValue?.ToString(), out _languageId);
            _languageId = ((Language)ComboBoxLanguage.SelectedItem).LanguageId;
            var languageTitle = ((Language)ComboBoxLanguage.SelectedItem).LanguageTitle;
        }

        private void ComboBoxPublishState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            //int.TryParse(ComboBoxPublishState.SelectedValue?.ToString(), out _publishStateId);
            _publishStateId = ((PublishState)ComboBoxPublishState.SelectedItem).PublishStateId;
            var publishStateTitle = ((PublishState)ComboBoxPublishState.SelectedItem).PublishStateTitle;
        }

        private void ButtonAddFile_Click(object sender, EventArgs e)
        {
            if (TextBoxFileNo.Text.Trim() == "")
            {
                MessageBox.Show("شماره فایل باید مقداردهی شود");
                return;
            }

            ContentDto contentDto = new ContentDto
            {
                ResourceTitle = _resourceTitle,
                FileTypeTitle = _fileTypeTitle,
                FileNumber = int.Parse(TextBoxFileNo.Text.Trim()),
                ContentTypeTitle = _contentType.ContentTypeTitle,
                Comment = TextBoxComment.Text.Trim(),
                DeletionDescription = textBoxDeletionDescription.Text.Trim(),
                DocumentId = _documentId,
                FileTypeId = _fileTypeId
            };
            using (ArchiveEntities context = new ArchiveEntities())
            {
                context.Contents.Add(contentDto);
            }
                FillGrid();
        }

        private void FillGrid()
        {
            int index = 0;
            if (GridViewContent.CurrentRow != null)
                index = GridViewContent.CurrentRow.Index;
            var list = GetInformation();
            GridViewContent.DataSource = list;
            if (GridViewContent.RowCount > 0) GridViewContent.CurrentRow = GridViewContent.Rows[index];
        }

        private void ComboBoxResource_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resourceId = ((Resource)ComboBoxResource.SelectedItem).ResourceId;
            _resourceTitle = ((Resource)ComboBoxResource.SelectedItem).ResourceTitle;
        }

        private void TextBoxFileNo_TextChanged(object sender, EventArgs e)
        {
            // باید فقط مقادیر عددی وارد شود
            if (Regex.Replace(TextBoxFileNo.Text, @"\d+", "").Length > 0)
            {
                TextBoxFileNo.Text = "";
            }
        }

        private void ButtonRegisterDocument_Click(object sender, EventArgs e)
        {
            if (IsDuplicatedData())
            {
                MessageBox.Show("اطلاعات وارد شده تکراری می‌باشد");
                return;
            }
            if (TextBoxSiteCode.Text.Trim() == "")
            {
                TextBoxSiteCode.Focus();
                TextBoxSiteCode.BackColor = Color.IndianRed;
                return;
            }

            if (TextBoxNewTitle.Text.Trim() == "")
            {
                TextBoxNewTitle.Focus();
                TextBoxNewTitle.BackColor = Color.IndianRed;
                return;
            }

            if (TextBoxSessionNumber.Text.Trim() == "")
            {
                TextBoxSessionNumber.Focus();
                TextBoxSessionNumber.BackColor = Color.IndianRed;
                return;
            }

            if (ComboBoxPermissionState.SelectedIndex == -1)
            {
                ComboBoxPermissionState.Focus();
                ComboBoxPermissionState.BackColor = Color.IndianRed;
                return;
            }

            if (ComboBoxPublishState.SelectedIndex == -1)
            {
                ComboBoxPublishState.Focus();
                ComboBoxPublishState.BackColor = Color.IndianRed;
                return;
            }

            if (ComboBoxLanguage.SelectedIndex == -1)
            {
                ComboBoxLanguage.Focus();
                ComboBoxLanguage.BackColor = Color.IndianRed;
                return;
            }

            if (ComboBoxPadidAvar.SelectedIndex == -1)
            {
                ComboBoxPadidAvar.Focus();
                ComboBoxPadidAvar.BackColor = Color.IndianRed;
                return;
            }

            if (ComboBoxMainCategory.SelectedIndex == -1)
            {
                ComboBoxMainCategory.Focus();
                ComboBoxMainCategory.BackColor = Color.IndianRed;
                return;
            }

            if (ComboBoxCategory1.SelectedIndex == -1)
            {
                ComboBoxCategory1.Focus();
                ComboBoxCategory1.BackColor = Color.IndianRed;
                return;
            }

            int.TryParse(TextBoxSessionCount.Text.Trim(), out int sessionCount);
            int.TryParse(TextBoxSessionNumber.Text.Trim(), out int sessionNumber);
            Document document = new Document
            {
                OldTitle = TextBoxOldTitle.Text.Trim(),
                NewTitle = TextBoxNewTitle.Text.Trim(),
                SubTitle = TextBoxSubTitle.Text.Trim(),
                LanguageId = _languageId,
                SiteCode = TextBoxSiteCode.Text.Trim(),
                SessionPlace = TextBoxPlace.Text.Trim(),
                Comment = TextBoxDocumentDescription.Text.Trim(),
                RelatedLink = TextBoxLink.Text.Trim(),
                SessionCount = sessionCount,
                PermissionStateId = _permissionStateId,
                PadidAvarId = _padidAvarId,
                PublishStateId = _publishStateId,
                SessionNumber = sessionNumber,
                CreatedDate = DateTime.Now,
                MainCategoryId = _firstCategoryId,
                //SessionDate = Calendar.va
            };
            using (ArchiveEntities context = new ArchiveEntities())
            {
                try
                {
                    context.Documents.Add(document);
                    context.SaveChanges();
                    _documentId = document.DocumentId;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private bool IsDuplicatedData()
        {
            using (ArchiveEntities context = new ArchiveEntities())
            {
                return context.Documents.Count(x => x.SiteCode == TextBoxSiteCode.Text.Trim()) > 0;
            }
        }

        private void ComboBoxPadidAvar_SelectedIndexChanged(object sender, EventArgs e)
        {
            _padidAvarId = ((PadidAvar)ComboBoxPadidAvar.SelectedItem).PadidAvarId;
            var padidAvarTitle = ((PadidAvar)ComboBoxPadidAvar.SelectedItem).PadidAvarTitle;
            //int.TryParse(ComboBoxPadidAvar.SelectedValue?.ToString(), out int padidAvarId);
            //var padidAvarTitle = ComboBoxPadidAvar.SelectedItem;
        }

        private List<ContentDto> GetInformation()
        {
            using (ArchiveEntities context = new ArchiveEntities())
            {
                List<ContentDto> contents = new List<ContentDto>();
                using (var db = new SqlConnection(context.Database.Connection.ConnectionString))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@DocumentId", _documentId, DbType.Int32);
                    contents = db.Query<ContentDto>("GetContentByDocumentId", parameters, commandType: CommandType.StoredProcedure).ToList();
                }
                return contents;
            }
        }
    }
}
