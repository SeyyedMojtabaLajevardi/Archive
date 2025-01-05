using Archive.BusinessLogic.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DataAccess
{
    public class Repository<T> where T : class
    {
        private readonly ArchiveEntities _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ArchiveEntities context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToList();
        }

        public List<UserDto> GetUserDtos()
        {
            return (from u in _context.UserInfoes
                    join p in _context.PermissionTypes on u.PermissionTypeId equals p.PermissionTypeId
                    select new UserDto
                    {
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Password = u.PassWord,
                        UserId = u.UsreId,
                        UserName = u.UserName,
                        PermissionTypeTitle = p.PermissionTypeTitle
                    }).ToList();
        }

    }
}
