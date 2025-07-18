﻿using Archive.BusinessLogic;
using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            _mainCategories = _archiveService.GetCategory(null, 1);
        }

        private void ButtonCreateDocument_Click(object sender, EventArgs e)
        {
            FormCreateDocument_Speech formCreateDocument = new FormCreateDocument_Speech(_mainCategoryId);
            formCreateDocument.ShowDialog();
        }

        private void ButtonSpeech_Click(object sender, EventArgs e)
        {
            FetchCategoryData(ButtonSpeech.Tag.ToString());
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
