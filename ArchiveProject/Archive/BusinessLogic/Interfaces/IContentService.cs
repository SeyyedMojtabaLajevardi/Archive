using Archive.DataAccess;
using Archive.DataAccess.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.BusinessLogic
{
    public interface IContentService
    {
        void AddContent(Content content);
        void DeleteContent(int contentId);
        Content GetContentByContentId(int contentId);
        List<ContentDto> GetContentByDocumentId(int documentId);
        Content GetContentByContentTypeIdAndDocumentId(int contentTypeId, int documentId);
        bool UpdateContent(int contentId, Content content);
        void AddFilesToContentByContentId(int contentId, List<File> fileList);
    }
}
