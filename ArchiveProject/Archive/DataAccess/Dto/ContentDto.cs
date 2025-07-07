using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DataAccess.Dto
{
    public class ContentDto : Content
    {
        public string ContentTypeTitle { get; set; }
        public string ContentTypeTitlePresian { get; set; }
        public string FileTypeTitle { get; set; }
        public int ResourceId { get; set; }
        public string ResourceTitle { get; set; }
        public int FileTypeId { get; set; }
        public int FileNumber { get; set; }
        public string DeletionDescription { get; set; }
        public string Comment { get; set; }
        public string Text { get; set; }
        public string FileName { get; set; }
        public int? CategoryId { get; set; }
        public int? FileCode { get; set; }
        //public File File { get; set; }
    }
}
