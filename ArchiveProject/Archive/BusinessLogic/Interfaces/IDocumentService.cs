﻿using Archive.DataAccess;
using Archive.DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.BusinessLogic
{
    public interface IDocumentService
    {
        int AddDocument(Document document);
        void DeleteDocument(int documentId);
        Document GetDocumentById(int documentId);
        List<Document> GetAll();
        Document GetDocumentBySiteCode(string siteCode);
        Document GetDocumentByOldTitle(string oldTitle);
        Document GetDocumentByNewTitle(string newTitle);
        Document GetDocumentBySiteCodeAndMainCategory(string siteCode, int mainCategory);
        Document GetDocumentByOldTitleAndMainCategory(string oldTitle, int mainCategory);
        Document GetDocumentByNewTitleAndMainCategory(string newTitle, int mainCategory);
        void UpdateDocument(Document document);
        void Save();
    }
}
