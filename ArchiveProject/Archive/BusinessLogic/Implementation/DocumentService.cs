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

        public void UpdateDocument(Document document)
        {
            using (var context = new ArchiveEntities())
            {
                var existingDocument = context.Documents.FirstOrDefault(x => x.DocumentId == document.DocumentId);
                if (existingDocument != null)
                {
                    existingDocument.UserId = document.UserId;
                    existingDocument.DocumentCode = document.DocumentCode;
                    existingDocument.CreatedDate = document.CreatedDate;
                    existingDocument.SiteCode = document.SiteCode;
                    existingDocument.OldTitle = document.OldTitle;
                    existingDocument.NewTitle = document.NewTitle;
                    existingDocument.SubTitle = document.SubTitle;
                    existingDocument.PublishStateId = document.PublishStateId == 0 ? null : document.PublishStateId;
                    existingDocument.PermissionStateId = document.PermissionStateId == 0 ? null : document.PermissionStateId;
                    existingDocument.CreatorUserId = document.CreatorUserId == 0 ? null : document.CreatorUserId;
                    existingDocument.PadidAvarId = document.PadidAvarId == 0 ? null : document.PadidAvarId;
                    existingDocument.LanguageId = document.LanguageId == 0 ? null : document.LanguageId;
                    existingDocument.Comment = document.Comment;
                    existingDocument.SessionNumber = document.SessionNumber;
                    existingDocument.SessionCount = document.SessionCount;
                    existingDocument.SessionPlace = document.SessionPlace;
                    existingDocument.SessionDate = document.SessionDate;
                    existingDocument.RelatedLink = document.RelatedLink;
                    existingDocument.Description = document.Description;
                    existingDocument.MainCategoryId = document.MainCategoryId == 0 ? null : document.MainCategoryId;
                    existingDocument.ContentTypeId = document.ContentTypeId == 0 ? null : document.ContentTypeId;
                    existingDocument.PublishYear = document.PublishYear;
                    existingDocument.PublishPlace = document.PublishPlace;
                    existingDocument.BookPublisher = document.BookPublisher;
                    existingDocument.BookVolumeNumber = document.BookVolumeNumber;
                    existingDocument.BookPageNumber = document.BookPageNumber;
                    existingDocument.BookVolumeCount = document.BookVolumeCount;
                    existingDocument.FipaCode = document.FipaCode;
                    existingDocument.TranslateLanguageId = document.TranslateLanguageId == 0 ? null : document.TranslateLanguageId;
                    existingDocument.Translator = document.Translator;
                    existingDocument.Narrator = document.Narrator;
                    existingDocument.SecondCategoryId = document.SecondCategoryId == 0 ? null : document.SecondCategoryId;
                    existingDocument.FirstCategoryId = document.FirstCategoryId == 0 ? null : document.FirstCategoryId;
                    existingDocument.DocumentSubjectRelations.Clear();
                    var currentDocumentSubjectRelations = context.DocumentSubjectRelations.Where(x => x.DocumentId == document.DocumentId).ToList();
                    context.DocumentSubjectRelations.RemoveRange(currentDocumentSubjectRelations);
                    context.DocumentSubjectRelations.AddRange(document.DocumentSubjectRelations);

                    context.SaveChanges();
                }
            }
        }

    }
}
