using Shop.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Repozitory
{
    public class EFCategoryRepository
    {
        private ShopDataModel _context;

        public EFCategoryRepository()
        {

        }
        public EFCategoryRepository(ShopDataModel context)
        {
            _context = context;
        }
        public int Add(CategoryClient category)
        {
            _context.CategoryClient.Add(category);
            return category.Id;
        }

        public void Delete(int id)
        {
            var category = GetDeteils(id);
            category.IsDeleted = true;

        }

        public virtual List<CategoryClient> Get()
        {
            return _context.CategoryClient.Where(x => x.IsDeleted == false).ToList();
        }

        public CategoryClient GetDeteils(int id)
        {
            var category = _context.CategoryClient.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return null;
            }
            else if (category.IsDeleted == false)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public void Update(CategoryClient category)
        {
            var tempCategory = GetDeteils(category.Id);
            tempCategory.CategoryName = category.CategoryName;
        }
    }
}
