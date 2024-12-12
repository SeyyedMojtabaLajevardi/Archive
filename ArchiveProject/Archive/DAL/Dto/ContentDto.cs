using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DAL.Dto
{
    internal class ContentDto : Content
    {
        public string ContentTypeTitle { get; set; }
        public string FileTypeTitle { get; set; }
        public string ResourceTitle { get; set; }
    }
}
