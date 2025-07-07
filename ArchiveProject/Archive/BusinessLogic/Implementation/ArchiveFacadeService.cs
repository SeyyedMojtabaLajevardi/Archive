using Archive.BusinessLogic;

namespace Archive.BusinessLogic.Implementation
{
    public class ArchiveFacadeService : IArchiveFacadeService
    {
        private readonly IDocumentService _documentService;
        private readonly IContentService _contentService;
        private readonly IFileService _fileService;
        private readonly ICategoryService _categoryService;
        private readonly IDocumentSubjectRelationService _documentSubjectRelationService;

        public ArchiveFacadeService(
            IDocumentService documentService,
            IContentService contentService,
            IFileService fileService,
            ICategoryService categoryService,
            IDocumentSubjectRelationService documentSubjectRelationService)
        {
            _documentService = documentService;
            _contentService = contentService;
            _fileService = fileService;
            _categoryService = categoryService;
            _documentSubjectRelationService = documentSubjectRelationService;
        }

        public IDocumentService DocumentService => _documentService;
        public IContentService ContentService => _contentService;
        public IFileService FileService => _fileService;
        public ICategoryService CategoryService => _categoryService;
        public IDocumentSubjectRelationService DocumentSubjectRelationService => _documentSubjectRelationService;
    }
}