using Archive.DataAccess;
using System.Collections.Generic;

namespace Archive.BusinessLogic
{
    public interface IDocumentSubjectRelationService
    {
        void AddRelation(int documentId, int subjectId);
        void RemoveRelation(int documentId, int subjectId);
        List<Subject> GetSubjectsByDocumentId(int documentId);
        List<Document> GetDocumentsBySubjectId(int subjectId);
    }
}