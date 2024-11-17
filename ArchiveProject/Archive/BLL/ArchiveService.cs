using Archive.BLL.Dto;
using Archive.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.BLL
{
    public class ArchiveService
    {
        private readonly ArchiveEntities _context;
        private readonly Repository<UserDto> _userDtoRepository;
        public ArchiveService(ArchiveEntities context)
        {
            _context = context;
        }

        public List<PermissionType> FillPermissionType()
        {
            var repository = new Repository<PermissionType>(_context);
            return repository.GetAll();
        }

        public List<PadidAvar> FillPadidAvar()
        {
            var padidAvar = new Repository<PadidAvar>(_context);
            return padidAvar.GetAll();
        }

        public List<PermissionState> FillPermissionState()
        {
            var repository = new Repository<PermissionState>(_context);
            return repository.GetAll();
        }

        public List<Subject> FillSubject()
        {
            var repository = new Repository<Subject>(_context);
            return repository.GetAll();
        }

        public List<PublishState> FillPublishState()
        {
            var repository = new Repository<PublishState>(_context);
            return repository.GetAll();
        }

        public List<Category> FillCategory(int? parentId, int levelNo)
        {
            var repository = new Repository<Category>(_context);
            return repository.GetByCondition(x => x.ParentId == parentId && x.LevelNo == levelNo);
        }

        public List<Collection> FillCollection()
        {
            var repository = new Repository<Collection>(_context);
            return repository.GetAll();
        }

        public List<FileType> FillFileType()
        {
            var repository = new Repository<FileType>(_context);
            return repository.GetAll();
        }

        public List<UserDto> FillUser()
        {
            return _userDtoRepository.GetUserDtos();
        }

        public List<Editor> FillEditor()
        {
            var repository = new Repository<Editor>(_context);
            return repository.GetAll();
        }

    }
}
