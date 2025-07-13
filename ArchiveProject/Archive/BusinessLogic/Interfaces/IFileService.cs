using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Diagrams.Core;

namespace Archive.BusinessLogic
{
    public interface IFileService
    {
        void AddFile(File file);
        void DeleteFile(int fileId);
        File GetFileById(int fileId);
        bool UpdateFile(int fileId, File file);
        File GetFileByContentIdAndFileTypeIdAndFileNumber(int contentId, int fileTypeId, int fileNumber);
        File GetFileByFileCode(int fileCode);
        File GetMaxFileByCategoryId(int categoryId);
        //void AddFilesByContentId(int contentId, List<File> fileList);
    }
}
