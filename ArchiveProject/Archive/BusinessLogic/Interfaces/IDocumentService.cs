using Archive.DataAccess;
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
        Document GetDocumentBySiteCode(string siteCode);
        void UpdateDocument(DocumentDto documentDto);
        void Save();
    }
}
