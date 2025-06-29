using Archive.BusinessLogic;
using Archive.BusinessLogic.Enumerations;
using Archive.DataAccess;
using Archive.DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using static Telerik.WinControls.VirtualKeyboard.VirtualKeyboardNativeMethods;

namespace Archive
{
    public partial class FormCreateDocument : Form
    {
        private readonly IDocumentService _documentService;
        private readonly IContentService _contentService;
        private readonly IFileService _fileService;
        private readonly ICategoryService _categoryService;
        private readonly IContentTypeService _contentTypeService;
        private readonly IFileTypeService _fileTypeService;
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
        private List<FileType> _fileTypes_Sound = new List<FileType>();
        private List<FileType> _fileTypes_Text = new List<FileType>();
        private List<FileType> _fileTypes_Image = new List<FileType>();
        private List<FileType> _fileTypes_Video = new List<FileType>();
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
        CultureInfo _persianCulture = new CultureInfo("fa-IR");
        //Enums enums = new Enums();

        public FormCreateDocument(int mainCategoryId)
        {
            InitializeComponent();
            _mainCategoryId = mainCategoryId;
            _archiveService = new ArchiveService(new ArchiveEntities());
            //var width = (ToolStripContentType.Width / 4) - 10;
            //ToolStripButtonSound.Width = width;
            //ToolStripButtonText.Width = width;
            //ToolStripButtonImage.Width = width;
            //ToolStripButtonVideo.Width = width;
        }

        //public FormCreateDocument(IDocumentService documentService, IContentService contentService, IFileService fileService, ICategoryService categoryService)
        public FormCreateDocument(IArchiveFacadeService archiveFacadeService)
        {
            this.SuspendLayout();
            InitializeComponent();
            this.ResumeLayout();
            _archiveService = new ArchiveService(new ArchiveEntities());
            _documentService = archiveFacadeService.DocumentService;
            _contentService = archiveFacadeService.ContentService;
            _categoryService = archiveFacadeService.CategoryService;
            _fileService = archiveFacadeService.FileService;
            GridViewContent.ViewCellFormatting += GridViewContent_ViewCellFormatting;
        }

        private void GridViewContent_ViewCellFormatting(object sender, Telerik.WinControls.UI.CellFormattingEventArgs e)
        {
            if (e.CellElement is Telerik.WinControls.UI.GridDataCellElement)
            {
                e.CellElement.Font = e.Column.FieldName == "ContentTypeTitle" ? new Font("Dana", 10, FontStyle.Bold) : new Font("Dana", 10, FontStyle.Regular);
            }
        }

        private void FormCreateDocumentSpeach_Load(object sender, EventArgs e)
        {
            _isFirst = true;
            FillDropDownList();
            foreach (RadListDataItem item in ComboBoxSubject.Items)
                item.TextAlignment = ContentAlignment.MiddleRight;
            _isFirst = false;
        }

        private void ButtonSaveTemorary_Click(object sender, EventArgs e)
        {
            //var content = GetCurrentContentInfo();
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

        private object GetCurrentContentInfo()
        {
            return null;
            //var filetype;
        }

        private void FillContentControls(int documentId)
        {
            FillGrid();
        }

        private void FillDocumentControls(Document document)
        {
            _isFirst = true;
            string mainCategory = _categoryService.GetCategoryById(document.MainCategoryId.Value).CategoryTitle;
            string firstCategory = _categoryService.GetCategoryById(document.FirstCategoryId.Value).CategoryTitle;
            string secondCategory = _categoryService.GetCategoryById(document.SecondCategoryId.Value).CategoryTitle;

            _documentId = document.DocumentId;
            radDropDownListPermissionState.SelectedIndex = -1;
            radDropDownListPadidAvar.SelectedIndex = -1;
            radDropDownListLanguage.SelectedIndex = -1;
            radDropDownListPublishState.SelectedIndex = -1;
            radDropDownListMainCategory.SelectedIndex = -1;
            radDropDownListCategory1.SelectedIndex = -1;
            radDropDownListCategory2.SelectedIndex = -1;
            TextBoxSiteCode.Text = document.SiteCode;
            TextBoxSubTitle.Text = document.SubTitle;
            TextBoxComment.Text = document.Comment;
            TextBoxSessionCount.Text = document.SessionCount?.ToString();
            TextBoxSessionNumber.Text = document.SessionNumber?.ToString();
            TextBoxPlace.Text = document.SessionPlace;
            TextBoxLink.Text = document.RelatedLink;
            TextBoxDocumentDescription.Text = document.Description;

            if (document.PermissionState != null)
                radDropDownListPermissionState.SelectedIndex = radDropDownListPermissionState.FindStringExact(document.PermissionState.PermissionStateTitle);
            if (document.PadidAvar != null)
                radDropDownListPadidAvar.SelectedIndex = radDropDownListPadidAvar.FindStringExact(document.PadidAvar.PadidAvarTitle);
            if (document.Language != null)
                radDropDownListLanguage.SelectedIndex = radDropDownListLanguage.FindStringExact(document.Language.LanguageTitle);
            if (document.PublishState != null)
                radDropDownListPublishState.SelectedIndex = radDropDownListPublishState.FindStringExact(document.PublishState.PublishStateTitle);
            if (document.OldTitle != null)
                radDropDownListOldTitle.SelectedIndex = radDropDownListOldTitle.FindStringExact(document.OldTitle);
            if (document.NewTitle != null)
                radDropDownListNewTitle.SelectedIndex = radDropDownListNewTitle.FindStringExact(document.NewTitle);
            if (document.SessionDate != null)
                PersiandateTimePickerDate.DateValue = document.SessionDate.Value.ToString("yyyy/MM/dd", _persianCulture);

            _isFirst = false;
            if (!string.IsNullOrEmpty(mainCategory.Trim()))
                radDropDownListMainCategory.SelectedIndex = radDropDownListMainCategory.FindStringExact(mainCategory);
            if (!string.IsNullOrEmpty(firstCategory.Trim()))
                radDropDownListCategory1.SelectedIndex = radDropDownListCategory1.FindStringExact(firstCategory);
            _isFirst = true;
            radDropDownListCategory2.SelectedIndex = -1;
            _isFirst = false;
            if (!string.IsNullOrEmpty(secondCategory.Trim()))
            {
                radDropDownListCategory2.SelectedIndex = radDropDownListCategory2.FindStringExact(secondCategory);
                radDropDownListCategory2.Text = secondCategory;
            }
            var subjects = document.DocumentSubjectRelations
                        .Select(r => r.Subject)
                        .ToList();
            foreach (RadCheckedListDataItem item in ComboBoxSubject.Items)
            {
                item.Checked = subjects.Count(x => x.SubjectId.ToString() == item.Value.ToString()) > 0;
            }
        }

        private void ButtonAddFile_Click(object sender, EventArgs e)
        {
            if (!FormValidations())
                return;

            Content content = _contentService.GetContentByContentTypeIdAndDocumentId(_contentType.ContentTypeId, _documentId);

            if (content == null)
            {
                content = new Content
                {
                    ContentTypeId = _contentType.ContentTypeId,
                    DocumentId = _documentId,
                    Code = TextBoxCode.Text.Trim(),
                    Description = TextBoxContentDescription_Sound.Text.Trim(),
                };
                _contentService.AddContent(content);
            }
            _contentId = content.ContentId;
            File file = _fileService.GetFileByContentIdAndFileTypeIdAndFileNumber(_contentId, _fileTypeId, int.Parse(TextBoxFileNo_Sound.Text.Trim()));

            if (file == null)
            {
                file = new File
                {
                    CategoryId = _mainCategoryId,
                    ResourceId = _resourceId > 0 ? _resourceId : (int?)null,
                    FileTypeId = _fileTypeId,
                    FileNumber = int.Parse(TextBoxFileNo_Sound.Text.Trim()),
                    Comment = TextBoxContentComment_Sound.Text.Trim(),
                    //EditorId = null,
                    DeletionDescription = textBoxDeletionDescription_Sound.Text.Trim(),
                    FileName = "test" + TextBoxFileNo_Sound.Text.Trim(),
                    ContentId = content.ContentId
                };
                _fileService.AddFile(file);
                //_contentService.AddFilesToContentByContentId(content.ContentId, new List<File> { file });
            }
            else
            {
                _fileService.UpdateFile(file.FileId, file);
                MessageBox.Show(@"فایل مورد نظر موجود می‌باشد");
                return;
            }

            FillGrid();
        }

        private void ButtonEditDocument_Click(object sender, EventArgs e)
        {

        }

        private void radNavigationView1_SelectedPageChanged(object sender, EventArgs e)
        {
            _contentType = GetConentType();
        }

        private ContentType GetConentType()
        {
            var contentTypeTitle = radNavigationView1.SelectedPage.Tag.ToString();
            int contentTypeId = -1;
            switch (radNavigationView1.SelectedPage.Name)
            {
                case "radPageViewPageSound":
                    contentTypeId = (int)ConentTypeEnum.Sound + 1;
                    break;
                case "radPageViewPageText":
                    contentTypeId = (int)ConentTypeEnum.Text + 1;
                    break;
                case "radPageViewPageImage":
                    contentTypeId = (int)ConentTypeEnum.Image + 1;
                    break;
                case "radPageViewPageVideo":
                    contentTypeId = (int)ConentTypeEnum.Video + 1;
                    break;
                default:
                    break;
            }
            var contentType = new ContentType { ContentTypeTitle = contentTypeTitle, ContentTypeId = contentTypeId };
            return contentType;
        }

        private void GridViewContent_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (_isFirst || GridViewContent.CurrentRow == null/* || GridViewContent.CurrentRow.HierarchyLevel == 0*/)
                return;
            File fileInfo = GetCurrentFileInfo(GridViewContent.CurrentRow);
            if (fileInfo.ContentId == 0) return;
            _contentType = GetContentTypeFromGridView();
            switch (_contentType.ContentTypeTitle?.ToLower())
            {
                case "sound":
                    TextBoxContentComment_Sound.Text = fileInfo.Comment;
                    textBoxDeletionDescription_Sound.Text = fileInfo.DeletionDescription;
                    TextBoxFileNo_Sound.Text = fileInfo.FileNumber.ToString();
                    if (fileInfo.FileType != null)
                        radDropDownListFileType_Sound.SelectedIndex = radDropDownListFileType_Sound.FindStringExact(fileInfo.FileType.FileTypeTitle);
                    if (fileInfo.Resource != null)
                        radDropDownListResource_Sound.SelectedIndex = radDropDownListResource_Sound.FindStringExact(fileInfo.Resource.ResourceTitle);
                    radNavigationView1.SelectedPage = radPageViewPageSound;

                    break;

                case "text":
                    TextBoxContentComment_Text.Text = fileInfo.Comment;
                    textBoxDeletionDescription_Text.Text = fileInfo.DeletionDescription;
                    TextBoxFileNo_Text.Text = fileInfo.FileNumber.ToString();
                    if (fileInfo.FileType != null)
                        radDropDownListFileType_Text.SelectedIndex = radDropDownListFileType_Text.FindStringExact(fileInfo.FileType.FileTypeTitle);
                    if (fileInfo.Resource != null)
                        radDropDownListResource_Text.SelectedIndex = radDropDownListResource_Text.FindStringExact(fileInfo.Resource.ResourceTitle);
                    RichTextBoxTextUpload.Text = fileInfo.Text;
                    radNavigationView1.SelectedPage = radPageViewPageText;
                    break;

                case "image":
                    TextBoxContentComment_Image.Text = fileInfo.Comment;
                    textBoxDeletionDescription_Image.Text = fileInfo.DeletionDescription;
                    TextBoxFileNo_Image.Text = fileInfo.FileNumber.ToString();
                    if (fileInfo.FileType != null)
                        radDropDownListFileType_Image.SelectedIndex = radDropDownListFileType_Image.FindStringExact(fileInfo.FileType.FileTypeTitle);
                    if (fileInfo.Resource != null)
                        radDropDownListResource_Image.SelectedIndex = radDropDownListResource_Image.FindStringExact(fileInfo.Resource.ResourceTitle);
                    radNavigationView1.SelectedPage = radPageViewPageImage;
                    break;

                case "video":
                    TextBoxContentComment_Video.Text = fileInfo.Comment;
                    textBoxDeletionDescription_Video.Text = fileInfo.DeletionDescription;
                    TextBoxFileNo_Video.Text = fileInfo.FileNumber.ToString();
                    if (fileInfo.FileType != null)
                        radDropDownListFileType_Video.SelectedIndex = radDropDownListFileType_Video.FindStringExact(fileInfo.FileType.FileTypeTitle);
                    if (fileInfo.Resource != null)
                        radDropDownListResource_Video.SelectedIndex = radDropDownListResource_Video.FindStringExact(fileInfo.Resource.ResourceTitle);
                    radNavigationView1.SelectedPage = radPageViewPageVideo;
                    break;
                default:
                    MessageBox.Show(@"اشکال در واکشی نوع محتوا");
                    break;
            }

        }

        private File GetCurrentFileInfo(GridViewRowInfo currentRow)
        {
            File file = new File();
            try
            {
                file.Comment = currentRow.Cells["Comment"].Value?.ToString();
                file.ContentId = int.Parse(currentRow.Cells["ContentId"].Value?.ToString());
                file.DeletionDescription = currentRow.Cells["DeletionDescription"].Value.ToString();
                file.FileName = currentRow.Cells["FileName"]?.Value?.ToString();
                file.FileNumber = int.Parse(currentRow.Cells["FileNumber"].Value.ToString());
                if (currentRow.Cells["FileTypeTitle"].Value != null)
                    file.FileType = new FileType { FileTypeId = int.Parse(currentRow.Cells["FileTypeId"].Value.ToString()), FileTypeTitle = currentRow.Cells["FileTypeTitle"].Value.ToString() };
                if (currentRow.Cells["ResourceTitle"].Value != null)
                    file.Resource = new Resource { ResourceId = int.Parse(currentRow.Cells["ResourceId"].Value.ToString()), ResourceTitle = currentRow.Cells["ResourceTitle"].Value.ToString() };
                file.Text = currentRow.Cells["Text"]?.Value?.ToString();
            }
            catch (Exception ex)
            {
            }
            return file;
        }

        private ContentType GetContentTypeFromGridView()
        {
            int contentTypeId = -1;
            var contentTypeTitle = GridViewContent.CurrentRow.Cells["ContentTypeTitle"].Value?.ToString().ToLower();
            if (contentTypeTitle == null) return new ContentType();
            switch (contentTypeTitle.ToLower())
            {
                case "sound":
                    contentTypeId = (int)ConentTypeEnum.Sound + 1;
                    break;
                case "text":
                    contentTypeId = (int)ConentTypeEnum.Sound + 1;
                    break;
                case "image":
                    contentTypeId = (int)ConentTypeEnum.Sound + 1;
                    break;
                case "video":
                    contentTypeId = (int)ConentTypeEnum.Sound + 1;
                    break;
            }
            var contentType = new ContentType { ContentTypeTitle = contentTypeTitle, ContentTypeId = contentTypeId };
            return contentType;
        }

        private void radDropDownListLanguage_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            radDropDownListLanguage.BackColor = Color.White;
            //int.TryParse(radDropDownListLanguage.SelectedValue?.ToString(), out _languageId);
            int.TryParse(radDropDownListLanguage?.SelectedValue?.ToString(), out _languageId);
            var languageTitle = radDropDownListLanguage.SelectedText;
        }

        private void radDropDownListPermissionState_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            radDropDownListPermissionState.BackColor = Color.White;
            int.TryParse(radDropDownListPermissionState.SelectedValue?.ToString(), out _permissionStateId);
            var permissionLeveTitle = radDropDownListPermissionState.SelectedText;
        }

        private void radDropDownListPublishState_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            radDropDownListPublishState.BackColor = Color.White;
            //int.TryParse(radDropDownListPublishState.SelectedValue?.ToString(), out _publishStateId);
            int.TryParse(radDropDownListPublishState?.SelectedItem?.Value.ToString(), out _publishStateId);
            //var publishStateTitle = ((PublishState)radDropDownListPublishState.SelectedItem).PublishStateTitle;
        }

        private void radDropDownListMainCategory_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            _isFirst = true;
            radDropDownListMainCategory.BackColor = Color.White;
            int.TryParse(radDropDownListMainCategory?.SelectedItem?.Value.ToString(), out _mainCategoryId);
            var categoryTitle = radDropDownListMainCategory.SelectedText;

            _categories1 = _archiveService.FillCategory(_mainCategoryId, 2);
            radDropDownListCategory1.DataSource = _categories1;
            radDropDownListCategory1.DisplayMember = "CategoryTitle";
            radDropDownListCategory1.ValueMember = "CategoryId";
            //radDropDownListCategory1.Text = "انتخاب کنید";
            _isFirst = false;
        }

        private void radDropDownListCategory1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            //_firstCategoryId = ((Category)radDropDownListCategory1.SelectedItem.Value).CategoryId;
            int.TryParse(radDropDownListCategory1?.SelectedItem?.Value.ToString(), out _firstCategoryId);
            radDropDownListCategory1.BackColor = Color.White;
            var categoryTitle = radDropDownListCategory1.SelectedText;
            _isFirst = true;
            _categories2 = _archiveService.FillCategory(_firstCategoryId, 3);
            radDropDownListCategory2.DataSource = _categories2;
            radDropDownListCategory2.DisplayMember = "CategoryTitle";
            radDropDownListCategory2.ValueMember = "CategoryId";
            radDropDownListCategory2.Text = "انتخاب کنید";
            _isFirst = false;
        }

        private void radDropDownListCategory2_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            radDropDownListCategory2.BackColor = Color.White;
            //int.TryParse(radDropDownListCategory2.SelectedValue?.ToString(), out _secondCategoryId);
            int.TryParse(radDropDownListCategory2?.SelectedItem?.Value.ToString(), out _secondCategoryId);
            var categoryTitle = radDropDownListCategory2.SelectedText;
        }

        private void radDropDownListFileType_Sound_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            radDropDownListFileType_Sound.BackColor = Color.White;
            int.TryParse(radDropDownListFileType_Sound?.SelectedItem?.Value.ToString(), out _fileTypeId);
            _fileTypeTitle = radDropDownListFileType_Sound.SelectedText;
            //_fileType = new FileType { FileTypeId = fileTypeId, FileTypeTitle = fileTypeTitle };
        }

        private void radDropDownListFileType_Text_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            radDropDownListFileType_Text.BackColor = Color.White;
            int.TryParse(radDropDownListFileType_Text?.SelectedItem?.Value.ToString(), out _fileTypeId);
            _fileTypeTitle = radDropDownListFileType_Text.SelectedText;
        }

        private void radDropDownListResource_Text_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            radDropDownListResource_Text.BackColor = Color.White;
            int.TryParse(radDropDownListResource_Text?.SelectedItem?.Value.ToString(), out _fileTypeId);
            _fileTypeTitle = radDropDownListResource_Text.SelectedText;
        }

        private void radDropDownListResource_Image_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            radDropDownListResource_Image.BackColor = Color.White;
            int.TryParse(radDropDownListResource_Image?.SelectedItem?.Value.ToString(), out _fileTypeId);
            _fileTypeTitle = radDropDownListResource_Image.SelectedText;
        }

        private void radDropDownListResource_Sound_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            radDropDownListResource_Sound.BackColor = Color.White;
            int.TryParse(radDropDownListResource_Sound?.SelectedItem?.Value.ToString(), out _resourceId);
            _resourceTitle = radDropDownListResource_Sound.SelectedText;
        }

        private void TextBoxSiteCode_Leave(object sender, EventArgs e)
        {
            _contentType = GetConentType();
            var siteCode = TextBoxSiteCode.Text.Trim();
            var document = _documentService.GetDocumentBySiteCode(siteCode);

            ClearBox();
            if (document == null)
                return;
            _isFirst = true;
            FillDocumentControls(document);
            FillContentControls(document.DocumentId);
            _isFirst = false;
        }
        private void TextBoxSiteCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            _contentType = GetConentType();
            var siteCode = TextBoxSiteCode.Text.Trim();
            var document = _documentService.GetDocumentBySiteCode(siteCode);

            ClearBox();
            if (document == null)
                return;
            _isFirst = true;
            TextBoxSiteCode.Text = siteCode;
            FillDocumentControls(document);
            FillContentControls(document.DocumentId);
            _isFirst = false;

        }

        private void radDropDownListOldTitle_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst || radDropDownListOldTitle.Text.Trim() == "")
                return;
            radDropDownListOldTitle.BackColor = Color.White;

            //  اگر سایت کد، مشخص شده باشد، تغییر عنوان قدیم بابت ویرایش خواهد بود نه جستجوی مستند
            //  لذا دیگر نباید جستجوی مستند بر اساس عنوان قدیم صورت پذیرد
            if (TextBoxSiteCode.Text.Trim() != "")
                return;
            var document = _documentService.GetDocumentByOldTitle(radDropDownListOldTitle.Text.Trim());
            var text = radDropDownListOldTitle.Text.Trim();
            ClearBox();
            if (document == null)
                return;
            _isFirst = true;
            radDropDownListOldTitle.Text = text;
            _isFirst = false;

            _isFirst = true;
            FillDocumentControls(document);
            FillContentControls(document.DocumentId);
            _isFirst = false;
        }

        private void radDropDownListNewTitle_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst || radDropDownListNewTitle.Text.Trim() == "")
                return;

            radDropDownListNewTitle.BackColor = Color.White;

            //  اگر سایت کد، مشخص شده باشد، تغییر عنوان جدید بابت ویرایش خواهد بود نه جستجوی مستند
            //  لذا دیگر نباید جستجوی مستند بر اساس عنوان جدید صورت پذیرد
            if (TextBoxSiteCode.Text.Trim() != "")
                return;
            var document = _documentService.GetDocumentByNewTitle(radDropDownListNewTitle.Text.Trim());
            var text = radDropDownListNewTitle.Text.Trim();
            ClearBox();
            if (document == null)
                return;

            _isFirst = true;
            radDropDownListNewTitle.Text = text;
            _isFirst = false;

            _isFirst = true;
            FillDocumentControls(document);
            FillContentControls(document.DocumentId);
            _isFirst = false;
        }

        private void ButtonUpload_Sound_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxSiteCode_TextChanged(object sender, EventArgs e)
        {
            TextBoxSiteCode.BackColor = Color.White;
        }

        private void ButtonAddFileType_Sound_Click(object sender, EventArgs e)
        {
            FormFileType frm = new FormFileType();
            frm.ShowDialog();
            frm.Close();
            radDropDownListFileType_Sound.DataSource = _fileTypes_Sound;
            radDropDownListFileType_Sound.DisplayMember = "FileTypeTitle";
            radDropDownListFileType_Sound.ValueMember = "FileTypeId";
            radDropDownListFileType_Sound.Text = "انتخاب کنید";
        }

        private void ButtonAddFileType_Text_Click(object sender, EventArgs e)
        {
            FormFileType frm = new FormFileType();
            frm.ShowDialog();
            frm.Close();
            radDropDownListFileType_Text.DataSource = _fileTypes_Text;
            radDropDownListFileType_Text.DisplayMember = "FileTypeTitle";
            radDropDownListFileType_Text.ValueMember = "FileTypeId";
            radDropDownListFileType_Text.Text = "انتخاب کنید";
        }

        private void ButtonAddFileType_Image_Click(object sender, EventArgs e)
        {
            FormFileType frm = new FormFileType();
            frm.ShowDialog();
            frm.Close();
            radDropDownListFileType_Image.DataSource = _fileTypes_Image;
            radDropDownListFileType_Image.DisplayMember = "FileTypeTitle";
            radDropDownListFileType_Image.ValueMember = "FileTypeId";
            radDropDownListFileType_Image.Text = "انتخاب کنید";
        }

        private void ButtonAddFileType_Video_Click(object sender, EventArgs e)
        {
            FormFileType frm = new FormFileType();
            frm.ShowDialog();
            frm.Close();
            radDropDownListFileType_Video.DataSource = _fileTypes_Video;
            radDropDownListFileType_Video.DisplayMember = "FileTypeTitle";
            radDropDownListFileType_Video.ValueMember = "FileTypeId";
            radDropDownListFileType_Video.Text = "انتخاب کنید";
        }

        private void ButtonAddSubject_Click(object sender, EventArgs e)
        {
            FormSubject frm = new FormSubject();
            frm.ShowDialog();
            frm.Close();

            _subjects = _archiveService.FillSubject();
            ComboBoxSubject.DataSource = _subjects;
            ComboBoxSubject.DisplayMember = "SubjectTitle";
            ComboBoxSubject.ValueMember = "SubjectId";
            ComboBoxSubject.Text = "انتخاب کنید";
        }

        private void radDropDownListPadidAvar_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            int.TryParse(radDropDownListPadidAvar.SelectedItem?.Value?.ToString(), out _padidAvarId);
            var padidAvarTitle = radDropDownListPadidAvar.SelectedText;
        }

        private void FillGrid()
        {
            int index = 0;
            if (GridViewContent.CurrentRow != null)
                index = GridViewContent.CurrentRow.Index;
            var list = _contentService.GetContentByDocumentId(_documentId);
            //GetInformation();
            _isFirst = true;
            GridViewContent.DataSource = list;
            if (GridViewContent.RowCount > 0) GridViewContent.CurrentRow = GridViewContent.Rows[index];
            _isFirst = false;
        }

        private void TextBoxFileNo_TextChanged(object sender, EventArgs e)
        {
            // باید فقط مقادیر عددی وارد شود
            if (Regex.Replace(TextBoxFileNo_Sound.Text, @"\d+", "").Length > 0)
            {
                TextBoxFileNo_Sound.Text = "";
            }
        }

        private void ButtonRegisterDocument_Click(object sender, EventArgs e)
        {
            if (!FormValidations())
            {
                MessageBox.Show(@"اطلاعات ضروری، تکمیل نشده است. برای ثبت اطلاعات ناقص از دکمه «ثبت موقت» استفاده کنید", @"عدم تکمیل اطلاعات");
                return;
            }

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

            if (radDropDownListNewTitle.SelectedIndex == -1)
            {
                radDropDownListNewTitle.Focus();
                radDropDownListNewTitle.BackColor = Color.IndianRed;
                return false;
            }

            if (TextBoxSessionNumber.Text.Trim() == "")
            {
                TextBoxSessionNumber.Focus();
                TextBoxSessionNumber.BackColor = Color.IndianRed;
                return false;
            }

            if (radDropDownListPermissionState.SelectedIndex == -1)
            {
                radDropDownListPermissionState.Focus();
                radDropDownListPermissionState.BackColor = Color.IndianRed;
                return false;
            }

            if (radDropDownListPublishState.SelectedIndex == -1)
            {
                radDropDownListPublishState.Focus();
                radDropDownListPublishState.BackColor = Color.IndianRed;
                return false;
            }

            if (radDropDownListLanguage.SelectedIndex == -1)
            {
                radDropDownListLanguage.Focus();
                radDropDownListLanguage.BackColor = Color.IndianRed;
                return false;
            }

            if (radDropDownListPadidAvar.SelectedIndex == -1)
            {
                radDropDownListPadidAvar.Focus();
                radDropDownListPadidAvar.BackColor = Color.IndianRed;
                return false;
            }

            if (radDropDownListMainCategory.SelectedIndex == -1)
            {
                radDropDownListMainCategory.Focus();
                radDropDownListMainCategory.BackColor = Color.IndianRed;
                return false;
            }

            if (radDropDownListCategory1.SelectedIndex == -1)
            {
                radDropDownListCategory1.Focus();
                radDropDownListCategory1.BackColor = Color.IndianRed;
                return false;
            }

            /*            if (_contentType.ContentTypeTitle == ConentTypeEnum.Sound.ToString() && string.IsNullOrEmpty(TextBoxFileNo_Sound.Text))
                        {
                            TextBoxFileNo_Sound.Focus();
                            TextBoxFileNo_Sound.BackColor = Color.IndianRed;
                            return false;
                        }

                        if (_contentType.ContentTypeTitle == ConentTypeEnum.Text.ToString() && string.IsNullOrEmpty(TextBoxFileNo_Text.Text))
                        {
                            TextBoxFileNo_Sound.Focus();
                            TextBoxFileNo_Sound.BackColor = Color.IndianRed;
                            return false;
                        }

                        if (_contentType.ContentTypeTitle == ConentTypeEnum.Image.ToString() && string.IsNullOrEmpty(TextBoxFileNo_Image.Text))
                        {
                            TextBoxFileNo_Sound.Focus();
                            TextBoxFileNo_Sound.BackColor = Color.IndianRed;
                            return false;
                        }

                        if (_contentType.ContentTypeTitle == ConentTypeEnum.Video.ToString() && string.IsNullOrEmpty(TextBoxFileNo_Video.Text))
                        {
                            TextBoxFileNo_Sound.Focus();
                            TextBoxFileNo_Sound.BackColor = Color.IndianRed;
                            return false;
                        }*/

            return true;
        }

        private DocumentDto CreateDocumentModel(Document document = null)
        {
            DocumentDto documentDto = new DocumentDto();
            if (document == null)
                document = new Document();
            int.TryParse(TextBoxSessionCount.Text.Trim(), out int sessionCount);
            int.TryParse(TextBoxSessionNumber.Text.Trim(), out int sessionNumber);
            int.TryParse(radDropDownListPermissionState?.SelectedItem?.Value.ToString(), out _permissionStateId);
            int.TryParse(radDropDownListCategory2?.SelectedItem?.Value.ToString(), out _secondCategoryId);
            int.TryParse(radDropDownListCategory1?.SelectedItem?.Value.ToString(), out _firstCategoryId);
            int.TryParse(radDropDownListPadidAvar?.SelectedItem?.Value.ToString(), out _padidAvarId);
            int.TryParse(radDropDownListLanguage?.SelectedItem?.Value.ToString(), out _languageId);
            int.TryParse(radDropDownListMainCategory?.SelectedItem?.Value.ToString(), out _mainCategoryId);
            int.TryParse(radDropDownListPublishState?.SelectedItem?.Value.ToString(), out _publishStateId);
            //if (document == null)
            //    document = new Document();

            //documentDto.UserId = ??
            //documentDto.CreatedDate = ??
            //documentDto.CreatorUserId = ??
            var date = PersiandateTimePickerDate.DateValue != null ? PersiandateTimePickerDate.DateValue : "";
            string validDate = Regex.Replace(date, @"(\d{4})/(\d{1,2})/(\d{1,2})",
            m => $"{m.Groups[1].Value}/{int.Parse(m.Groups[2].Value):00}/{int.Parse(m.Groups[3].Value):00}"
        );
            documentDto.SessionDate = DateTime.ParseExact(validDate, "yyyy/MM/dd", _persianCulture, DateTimeStyles.None);
            documentDto.DocumentCode = document.DocumentCode;
            documentDto.DocumentId = document.DocumentId;
            //documentDto.SubjectIdList = document.DocumentSubjectRelations.Select(x => x.SubjectId.Value).ToList();
            documentDto.DocumentSubjectRelations = GetNewDocumentSubjectRelation(document);
            documentDto.SiteCode = TextBoxSiteCode.Text.Trim();
            documentDto.OldTitle = radDropDownListOldTitle.Text.Trim();
            documentDto.NewTitle = radDropDownListNewTitle.Text.Trim();
            documentDto.NewTitle = radDropDownListNewTitle.Text.Trim();
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

        private ICollection<DocumentSubjectRelation> GetNewDocumentSubjectRelation(Document document)
        {
            List<DocumentSubjectRelation> documentSubjectRelationList = new List<DocumentSubjectRelation>();
            foreach (RadCheckedListDataItem item in ComboBoxSubject.Items)
            {
                if (item.Checked)
                    documentSubjectRelationList.Add(
                        new DocumentSubjectRelation { DocumentId = document.DocumentId, SubjectId = int.Parse(item.Value.ToString()) });
            }
            return documentSubjectRelationList;
        }

        private void ClearBox()
        {
            _isFirst = true;
            ClearFormControls(this);
            _isFirst = false;
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
                    _isFirst = true;
                    comboBox.SelectedIndex = -1; // یا هر مقداری که برای تنظیم اولیه نیاز دارید
                    _isFirst = false;
                }
                else if (c is RadDropDownList radDropDownList)
                {
                    _isFirst = true;
                    radDropDownList.SelectedIndex = -1; // یا هر مقداری که برای تنظیم اولیه نیاز دارید
                    _isFirst = false;
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
            if (control == this)
            {
                GridViewContent.DataSource = null;
                GridViewContent.Rows.Clear();
                PersiandateTimePickerDate.DateValue = "";
                _isFirst = true;
                foreach (RadCheckedListDataItem item in ComboBoxSubject.Items)
                    item.Checked = false;
                _isFirst = false;
            }
        }

        private Document DuplicatedData()
        {
            return _documentService.GetDocumentBySiteCode(TextBoxSiteCode.Text.Trim());
        }

        private void FillDropDownList()
        {
            _permissionStates = _archiveService.FillPermissionState();
            _padidAvars = _archiveService.FillPadidAvar();
            _permissionTypes = _archiveService.FillPermissionType();
            _subjects = _archiveService.FillSubject();
            _publishStates = _archiveService.FillPublishState();
            _collections = _archiveService.FillCollection();
            _mainCategories = _archiveService.FillCategory(null, 1);
            _fileTypes_Text = _archiveService.FillFileTypeByContentType(ConentTypeEnum.Text);
            _fileTypes_Sound = _archiveService.FillFileTypeByContentType(ConentTypeEnum.Sound);
            _fileTypes_Video = _archiveService.FillFileTypeByContentType(ConentTypeEnum.Video);
            _fileTypes_Image = _archiveService.FillFileTypeByContentType(ConentTypeEnum.Image);
            _languages = _archiveService.FillLanguage();

            radDropDownListPermissionState.DataSource = _permissionStates;
            radDropDownListPermissionState.DisplayMember = "PermissionStateTitle";
            radDropDownListPermissionState.ValueMember = "PermissionStateId";
            radDropDownListPermissionState.Text = "انتخاب کنید";

            radDropDownListPadidAvar.DataSource = _padidAvars;
            radDropDownListPadidAvar.DisplayMember = "PadidAvarTitle";
            radDropDownListPadidAvar.ValueMember = "PadidAvarId";
            radDropDownListPadidAvar.Text = "انتخاب کنید";

            radDropDownListLanguage.DataSource = _languages;
            radDropDownListLanguage.DisplayMember = "LanguageTitle";
            radDropDownListLanguage.ValueMember = "LanguageId";
            radDropDownListLanguage.Text = "انتخاب کنید";

            radDropDownListOldTitle.DataSource = _documentService.GetAll();
            radDropDownListOldTitle.DisplayMember = "OldTitle";
            radDropDownListOldTitle.ValueMember = "DocumentId";
            radDropDownListOldTitle.Text = "انتخاب کنید";

            radDropDownListNewTitle.DataSource = _documentService.GetAll();
            radDropDownListNewTitle.DisplayMember = "NewTitle";
            radDropDownListNewTitle.ValueMember = "DocumentId";
            radDropDownListNewTitle.Text = "انتخاب کنید";

            radDropDownListMainCategory.DataSource = _mainCategories;
            radDropDownListMainCategory.DisplayMember = "CategoryTitle";
            radDropDownListMainCategory.ValueMember = "CategoryId";
            radDropDownListMainCategory.Text = "انتخاب کنید";
            if (_mainCategoryId > 0)
            {
                var category = _mainCategories.Where(x => x.CategoryId == _mainCategoryId).FirstOrDefault();
                radDropDownListMainCategory.SelectedIndex = category == null ? -1 : category.CategoryId - 1;
                _categories1 = _archiveService.FillCategory(category.CategoryId, 2);
                radDropDownListCategory1.DataSource = _categories1;
                radDropDownListCategory1.DisplayMember = "CategoryTitle";
                radDropDownListCategory1.ValueMember = "CategoryId";
                radDropDownListCategory1.Text = "انتخاب کنید";
            }

            radDropDownListPublishState.DataSource = _publishStates;
            radDropDownListPublishState.DisplayMember = "PublishStateTitle";
            radDropDownListPublishState.ValueMember = "PublishStateId";
            radDropDownListPublishState.Text = "انتخاب کنید";

            radDropDownListFileType_Sound.DataSource = _fileTypes_Sound;
            radDropDownListFileType_Sound.DisplayMember = "FileTypeTitle";
            radDropDownListFileType_Sound.ValueMember = "FileTypeId";
            radDropDownListFileType_Sound.Text = "انتخاب کنید";

            radDropDownListFileType_Text.DataSource = _fileTypes_Text;
            radDropDownListFileType_Text.DisplayMember = "FileTypeTitle";
            radDropDownListFileType_Text.ValueMember = "FileTypeId";
            radDropDownListFileType_Text.Text = "انتخاب کنید";

            radDropDownListFileType_Image.DataSource = _fileTypes_Image;
            radDropDownListFileType_Image.DisplayMember = "FileTypeTitle";
            radDropDownListFileType_Image.ValueMember = "FileTypeId";
            radDropDownListFileType_Image.Text = "انتخاب کنید";

            radDropDownListFileType_Video.DataSource = _fileTypes_Video;
            radDropDownListFileType_Video.DisplayMember = "FileTypeTitle";
            radDropDownListFileType_Video.ValueMember = "FileTypeId";
            radDropDownListFileType_Video.Text = "انتخاب کنید";

            ComboBoxSubject.DataSource = _subjects;
            ComboBoxSubject.DisplayMember = "SubjectTitle";
            ComboBoxSubject.ValueMember = "SubjectId";
            ComboBoxSubject.Text = "کنید انتخاب";
            

            radDropDownListOldTitle.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListOldTitle.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListOldTitle.DropDownListElement);
            radDropDownListNewTitle.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListNewTitle.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListNewTitle.DropDownListElement);
            radDropDownListPermissionState.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListPermissionState.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListPermissionState.DropDownListElement);
            radDropDownListPadidAvar.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListPadidAvar.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListPadidAvar.DropDownListElement);
            radDropDownListLanguage.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListLanguage.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListLanguage.DropDownListElement);
            radDropDownListPublishState.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListPublishState.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListPublishState.DropDownListElement);
            radDropDownListCategory1.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListCategory1.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListCategory1.DropDownListElement);
            radDropDownListCategory2.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListCategory2.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListCategory2.DropDownListElement);
            radDropDownListFileType_Sound.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListFileType_Sound.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListFileType_Sound.DropDownListElement);
            radDropDownListFileType_Text.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListFileType_Text.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListFileType_Text.DropDownListElement);
            radDropDownListFileType_Image.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListFileType_Image.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListFileType_Image.DropDownListElement);
            radDropDownListFileType_Video.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListFileType_Video.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListFileType_Video.DropDownListElement);
            radDropDownListResource_Sound.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListResource_Sound.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListResource_Sound.DropDownListElement);
            radDropDownListResource_Text.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListResource_Text.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListResource_Text.DropDownListElement);
            radDropDownListResource_Image.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListResource_Image.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListResource_Image.DropDownListElement);
            radDropDownListResource_Video.AutoCompleteMode = AutoCompleteMode.Suggest;
            radDropDownListResource_Video.DropDownListElement.AutoCompleteSuggest = new CustomAutoCompleteSuggestHelper(radDropDownListResource_Video.DropDownListElement);
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
