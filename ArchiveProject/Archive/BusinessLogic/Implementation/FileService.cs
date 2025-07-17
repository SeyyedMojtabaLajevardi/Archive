using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

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

        public File GetMaxFileByCategoryId(int categoryId)
        {
            return _context.Files.Where(x => x.CategoryId == categoryId).OrderByDescending(x => x.FileCode).FirstOrDefault();
        }

        public void UpdateFile(File file)
        {
            try
            {
                var existingFile = _context.Files.FirstOrDefault(x => x.FileId == file.FileId);
                if (existingFile == null)
                    throw new Exception("فایل مورد نظر یافت نشد.");

                _context.Entry(existingFile).CurrentValues.SetValues(file);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //existingFile.FileName = file.FileName;
            //existingFile.Text = file.Text;
            //existingFile.DeletionDescription = file.DeletionDescription;
            ////existingFile.Content = file.Content;
            //existingFile.ContentId = file.ContentId;
            //existingFile.IsUploaded = file.IsUploaded;
            //existingFile.CategoryId = file.CategoryId;
            //existingFile.EditorId = file.EditorId;
            ////existingFile.Editor = file.Editor;
            //existingFile.FileNumber = file.FileNumber;
            //existingFile.Comment = file.Comment;
            //existingFile.FileCode = file.FileCode;
            //existingFile.FileName = file.FileName;
            ////existingFile.FileType = file.FileType;
            //existingFile.FileTypeId = file.FileTypeId;
            ////existingFile.Resource = file.Resource;
            //existingFile.ResourceId = file.ResourceId;
            _context.SaveChanges();
        }

        File IFileService.GetFileByFileCode(int fileCode)
        {
            return _context.Files.Where(x => x.FileCode == fileCode).FirstOrDefault();
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
