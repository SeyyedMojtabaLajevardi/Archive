using Archive.DataAccess;
using System;
using System.Linq;

namespace Archive.BusinessLogic
{
    public class CategoryService : ICategoryService
    {
        private readonly ArchiveEntities _context;

        public CategoryService(ArchiveEntities context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }


        public void DeleteCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }

        public Category GetCategoryById(int categoryId)
        {
            return _context.Categories.FirstOrDefault(x=>x.CategoryId == categoryId);
        }

        public bool UpdateCategory(int categoryId, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
