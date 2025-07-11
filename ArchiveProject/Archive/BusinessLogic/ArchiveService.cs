﻿using Archive.BusinessLogic.Dto;
using Archive.BusinessLogic.Enumerations;
using Archive.DataAccess;
using System.Collections.Generic;

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

        public List<FileType> FillFileTypeByContentType(ConentTypeEnum conentTypeEnum)
        {
            var repository = new Repository<FileType>(_context);
            return repository.GetByCondition(x => x.ContentTypeId == (int)conentTypeEnum + 1);
        }

        public List<Language> FillLanguage()
        {
            var repository = new Repository<Language>(_context);
            return repository.GetAll();
        }

        public List<UserDto> FillUser()
        {
            return _userDtoRepository.GetUserDtos();
        }

        //public List<Editor> FillEditor()
        //{
        //    var repository = new Repository<Editor>(_context);
        //    return repository.GetAll();
        //}
    }
}
