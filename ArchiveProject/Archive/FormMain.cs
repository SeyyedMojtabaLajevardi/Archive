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
    public partial class FormMain : Form
    {
        private readonly ArchiveService _archiveService;
        List<PermissionType> permissionTypes=new List<PermissionType>();
        List<PermissionLevel> permissionLevels=new List<PermissionLevel>();
        List<Subject> subjects = new List<Subject>();
        List<PublishState> publishStates = new List<PublishState>();
        List<Category> categories = new List<Category>();
        List<Collection> collections = new List<Collection>();
        
        public FormMain()
        {
            InitializeComponent();
            _archiveService = new ArchiveService(new ArchiveEntities());
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            permissionTypes = _archiveService.FillPermissionType();
            permissionLevels = _archiveService.FillPermissionLevel();
            subjects = _archiveService.FillSubject();
            publishStates = _archiveService.FillPublishState();
            collections = _archiveService.FillCollection();
        }
    }
}
