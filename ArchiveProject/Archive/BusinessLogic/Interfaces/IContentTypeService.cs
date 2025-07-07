using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.BusinessLogic
{
    public interface IContentTypeService
    {
        void AddContentType(ContentType contentType);
        void DeleteContentType(int contentTypeId);
        File GetContentTypeById(int contentTypeId);
        bool UpdateContentType(int ccontentTypeId, ContentType ccontentType);
    }
}
