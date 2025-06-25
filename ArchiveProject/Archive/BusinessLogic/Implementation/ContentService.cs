using Archive.DataAccess;
using Archive.DataAccess.Dto;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using Telerik.Windows.Diagrams.Core;
using System.Linq;

namespace Archive.BusinessLogic
{
    public class ContentService : IContentService
    {
        private readonly ArchiveEntities _context;

        public ContentService(ArchiveEntities context)
        {
            _context = context;
        }

        public void AddContent(Content content)
        {
            _context.Contents.Add(content);
            _context.SaveChanges();
        }

        public void AddFilesToContentByContentId(int contentId, List<File> fileList)
        {
            Content content = GetContentByContentId(contentId);
            try
            {
                content.Files.AddRange(fileList);
            }
            catch (Exception ex)
            {
                content.Files = fileList;
            }
            _context.SaveChanges();
        }

        public void DeleteContent(int contentId)
        {
            var content = _context.Contents.Find(contentId);
            if (content != null)
            {
                _context.Contents.Remove(content);
                _context.SaveChanges();
            }
        }

        public Content GetContentByContentId(int contentId)
        {
            return _context.Contents.FirstOrDefault(x => x.ContentId == contentId);
        }

        public List<ContentDto> GetContentByDocumentId(int documentId)
        {
            using (ArchiveEntities context = new ArchiveEntities())
            {
                List<ContentDto> contents = new List<ContentDto>();
                var query = from f in context.Files
                            join c in context.Contents on f.ContentId equals c.ContentId
                            join ft in context.FileTypes on f.FileTypeId equals ft.FileTypeId
                            join ct in context.ContentTypes on c.ContentTypeId equals ct.ContentTypeId
                            join r in context.Resources on f.ResourceId equals r.ResourceId into rj
                            from r in rj.DefaultIfEmpty()
                            where c.DocumentId == documentId
                            select new ContentDto
                            {
                                FileNumber = f.FileNumber,
                                DeletionDescription = f.DeletionDescription,
                                Comment = f.Comment,
                                Text = f.Text,
                                FileName = f.FileName,
                                FileTypeId = ft.FileTypeId,
                                FileCode = f.FileCode,
                                CategoryId = f.CategoryId,
                                ContentId = c.ContentId,
                                ContentTypeTitle = ct.ContentTypeTitle,
                                FileTypeTitle = ft.FileTypeTitle,
                                ResourceTitle = r != null ? r.ResourceTitle : null,
                                ResourceId = r != null ? r.ResourceId : -1,
                                DocumentId = c.DocumentId,
                                Code = c.Code,
                                Description = c.Description,
                                ContentTypeId = ct.ContentTypeId,
                            };

                var results = query.ToList();
                return results;
            }
        }

        public bool UpdateContent(int contentId, Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetContentByContentTypeIdAndDocumentId(int contentTypeId, int documentId)
        {
            using (ArchiveEntities context = new ArchiveEntities())
            {
                List<Content> contents = new List<Content>();
                var content = context.Contents.FirstOrDefault(x => x.ContentTypeId == contentTypeId && x.DocumentId == documentId);
                return content;
            }
        }

    }
}
