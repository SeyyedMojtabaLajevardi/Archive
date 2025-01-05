using Archive.BusinessLogic;
using Archive.BusinessLogic.Enumerations;
using Archive.DataAccess;
using Archive.DataAccess.Dto;
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
using System.Xml.Linq;
using Telerik.WinControls;

namespace Archive
{
    public partial class FormCreateDocument : Form
    {
        private readonly IDocumentService _documentService;
        private readonly IContentService _contentService;
        private readonly IFileService _fileService;
        private readonly ICategoryService _categoryService;
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
            _resourceId,
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

        public FormCreateDocument(IDocumentService documentService, IContentService contentService, IFileService fileService, ICategoryService categoryService)
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
            _documentService = documentService;
            _contentService = contentService;
            _categoryService = categoryService;
            _fileService = fileService;
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
            SetButtonState(ToolStripButtonSound, ConentTypeEnum.Sound);
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
            _isFirst = true;
            _categories2 = _archiveService.FillCategory(_firstCategoryId, 3);
            ComboBoxCategory2.DataSource = _categories2;
            ComboBoxCategory2.DisplayMember = "CategoryTitle";
            ComboBoxCategory2.ValueMember = "CategoryId";
            ComboBoxCategory2.Text = "انتخاب کنید";
            _isFirst = false;
        }

        private void ComboBoxMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            _isFirst = true;
            _mainCategoryId = ((Category)ComboBoxMainCategory.SelectedItem).CategoryId;
            var categoryTitle = ((Category)ComboBoxMainCategory.SelectedItem).CategoryTitle;

            _categories1 = _archiveService.FillCategory(_mainCategoryId, 2);
            ComboBoxCategory1.DataSource = _categories1;
            ComboBoxCategory1.DisplayMember = "CategoryTitle";
            ComboBoxCategory1.ValueMember = "CategoryId";
            ComboBoxCategory1.Text = "انتخاب کنید";
            _isFirst = false;
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
            if (_isFirst) return;
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
            var document = _documentService.GetDocumentBySiteCode(siteCode);

            if (document == null) return;
            _isFirst = true;
            FillControls(document);
            _isFirst = false;
        }

        private void FillControls(Document document)
        {
            _isFirst = true;
            string mainCategory = _categoryService.GetCategoryById(document.MainCategoryId.Value).CategoryTitle;
            string firstCategory = _categoryService.GetCategoryById(document.FirstCategoryId.Value).CategoryTitle;
            string secondCategory = _categoryService.GetCategoryById(document.SecondCategoryId.Value).CategoryTitle;

            _documentId = document.DocumentId;
            ComboBoxPermissionState.SelectedIndex = -1;
            ComboBoxPadidAvar.SelectedIndex = -1;
            ComboBoxLanguage.SelectedIndex = -1;
            ComboBoxPublishState.SelectedIndex = -1;
            ComboBoxMainCategory.SelectedIndex = -1;
            ComboBoxCategory1.SelectedIndex = -1;
            ComboBoxCategory2.SelectedIndex = -1;
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

            if (document.PermissionState != null)
                ComboBoxPermissionState.SelectedIndex = ComboBoxPermissionState.FindStringExact(document.PermissionState.PermissionStateTitle);
            if (document.PadidAvar != null)
                ComboBoxPadidAvar.SelectedIndex = ComboBoxPadidAvar.FindStringExact(document.PadidAvar.PadidAvarTitle);
            if (document.Language != null)
                ComboBoxLanguage.SelectedIndex = ComboBoxLanguage.FindStringExact(document.Language.LanguageTitle);
            if (document.PublishState != null)
                ComboBoxPublishState.SelectedIndex = ComboBoxPublishState.FindStringExact(document.PublishState.PublishStateTitle);
            _isFirst = false;
            if (!string.IsNullOrEmpty(mainCategory.Trim()))
                ComboBoxMainCategory.SelectedIndex = ComboBoxMainCategory.FindStringExact(mainCategory);
            if (!string.IsNullOrEmpty(firstCategory.Trim()))
                ComboBoxCategory1.SelectedIndex = ComboBoxCategory1.FindStringExact(firstCategory);
            _isFirst = true;
            ComboBoxCategory2.SelectedIndex = -1;
            _isFirst = false;
            if (!string.IsNullOrEmpty(secondCategory.Trim()))
            {
                ComboBoxCategory2.SelectedIndex = ComboBoxCategory2.FindStringExact(secondCategory);
                ComboBoxCategory2.Text = secondCategory;
            }
        }

        private void ComboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            //int.TryParse(ComboBoxLanguage.SelectedValue?.ToString(), out _languageId);
            _languageId = ((Language)ComboBoxLanguage.SelectedItem).LanguageId;
            //var languageTitle = ((Language)ComboBoxLanguage.SelectedItem).LanguageTitle;
        }

        private void ComboBoxPublishState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            //int.TryParse(ComboBoxPublishState.SelectedValue?.ToString(), out _publishStateId);
            _publishStateId = ((PublishState)ComboBoxPublishState.SelectedItem).PublishStateId;
            //var publishStateTitle = ((PublishState)ComboBoxPublishState.SelectedItem).PublishStateTitle;
        }

        private void ButtonAddFile_Click(object sender, EventArgs e)
        {
            if (TextBoxFileNo.Text.Trim() == "")
            {
                MessageBox.Show("شماره فایل باید مقداردهی شود");
                return;
            }

            Content content = _contentService.GetContentByContentTypeIdAndDocumentId(_contentType.ContentTypeId, _documentId);

            if (content == null)
            {
                content = new Content
                {
                    ContentTypeId = _contentType.ContentTypeId,
                    DocumentId = _documentId,
                    Code = TextBoxCode.Text.Trim(),
                    Description = TextBoxContentDescription.Text.Trim(),
                };
                _contentService.AddContent(content);
            }
            _contentId = content.ContentId;

            File file = _fileService.GetFileByContentIdAndFileTypeIdAndFileNumber(_contentId, _fileTypeId, int.Parse(TextBoxFileNo.Text.Trim()));
            if (file == null)
            {
                file = new File
                {
                    ResourceId = _resourceId > 0 ? _resourceId : (int?)null,
                    FileTypeId = _fileTypeId,
                    FileNumber = int.Parse(TextBoxFileNo.Text.Trim()),
                    Comment = TextBoxContentComment.Text.Trim(),
                    //EditorId = null,
                    DeletionDescription = textBoxDeletionDescription.Text.Trim(),
                    FileName = "test" + TextBoxFileNo.Text.Trim(),
                    ContentId = content.ContentId
                };
                _fileService.AddFile(file);
                //_contentService.AddFilesToContentByContentId(content.ContentId, new List<File> { file });
            }
            else
            {
                MessageBox.Show(@"فایل مورد نظر موجود می‌باشد");
                return;
            }

            FillGrid();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (!FormValidations())
                return;

            Document document = DuplicatedData();
            if (document != null)
            {
                if (MessageBox.Show("اطلاعات وارد شده تکراری می‌باشد" + "\r\r" + "آیا تمایل به ویرایش اطلاعات دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var documentDto = CreateDocumentModel(document);
                    _documentService.UpdateDocument(documentDto);
                }
            }
            else
            {
                document = CreateDocumentModel();
                _documentId = _documentService.AddDocument(document);
            }
        }

        private void FillGrid()
        {
            int index = 0;
            if (GridViewContent.CurrentRow != null)
                index = GridViewContent.CurrentRow.Index;
            var list = _contentService.GetContentByDocumentId(_documentId);
            //GetInformation();
            GridViewContent.DataSource = list;
            if (GridViewContent.RowCount > 0) GridViewContent.CurrentRow = GridViewContent.Rows[index];
        }

        private void ComboBoxResource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            _resourceId = ((Resource)ComboBoxResource.SelectedItem).ResourceId;
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
            if (!FormValidations())
                return;

            Document document = DuplicatedData();
            if (document != null)
            {
                if (MessageBox.Show("اطلاعات وارد شده تکراری می‌باشد" + "\r\r" + "آیا تمایل به ویرایش اطلاعات دارید؟", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var documentDto = CreateDocumentModel(document);
                    _documentService.UpdateDocument(documentDto);
                }
            }
            else
            {
                document = CreateDocumentModel();
                _documentId = _documentService.AddDocument(document);
            }
        }

        private bool FormValidations()
        {
            if (TextBoxSiteCode.Text.Trim() == "")
            {
                TextBoxSiteCode.Focus();
                TextBoxSiteCode.BackColor = Color.IndianRed;
                return false;
            }

            if (TextBoxNewTitle.Text.Trim() == "")
            {
                TextBoxNewTitle.Focus();
                TextBoxNewTitle.BackColor = Color.IndianRed;
                return false;
            }

            if (TextBoxSessionNumber.Text.Trim() == "")
            {
                TextBoxSessionNumber.Focus();
                TextBoxSessionNumber.BackColor = Color.IndianRed;
                return false;
            }

            if (ComboBoxPermissionState.SelectedIndex == -1)
            {
                ComboBoxPermissionState.Focus();
                ComboBoxPermissionState.BackColor = Color.IndianRed;
                return false;
            }

            if (ComboBoxPublishState.SelectedIndex == -1)
            {
                ComboBoxPublishState.Focus();
                ComboBoxPublishState.BackColor = Color.IndianRed;
                return false;
            }

            if (ComboBoxLanguage.SelectedIndex == -1)
            {
                ComboBoxLanguage.Focus();
                ComboBoxLanguage.BackColor = Color.IndianRed;
                return false;
            }

            if (ComboBoxPadidAvar.SelectedIndex == -1)
            {
                ComboBoxPadidAvar.Focus();
                ComboBoxPadidAvar.BackColor = Color.IndianRed;
                return false;
            }

            if (ComboBoxMainCategory.SelectedIndex == -1)
            {
                ComboBoxMainCategory.Focus();
                ComboBoxMainCategory.BackColor = Color.IndianRed;
                return false;
            }

            if (ComboBoxCategory1.SelectedIndex == -1)
            {
                ComboBoxCategory1.Focus();
                ComboBoxCategory1.BackColor = Color.IndianRed;
                return false;
            }
            return true;
        }

        private DocumentDto CreateDocumentModel(Document document = null)
        {
            DocumentDto documentDto = new DocumentDto();
            int.TryParse(TextBoxSessionCount.Text.Trim(), out int sessionCount);
            int.TryParse(TextBoxSessionNumber.Text.Trim(), out int sessionNumber);
            //if (document == null)
            //    document = new Document();

            //documentDto.UserId = ??
            //documentDto.DocumentCode = ??
            //documentDto.CreatedDate = ??
            //documentDto.CreatorUserId = ??
            documentDto.SiteCode = TextBoxSiteCode.Text.Trim();
            documentDto.OldTitle = TextBoxOldTitle.Text.Trim();
            documentDto.NewTitle = TextBoxNewTitle.Text.Trim();
            documentDto.SubTitle = TextBoxSubTitle.Text.Trim();
            documentDto.PermissionStateId = _permissionStateId;
            //documentDto.CreatorUserId = ??
            documentDto.PadidAvarId = _padidAvarId;
            documentDto.LanguageId = _languageId;
            documentDto.Comment = TextBoxDocumentDescription.Text.Trim();
            documentDto.SessionNumber = sessionNumber;
            documentDto.SessionCount = sessionCount;
            documentDto.SessionPlace = TextBoxPlace.Text.Trim();
            //documentDto.SessionDate = ??
            documentDto.RelatedLink = TextBoxLink.Text.Trim();
            documentDto.Description = TextBoxDocumentDescription.Text.Trim();
            documentDto.MainCategoryId = _mainCategoryId;
            //documentDto.PublishYear = ??
            //documentDto.PublishPlace = ??
            //documentDto.BookPublisher = ??
            //documentDto.BookVolumeNumber = ??
            //documentDto.BookPageNumber = ??
            //documentDto.BookVolumeCount = ??
            //documentDto.FipaCode = ??
            //documentDto.TranslateLanguageId = ??
            //documentDto.Translator = ??
            //documentDto.Narrator = ??
            documentDto.SecondCategoryId = _secondCategoryId;
            documentDto.FirstCategoryId = _firstCategoryId;
            documentDto.PublishStateId = _publishStateId;
            documentDto.MainCategory = _categoryService.GetCategoryById(_mainCategoryId).CategoryTitle;
            documentDto.FirstCategory = _categoryService.GetCategoryById(_firstCategoryId).CategoryTitle;
            documentDto.SecondCategory = _categoryService.GetCategoryById(_secondCategoryId).CategoryTitle;

            //SessionDate = Calendar.va
            return documentDto;
        }

        private void ClearBox()
        {
            ClearFormControls(this);
        }

        private void ClearFormControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (c is ComboBox comboBox)
                {
                    comboBox.SelectedIndex = -1; // یا هر مقداری که برای تنظیم اولیه نیاز دارید
                }
                else if (c is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }
                else if (c is RadioButton radioButton)
                {
                    radioButton.Checked = false;
                }
                else if (c is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.Value = DateTime.Now;
                }
                else if (c.HasChildren)
                {
                    ClearFormControls(c);
                }
            }
        }

        private Document DuplicatedData()
        {
            return _documentService.GetDocumentBySiteCode(TextBoxSiteCode.Text.Trim());
        }

        private void ComboBoxPadidAvar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            _padidAvarId = ((PadidAvar)ComboBoxPadidAvar.SelectedItem).PadidAvarId;
            var padidAvarTitle = ((PadidAvar)ComboBoxPadidAvar.SelectedItem).PadidAvarTitle;
        }

        //private List<ContentDto> GetInformation()
        //{
        //    using (ArchiveEntities context = new ArchiveEntities())
        //    {
        //        List<ContentDto> contents = new List<ContentDto>();
        //        using (var db = new SqlConnection(context.Database.Connection.ConnectionString))
        //        {
        //            var parameters = new DynamicParameters();
        //            parameters.Add("@DocumentId", _documentId, DbType.Int32);
        //            contents = db.Query<ContentDto>("GetContentByDocumentId", parameters, commandType: CommandType.StoredProcedure).ToList();
        //        }
        //        return contents;
        //    }
        //}
    }
}
