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

namespace Archive.UI
{
    public partial class FormDocumentList : Form
    {
        private ArchiveService _archiveService;
        private List<Category> _mainCategories = new List<Category>();

        private ContentType _contentType;
        private int _mainCategoryId;
        private string _mainCategoryTitle;
        public FormDocumentList()
        {
            InitializeComponent();
        }

        private void FormDocumentList_Load(object sender, EventArgs e)
        {
            _archiveService = new ArchiveService(new ArchiveEntities());
            _mainCategories = _archiveService.FillCategory(null, 1);
        }

        private void ButtonCreateDocument_Click(object sender, EventArgs e)
        {
            FormCreateDocument formCreateDocument = new FormCreateDocument(_mainCategoryId);
            formCreateDocument.ShowDialog();
        }

        private void ButtonSpeach_Click(object sender, EventArgs e)
        {
            FetchCategoryData(ButtonSpeach.Tag.ToString());
        }

        private void ButtonLesson_Click(object sender, EventArgs e)
        {
            FetchCategoryData(ButtonLesson.Tag.ToString());
        }

        private void ButtonBook_Click(object sender, EventArgs e)
        {
            FetchCategoryData(ButtonBook.Tag.ToString());
        }

        private void ButtonQA_Click(object sender, EventArgs e)
        {
            FetchCategoryData(ButtonQA.Tag.ToString());
        }

        private void ButtonAref_Click(object sender, EventArgs e)
        {
            FetchCategoryData(ButtonAref.Tag.ToString());
        }

        private void ButtonOtherDocument_Click(object sender, EventArgs e)
        {
            FetchCategoryData(ButtonOtherDocument.Tag.ToString());
        }

        private void FetchCategoryData(string categoryTitle)
        {
            using (ArchiveEntities context = new ArchiveEntities())
            {
                _mainCategoryId = context.Categories
                                     .Where(x => x.CategoryEnglishTitle == categoryTitle)
                                     .Select(x => x.CategoryId)
                                     .FirstOrDefault();

                _mainCategoryTitle = context.Categories
                                       .Where(x => x.CategoryEnglishTitle == categoryTitle)
                                       .Select(x => x.CategoryTitle)
                                       .FirstOrDefault();
            }
        }


    }
}
