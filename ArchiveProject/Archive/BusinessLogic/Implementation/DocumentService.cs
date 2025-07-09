using Archive.DataAccess;
using Archive.DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Diagrams.Core;

namespace Archive.BusinessLogic
{
    public class DocumentService : IDocumentService
    {
        private readonly ArchiveEntities __context;

        public DocumentService(ArchiveEntities context)
        {
            __context = context;
        }

        public int AddDocument(Document document)
        {
            using (var context = new ArchiveEntities())
            {
                context.Documents.Add(document);
                context.SaveChanges();
            }
            return document.DocumentId;
        }

        public void DeleteDocument(int documentId)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents.Find(documentId);
                if (document != null)
                {
                    context.Documents.Remove(document);
                    context.SaveChanges();
                }
            }
        }

        public List<Document> GetAll()
        {
            using (var context = new ArchiveEntities())
            {
                return context.Documents.ToList();
            }
        }

        public Document GetDocumentById(int documentId)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include("Contents")
                            .Include("UserInfo")
                            .Include("PermissionState")
                            .Include("PadidAvar")
                            .Include("Language")
                            .Include("Category")
                            .Include("PublishState")
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .FirstOrDefault(d => d.DocumentId == documentId);
                return document;
            }
        }

        public Document GetDocumentBySiteCode(string siteCode)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include("Contents")
                            .Include("UserInfo")
                            .Include("PermissionState")
                            .Include("PadidAvar")
                            .Include("Language")
                            .Include("Category")
                            .Include("PublishState")
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .FirstOrDefault(d => d.SiteCode == siteCode);
                return document;
            }
        }
        Document IDocumentService.GetDocumentByOldTitle(string oldTitle)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include("Contents")
                            .Include("UserInfo")
                            .Include("PermissionState")
                            .Include("PadidAvar")
                            .Include("Language")
                            .Include("Category")
                            .Include("PublishState")
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .FirstOrDefault(d => d.OldTitle == oldTitle);
                return document;
                //return context.Documents.FirstOrDefault(x => x.OldTitle == oldTitle);
            }
        }
        Document IDocumentService.GetDocumentByNewTitle(string newTitle)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include("Contents")
                            .Include("UserInfo")
                            .Include("PermissionState")
                            .Include("PadidAvar")
                            .Include("Language")
                            .Include("Category")
                            .Include("PublishState")
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .FirstOrDefault(d => d.NewTitle == newTitle);
                return document;
                //return context.Documents.FirstOrDefault(x => x.NewTitle == newTitle);
            }
        }

        public void Save()
        {
            using (var context = new ArchiveEntities())
            {
                context.SaveChanges();
            }
        }

        public void UpdateDocument(DocumentDto documentDto)
        {
            using (var context = new ArchiveEntities())
            {
                var existingDocument = context.Documents.FirstOrDefault(x => x.DocumentId == documentDto.DocumentId);
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
                    existingDocument.CreatorUserId = documentDto.CreatorUserId == 0 ? null : documentDto.CreatorUserId;
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
                    existingDocument.DocumentSubjectRelations.Clear();
                    var currentDocumentSubjectRelations = context.DocumentSubjectRelations.Where(x => x.DocumentId == documentDto.DocumentId).ToList();
                    context.DocumentSubjectRelations.RemoveRange(currentDocumentSubjectRelations);
                    context.DocumentSubjectRelations.AddRange(documentDto.DocumentSubjectRelations);

                    context.SaveChanges();
                }
            }
        }

    }
}
