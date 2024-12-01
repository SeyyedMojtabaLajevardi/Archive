using Archive.BLL;
using Archive.BLL.Enumerations;
using Archive.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Archive
{
    public partial class FormCreateDocumentSpeach : Form
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
        private List<Editor> _editors = new List<Editor>();
        private bool _isFirst = false;
        private ContentType _contentType = null;
        private FileType _fileType = null;

        //Enums enums = new Enums();

        public FormCreateDocumentSpeach()
        {
            InitializeComponent();
            _archiveService = new ArchiveService(new ArchiveEntities());
            var width = (ToolStripContentType.Width / 4) - 10;
            ToolStripButtonSound.Width = width;
            ToolStripButtonText.Width = width;
            ToolStripButtonImage.Width = width;
            ToolStripButtonVideo.Width = width;
        }

        private void FormCreateDocumentSpeach_Load(object sender, EventArgs e)
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

            ComboBoxCollection.DataSource = _collections;
            ComboBoxCollection.DisplayMember = "CollectionTitle";
            ComboBoxCollection.ValueMember = "CollectionId";
            ComboBoxCollection.Text = "انتخاب کنید";

            ComboBoxPublishState.DataSource = _publishStates;
            ComboBoxPublishState.DisplayMember = "PublishStateTitle";
            ComboBoxPublishState.ValueMember = "PublishStateId";
            ComboBoxPublishState.Text = "انتخاب کنید";

            ComboBoxFileType.DataSource = _fileTypes;
            ComboBoxFileType.DisplayMember = "FileTypeTitle";
            ComboBoxFileType.ValueMember = "FileTypeId";
            ComboBoxFileType.Text = "انتخاب کنید";

            ComboBoxEditor.DataSource = _editors;
            ComboBoxEditor.DisplayMember = "EditorTitle";
            ComboBoxEditor.ValueMember = "EditorId";
            ComboBoxEditor.Text = "انتخاب کنید";

            _isFirst = false;
        }

        private void ToolStripButtonSound_Click(object sender, EventArgs e)
        {
            SetButtonState(ToolStripButtonSound, ConentTypeEnum.Sound);
            //ToolStripButtonSound.BackColor = Color.GreenYellow;
            //ToolStripButtonText.BackColor = Color.SeaShell;
            //ToolStripButtonImage.BackColor = Color.SeaShell;
            //ToolStripButtonVideo.BackColor = Color.SeaShell;
            //ButtonDownloadLQ.Visible = false;
            //ButtonUploadLQ.Visible = false;
            //ButtonDownload.Text = "دانلود";
            //ButtonUpload.Text = "آپلود";
        }

        private void ToolStripButtonText_Click(object sender, EventArgs e)
        {
            SetButtonState(ToolStripButtonText, ConentTypeEnum.Text);
            //ToolStripButtonText.BackColor = Color.GreenYellow;
            //ToolStripButtonSound.BackColor = Color.SeaShell;
            //ToolStripButtonImage.BackColor = Color.SeaShell;
            //ToolStripButtonVideo.BackColor = Color.SeaShell;
            //ButtonDownloadLQ.Visible = false;
            //ButtonUploadLQ.Visible = false;
            //ButtonDownload.Text = "دانلود";
            //ButtonUpload.Text = "آپلود";
        }

        private void ToolStripButtonImage_Click(object sender, EventArgs e)
        {
            SetButtonState(ToolStripButtonImage, ConentTypeEnum.Image);
            //ToolStripButtonImage.BackColor = Color.GreenYellow;
            //ToolStripButtonSound.BackColor = Color.SeaShell;
            //ToolStripButtonText.BackColor = Color.SeaShell;
            //ToolStripButtonVideo.BackColor = Color.SeaShell;
            //ButtonDownloadLQ.Visible = false;
            //ButtonUploadLQ.Visible = false;
            //ButtonDownload.Text = "دانلود";
            //ButtonUpload.Text = "آپلود";
        }

        private void ToolStripButtonVideo_Click(object sender, EventArgs e)
        {
            SetButtonState(ToolStripButtonVideo, ConentTypeEnum.Video);
            //ToolStripButtonVideo.BackColor = Color.GreenYellow;
            //ToolStripButtonSound.BackColor = Color.SeaShell;
            //ToolStripButtonText.BackColor = Color.SeaShell;
            //ToolStripButtonImage.BackColor = Color.SeaShell;
            //ButtonDownloadLQ.Visible = true;
            //ButtonUploadLQ.Visible = true;
            //ButtonDownload.Text = "HQ" + ButtonDownload.Text;
            //ButtonUpload.Text = "HQ" + ButtonUpload.Text;
        }

        private void ComboBoxPermissionState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
        }

        private void ComboBoxCategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            int.TryParse(ComboBoxCategory1.SelectedValue?.ToString(), out int categoryId);
            var categoryTitle = ComboBoxCategory1.SelectedItem;

            _categories2 = _archiveService.FillCategory(categoryId, 2);
            ComboBoxCategory2.DataSource = _categories2;
            ComboBoxCategory2.DisplayMember = "CategoryTitle";
            ComboBoxCategory2.ValueMember = "CategoryId";
            ComboBoxCategory2.Text = "انتخاب کنید";
        }

        private void ComboBoxMainCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirst) return;
            int categoryId = ((Category)ComboBoxMainCategory.SelectedItem).CategoryId;
                
            var categoryTitle = ((Category)ComboBoxMainCategory.SelectedItem).CategoryTitle;

            _categories1 = _archiveService.FillCategory(categoryId, 2);
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

            ButtonDownloadLQ.Visible = conentTypeEnum == ConentTypeEnum.Video;
            ButtonUploadLQ.Visible = conentTypeEnum == ConentTypeEnum.Video;

            if (conentTypeEnum == ConentTypeEnum.Video)
            {
                ButtonDownload.Text = "HQ دانلود";
                ButtonUpload.Text = "HQ آپلود";
            }
            else
            {
                ButtonDownload.Text = "دانلود";
                ButtonUpload.Text = "آپلود";
            }
        }

        private void ComboBoxFileType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var fileTypeId = ((FileType)ComboBoxFileType.SelectedItem).FileTypeId;
            var fileTypeTitle = ((FileType)ComboBoxFileType.SelectedItem).FileTypeTitle;
            _fileType = new FileType { FileTypeId = fileTypeId, FileTypeTitle = fileTypeTitle };
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
    }
}
