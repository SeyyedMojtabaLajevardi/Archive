using Archive.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.BusinessLogic
{
    public interface ICategoryService
    {
        void AddCategory(Category category);
        void DeleteCategory(int categoryId);
        Category GetCategoryById(int categoryId);
        bool UpdateCategory(int categoryId, Category category);
    }
}
