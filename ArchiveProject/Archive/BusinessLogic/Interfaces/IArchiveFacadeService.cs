using Archive.BusinessLogic;

public interface IArchiveFacadeService
{
    IDocumentService DocumentService { get; }
    IContentService ContentService { get; }
    IFileService FileService { get; }
    ICategoryService CategoryService { get; }
    IDocumentSubjectRelationService DocumentSubjectRelationService { get; }
}