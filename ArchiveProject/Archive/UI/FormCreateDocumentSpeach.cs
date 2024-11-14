using Archive.BLL;
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

namespace Archive
{
    public partial class FormCreateDocumentSpeach : Form
    {
        private readonly ArchiveService _archiveService;
        List<PermissionType> permissionTypes = new List<PermissionType>();
        List<PermissionState> permissionLevels = new List<PermissionState>();
        List<Subject> subjects = new List<Subject>();
        List<PublishState> publishStates = new List<PublishState>();
        List<Category> categories = new List<Category>();
        List<Collection> collections = new List<Collection>();
        List<PadidAvar> padidAvars = new List<PadidAvar>();

        public FormCreateDocumentSpeach()
        {
            InitializeComponent();
            _archiveService = new ArchiveService(new ArchiveEntities());
        }

        private void FormCreateDocumentSpeach_Load(object sender, EventArgs e)
        {
            //permissionLevels.Add(new PermissionLevel { PermissionLevelId = 0, PermissionLevelTitle = "انتخاب کنید" });
            permissionLevels = _archiveService.FillPermissionLevel();


            padidAvars = _archiveService.FillPadidAvar();
            permissionTypes = _archiveService.FillPermissionType();
            subjects = _archiveService.FillSubject();
            publishStates = _archiveService.FillPublishState();
            collections = _archiveService.FillCollection();

            ComboBoxPermissionState.DataSource = permissionLevels;
            ComboBoxPermissionState.DisplayMember = "PermissionStateTitle";
            ComboBoxPermissionState.ValueMember = "PermissionStateId";
            ComboBoxPermissionState.Text = "انتخاب کنید";

            ComboBoxPadidAvar.DataSource = padidAvars;
            ComboBoxPadidAvar.DisplayMember = "PadidAvarId";
            ComboBoxPadidAvar.DisplayMember = "PadidAvarTitle";
        }

    }
}
