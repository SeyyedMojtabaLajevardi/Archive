
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DataAccess.Dto
{
    public class FileDto : File
    {
        public string FileTypeTitle { get; set; }
        public string ContentTypeTitle { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

    }
}
