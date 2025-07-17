using Archive.BusinessLogic;
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

namespace Archive
{
    public partial class FormMain : Form
    {

        private readonly IArchiveFacadeService _archiveFacadeService;
        public FormMain(IArchiveFacadeService archiveFacadeService)
        {
            InitializeComponent();
            _archiveFacadeService = archiveFacadeService;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        private void buttonSpeech_Click(object sender, EventArgs e)
        {
            FormCreateDocument_Speech frm = new FormCreateDocument_Speech(_archiveFacadeService);
            Hide();
            frm.ShowDialog();
            Show();
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {
            FormCreateDocument_Book frm = new FormCreateDocument_Book(_archiveFacadeService);
            Hide();
            frm.ShowDialog();
            Show();
        }
    }
}
