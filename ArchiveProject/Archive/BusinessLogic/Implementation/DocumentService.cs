using Archive.DataAccess;
using Archive.DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Archive.BusinessLogic
{
    public class DocumentService : IDocumentService
    {
        private readonly ArchiveEntities _context;

        public DocumentService(ArchiveEntities context)
        {
            _context = context;
        }

        public int AddDocument(Document document)
        {
            _context.Documents.Add(document);
            _context.SaveChanges();
            return document.DocumentId;
        }

        public void DeleteDocument(int documentId)
        {
            var document = _context.Documents.Find(documentId);
            if (document != null)
            {
                _context.Documents.Remove(document);
                _context.SaveChanges();
            }
        }

        public Document GetDocumentById(int documentId)
        {
            return _context.Documents.Find(documentId);
        }

        public Document GetDocumentBySiteCode(string siteCode)
        {
            return _context.Documents.FirstOrDefault(x => x.SiteCode == siteCode);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void UpdateDocument(DocumentDto documentDto)
        {
            var existingDocument = _context.Documents.FirstOrDefault(x => x.DocumentId == documentDto.DocumentId);
            existingDocument = GetDocumentBySiteCode(documentDto.SiteCode);
            if (existingDocument != null)
            {
                existingDocument.UserId = documentDto.UserId;
                existingDocument.DocumentCode = documentDto.DocumentCode;
                existingDocument.CreatedDate = documentDto.CreatedDate;
                existingDocument.SiteCode = documentDto.SiteCode;
                existingDocument.OldTitle = documentDto.OldTitle;
                existingDocument.NewTitle = documentDto.NewTitle;
                existingDocument.SubTitle = documentDto.SubTitle;
                existingDocument.PublishStateId = documentDto.PublishStateId == 0 ? null : documentDto.PublishStateId;
                existingDocument.PermissionStateId = documentDto.PermissionStateId == 0 ? null : documentDto.PermissionStateId;
                existingDocument.CreatorUserId = documentDto.CreatorUserId == 0 ? null : documentDto.CreatorUserId ;
                existingDocument.PadidAvarId = documentDto.PadidAvarId == 0 ? null : documentDto.PadidAvarId;
                existingDocument.LanguageId = documentDto.LanguageId == 0 ? null : documentDto.LanguageId;
                existingDocument.Comment = documentDto.Comment;
                existingDocument.SessionNumber = documentDto.SessionNumber;
                existingDocument.SessionCount = documentDto.SessionCount;
                existingDocument.SessionPlace = documentDto.SessionPlace;
                existingDocument.SessionDate = documentDto.SessionDate;
                existingDocument.RelatedLink = documentDto.RelatedLink;
                existingDocument.Description = documentDto.Description;
                existingDocument.MainCategoryId = documentDto.MainCategoryId == 0 ? null : documentDto.MainCategoryId;
                existingDocument.ContentTypeId = documentDto.ContentTypeId == 0 ? null : documentDto.ContentTypeId;
                existingDocument.PublishYear = documentDto.PublishYear;
                existingDocument.PublishPlace = documentDto.PublishPlace;
                existingDocument.BookPublisher = documentDto.BookPublisher;
                existingDocument.BookVolumeNumber = documentDto.BookVolumeNumber;
                existingDocument.BookPageNumber = documentDto.BookPageNumber;
                existingDocument.BookVolumeCount = documentDto.BookVolumeCount;
                existingDocument.FipaCode = documentDto.FipaCode;
                existingDocument.TranslateLanguageId = documentDto.TranslateLanguageId == 0 ? null : documentDto.TranslateLanguageId;
                existingDocument.Translator = documentDto.Translator;
                existingDocument.Narrator = documentDto.Narrator;
                existingDocument.SecondCategoryId = documentDto.SecondCategoryId == 0 ? null : documentDto.SecondCategoryId;
                existingDocument.FirstCategoryId = documentDto.FirstCategoryId == 0 ? null : documentDto.FirstCategoryId;

                _context.SaveChanges();
            }
        }
    }
}
