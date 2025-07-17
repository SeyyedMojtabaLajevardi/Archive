using Archive.BusinessLogic.Dto;
using Archive.BusinessLogic.Enumerations;
using Archive.DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace Archive.BusinessLogic
{
    public class ArchiveService
    {
        private readonly ArchiveEntities _context;
        private readonly Repository<UserDto> _userDtoRepository;
        public ArchiveService(ArchiveEntities context)
        {
            _context = context;
        }

        public List<PermissionType> GetPermissionType()
        {
            var repository = new Repository<PermissionType>(_context);
            return repository.GetAll();
        }

        public List<PadidAvar> GetPadidAvar()
        {
            var padidAvar = new Repository<PadidAvar>(_context);
            return padidAvar.GetAll();
        }

        public List<Publisher> GetPublisher()
        {
            var publisher = new Repository<Publisher>(_context);
            return publisher.GetAll();
        }

        public List<PublicationPlace> GetPublicationPlace()
        {
            var publicationPlace = new Repository<PublicationPlace>(_context);
            return publicationPlace.GetAll();
        }

        public List<PermissionState> GetPermissionState()
        {
            var repository = new Repository<PermissionState>(_context);
            return repository.GetAll();
        }

        public List<Subject> GetSubject()
        {
            var repository = new Repository<Subject>(_context);
            return repository.GetAll();
        }

        public List<PublishState> GetPublishState()
        {
            var repository = new Repository<PublishState>(_context);
            return repository.GetAll();
        }

        public List<Category> GetCategory(int? parentId, int levelNo)
        {
            var repository = new Repository<Category>(_context);
            return repository.GetByCondition(x => x.ParentId == parentId && x.LevelNo == levelNo);
        }

        public Category GetCategoryByEnglishTitle(string title)
        {
            var repository = new Repository<Category>(_context);
            return repository.GetByCondition(x => x.CategoryEnglishTitle.ToLower() == title.ToLower()).FirstOrDefault();
        }

        public List<CodeRange> GetCodeRange()
        {
            var repository = new Repository<CodeRange>(_context);
            return repository.GetAll();
        }

        public CodeRange GetCodeRangeByCategoryId(int categoryId)
        {
            var repository = new Repository<CodeRange>(_context);
            return repository.GetByCondition(x => x.CategoryId == categoryId).FirstOrDefault();
        }

        public List<Collection> GetCollection()
        {
            var repository = new Repository<Collection>(_context);
            return repository.GetAll();
        }

        public List<FileType> GetFileType()
        {
            var repository = new Repository<FileType>(_context);
            return repository.GetAll();
        }

        public List<FileType> GetFileTypeByContentType(ConentTypeEnum conentTypeEnum)
        {
            var repository = new Repository<FileType>(_context);
            return repository.GetByCondition(x => x.ContentTypeId == (int)conentTypeEnum + 1);
        }

        public List<Language> GetLanguage()
        {
            var repository = new Repository<Language>(_context);
            return repository.GetAll();
        }

        public List<UserDto> GetUser()
        {
            return _userDtoRepository.GetUserDtos();
        }

        public List<Editor> GetEditor()
        {
            var repository = new Repository<Editor>(_context);
            return repository.GetAll();
        }
    }
}
