using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DataAccess.Dto
{
    public class DocumentDto : Document
    {
        public List<Subject> SubjectList { get; set; }
        public string MainCategory { get; set; }
        public string FirstCategory { get; set; }
        public string SecondCategory { get; set; }
    }
}
