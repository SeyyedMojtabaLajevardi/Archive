using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Archive.BusinessLogic
{
    public class FileService : IFileService
    {
        private readonly ArchiveEntities _context;

        public FileService(ArchiveEntities context)
        {
            _context = context;
        }

        public void AddFile(File file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();
        }


        public void DeleteFile(int fileId)
        {
            var file = GetFileById(fileId);
            if (file != null)
            {
                _context.Files.Remove(file);
                _context.SaveChanges();
            }
        }

        public File GetFileById(int fileId)
        {
            return _context.Files.FirstOrDefault(x => x.FileId == fileId);
        }

        public File GetFileByContentIdAndFileTypeIdAndFileNumber(int contentId, int fileTypeId, int fileNumber)
        {
            return _context.Files.FirstOrDefault(x => x.ContentId == contentId && x.FileTypeId == fileTypeId && x.FileNumber == fileNumber);
        }

        public bool UpdateFile(int fileId, File file)
        {
            throw new NotImplementedException();
        }
        //public void AddFilesByContentId(int contentId, List<File> fileList)
        //{
        //    using (ArchiveEntities context = new ArchiveEntities())
        //    {
        //        try
        //        {
        //            context.Files.AddRange(fileList);
        //            _context.SaveChanges();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception(ex.Message.ToString());
        //        }

        //    }
        //}
    }

    //}
    //}
}
