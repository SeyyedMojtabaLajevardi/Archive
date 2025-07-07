using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.BusinessLogic
{
    public interface IFileTypeService
    {
        void AddFileType(FileType filetype);
        void DeleteFileType(int fileTypeId);
        File GetFileTypeById(int fileTypeId);
        bool UpdateFileType(int fileTypeId, FileType fileType);
    }
}
