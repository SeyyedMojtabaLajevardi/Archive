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
                            .Include(x => x.Contents)
                            .Include(x => x.UserInfo)
                            .Include(x => x.PermissionState)
                            .Include(x => x.PadidAvar)
                            .Include(x => x.Publisher)
                            .Include(x => x.PublicationPlace)
                            .Include(x => x.Language)
                            .Include(x => x.Category)
                            .Include(x => x.PublishState)
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .Include("DocumentNarratorRelations.Narrator")
                            .FirstOrDefault(d => d.DocumentId == documentId);
                return document;
            }
        }

        public Document GetDocumentBySiteCodeAndMainCategory(string siteCode, int mainCategory)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include(x=>x.Contents)
                            .Include(x=>x.UserInfo)
                            .Include(x=>x.PermissionState)
                            .Include(x=>x.PadidAvar)
                            .Include(x=>x.Publisher)
                            .Include(x =>x.PublicationPlace)
                            .Include(x=>x.Language)
                            .Include("Category")
                            .Include(x=>x.PublishState)
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .Include("DocumentNarratorRelations.Narrator")
                            //.AsNoTracking()
                            .FirstOrDefault(d => d.SiteCode == siteCode && d.MainCategoryId == mainCategory);
                return document;
            }
        }

        public Document GetDocumentBySiteCode(string siteCode)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include(x => x.Contents)
                            .Include(x => x.UserInfo)
                            .Include(x => x.PermissionState)
                            .Include(x => x.PadidAvar)
                            .Include(x => x.Publisher)
                            .Include(x => x.PublicationPlace)
                            .Include(x => x.Language)
                            .Include(x => x.Category)
                            .Include(x => x.PublishState)
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .Include("DocumentNarratorRelations.Narrator")
                            //.AsNoTracking()
                            .FirstOrDefault(d => d.SiteCode == siteCode);
                return document;
            }
        }
        Document IDocumentService.GetDocumentByOldTitleAndMainCategory(string oldTitle, int contentTypeId)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include(x => x.Contents)
                            .Include(x => x.UserInfo)
                            .Include(x => x.PermissionState)
                            .Include(x => x.PadidAvar)
                            .Include(x => x.Publisher)
                            .Include(x => x.PublicationPlace)
                            .Include(x => x.Language)
                            .Include(x => x.Category)
                            .Include(x => x.PublishState)
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .Include("DocumentNarratorRelations.Narrator")
                            .FirstOrDefault(d => d.OldTitle == oldTitle && d.ContentTypeId == contentTypeId);
                return document;
                //return context.Documents.FirstOrDefault(x => x.OldTitle == oldTitle);
            }
        }
        Document IDocumentService.GetDocumentByNewTitleAndMainCategory(string newTitle, int contentTypeId)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include(x => x.Contents)
                            .Include(x => x.UserInfo)
                            .Include(x => x.PermissionState)
                            .Include(x => x.PadidAvar)
                            .Include(x => x.Publisher)
                            .Include(x => x.PublicationPlace)
                            .Include(x => x.Language)
                            .Include(x => x.Category)
                            .Include(x => x.PublishState)
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .Include("DocumentNarratorRelations.Narrator")
                            .FirstOrDefault(d => d.NewTitle == newTitle && d.ContentTypeId == contentTypeId);
                return document;
                //return context.Documents.FirstOrDefault(x => x.NewTitle == newTitle);
            }
        }

        Document IDocumentService.GetDocumentByOldTitle(string oldTitle)
        {
            using (var context = new ArchiveEntities())
            {
                var document = context.Documents
                            .Include(x => x.Contents)
                            .Include(x => x.UserInfo)
                            .Include(x => x.PermissionState)
                            .Include(x => x.PadidAvar)
                            .Include(x => x.Publisher)
                            .Include(x => x.PublicationPlace)
                            .Include(x => x.Language)
                            .Include(x => x.Category)
                            .Include(x => x.PublishState)
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .Include("DocumentNarratorRelations.Narrator")
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
                            .Include(x => x.Contents)
                            .Include(x => x.UserInfo)
                            .Include(x => x.PermissionState)
                            .Include(x => x.PadidAvar)
                            .Include(x => x.Publisher)
                            .Include(x => x.PublicationPlace)
                            .Include(x => x.Language)
                            .Include(x => x.Category)
                            .Include(x => x.PublishState)
                            .Include("DocumentResourceRelations.Resource")
                            .Include("DocumentSubjectRelations.Subject")
                            .Include("DocumentNarratorRelations.Narrator")
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
                var existingDocument = context.Documents
                    .Include(d => d.DocumentSubjectRelations)
                    .Include(d => d.DocumentNarratorRelations)
                    .Include(d => d.DocumentResourceRelations)
                    .FirstOrDefault(x => x.DocumentId == document.DocumentId);

                if (existingDocument == null)
                    throw new Exception("سند مورد نظر یافت نشد.");

                // ✅ آپدیت خودکار فیلدهای ساده
                context.Entry(existingDocument).CurrentValues.SetValues(document);

                // ✅ حذف روابط قبلی
                context.DocumentSubjectRelations.RemoveRange(existingDocument.DocumentSubjectRelations);
                context.DocumentNarratorRelations.RemoveRange(existingDocument.DocumentNarratorRelations);

                // ✅ افزودن روابط جدید
                if (document.DocumentSubjectRelations != null)
                {
                    foreach (var rel in document.DocumentSubjectRelations)
                    {
                        rel.DocumentId = existingDocument.DocumentId;
                        context.DocumentSubjectRelations.Add(rel);
                    }
                }

                if (document.DocumentNarratorRelations != null)
                {
                    foreach (var rel in document.DocumentNarratorRelations)
                    {
                        rel.DocumentId = existingDocument.DocumentId;
                        context.DocumentNarratorRelations.Add(rel);
                    }
                }

                context.SaveChanges();
            }
        }

        /*public void UpdateDocument(Document document)
        {
            using (var context = new ArchiveEntities())
            {
                var existingDocument = context.Documents
                    .Include(d => d.DocumentSubjectRelations)
                    .Include(d => d.DocumentNarratorRelations)
                    .FirstOrDefault(d => d.DocumentId == document.DocumentId);

                if (existingDocument != null)
                {
                    //Update scalar properties
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
                    existingDocument.PublicationPlaceId = document.PublicationPlaceId;
                    existingDocument.PublisherId = document.PublisherId;
                    existingDocument.BookVolumeNumber = document.BookVolumeNumber;
                    existingDocument.BookPageCount = document.BookPageCount;
                    existingDocument.BookVolumeCount = document.BookVolumeCount;
                    existingDocument.FipaCode = document.FipaCode;
                    existingDocument.TranslateLanguageId = document.TranslateLanguageId == 0 ? null : document.TranslateLanguageId;
                    existingDocument.TranslatorId = document.TranslatorId;
                    existingDocument.SecondCategoryId = document.SecondCategoryId == 0 ? null : document.SecondCategoryId;
                    existingDocument.FirstCategoryId = document.FirstCategoryId == 0 ? null : document.FirstCategoryId;

                    var oldSubjectRelations = context.DocumentSubjectRelations.Where(a => a.DocumentId == document.DocumentId);
                    context.DocumentSubjectRelations.RemoveRange(oldSubjectRelations);

                    var oldDocumentNarratorRelations = context.DocumentNarratorRelations.Where(a => a.DocumentId == document.DocumentId);
                    context.DocumentNarratorRelations.RemoveRange(oldDocumentNarratorRelations);

               
                    // Add new subject relations
                    if (document.DocumentSubjectRelations != null)
                    {
                        foreach (var rel in document.DocumentSubjectRelations)
                        {
                            // اطمینان از اینکه موجودیت جدید است
                            rel.DocumentId = document.DocumentId;
                            context.DocumentSubjectRelations.Add(rel);
                        }
                    }

                    // Add new narrator relations
                    if (document.DocumentNarratorRelations != null)
                    {
                        foreach (var rel in document.DocumentNarratorRelations)
                        {
                            rel.DocumentId = document.DocumentId;
                            context.DocumentNarratorRelations.Add(rel);
                        }
                    }

                    context.SaveChanges();
                }
            }
        }*/



    }
}
