using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Diagrams.Core;

namespace Archive.BusinessLogic
{
    public interface ISubjectService
    {
        void AddSubject(Subject Subject);
        void DeleteSubject(int SubjectId);
        Subject GetSubjectById(int SubjectId);
        bool UpdateSubject(int SubjectId, Subject Subject);
    }
}
