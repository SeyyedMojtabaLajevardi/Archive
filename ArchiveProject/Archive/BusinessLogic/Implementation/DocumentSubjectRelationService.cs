using Archive.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Archive.BusinessLogic
{
    public class DocumentSubjectRelationService : IDocumentSubjectRelationService
    {
        private readonly ArchiveEntities _context;

        public DocumentSubjectRelationService(ArchiveEntities context)
        {
            _context = context;
        }

        public void AddRelation(int documentId, int subjectId)
        {
            var relation = new DocumentSubjectRelation
            {
                DocumentId = documentId,
                SubjectId = subjectId
            };
            _context.DocumentSubjectRelations.Add(relation);
            _context.SaveChanges();
        }

        public void RemoveRelation(int documentId, int subjectId)
        {
            var relation = _context.DocumentSubjectRelations
                .FirstOrDefault(r => r.DocumentId == documentId && r.SubjectId == subjectId);
            if (relation != null)
            {
                _context.DocumentSubjectRelations.Remove(relation);
                _context.SaveChanges();
            }
        }

        public List<Subject> GetSubjectsByDocumentId(int documentId)
        {
            return _context.DocumentSubjectRelations
                .Where(r => r.DocumentId == documentId)
                .Select(r => r.Subject)
                .ToList();
        }

        public List<Document> GetDocumentsBySubjectId(int subjectId)
        {
            return _context.DocumentSubjectRelations
                .Where(r => r.SubjectId == subjectId)
                .Select(r => r.Document)
                .ToList();
        }
    }
}