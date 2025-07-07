using Archive.BusinessLogic;
using Archive.BusinessLogic.Enumerations;
using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Archive.Presentation.BaseForm
{
    public partial class UserControlFiles : UserControl
    {
        public event EventHandler AddButtonClicked;
        public ContentType ContentType { get; set; }
        private readonly ArchiveService _archiveService;
        ContentType _contentType = null;
        private List<FileType> _fileTypes_Sound = new List<FileType>();
        private List<FileType> _fileTypes_Text = new List<FileType>();
        private List<FileType> _fileTypes_Image = new List<FileType>();
        private List<FileType> _fileTypes_Video = new List<FileType>();
        bool _isFirst = false;
        public int FileTypeId { get; set; }

        public UserControlFiles()
        {
            _isFirst = true;
            InitializeComponent();
            _archiveService = new ArchiveService(new ArchiveEntities());
            _fileTypes_Text = _archiveService.FillFileTypeByContentType(ConentTypeEnum.Text);
            _fileTypes_Sound = _archiveService.FillFileTypeByContentType(ConentTypeEnum.Sound);
            _fileTypes_Video = _archiveService.FillFileTypeByContentType(ConentTypeEnum.Video);
            _fileTypes_Image = _archiveService.FillFileTypeByContentType(ConentTypeEnum.Image);
            _isFirst = false;
        }

        private void ButtonAddFileType_Click(object sender, EventArgs e)
        {
            FormFileType frm = new FormFileType();
            frm.ShowDialog();
            frm.Close();

            if (_contentType == null)
                radDropDownListFileType.DataSource = _fileTypes_Sound;
            else
            {
                switch (_contentType.ContentTypeTitle?.ToLower())
                {
                    case "sound":
                        radDropDownListFileType.DataSource = _fileTypes_Sound;
                        break;
                    case "text":
                        radDropDownListFileType.DataSource = _fileTypes_Text;
                        break;
                    case "image":
                        radDropDownListFileType.DataSource = _fileTypes_Image;
                        break;
                    case "video":
                        radDropDownListFileType.DataSource = _fileTypes_Video;
                        break;
                }
            }
            radDropDownListFileType.DisplayMember = "FileTypeTitle";
            radDropDownListFileType.ValueMember = "FileTypeId";
            radDropDownListFileType.Text = "انتخاب کنید";
        }

        private void ButtonAddFile_Click(object sender, EventArgs e)
        {
            AddButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void radDropDownListFileType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (_isFirst) return;
            radDropDownListFileType.BackColor = Color.White;
            int.TryParse(radDropDownListFileType?.SelectedItem?.Value.ToString(), out int _fileTypeId);
            FileTypeId = _fileTypeId;
        }
    }
}
