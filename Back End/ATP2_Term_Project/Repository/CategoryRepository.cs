using ATP2_Term_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATP2_Term_Project.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public List<Category> GetCategoryWithProducts(int id)
        {
            throw new NotImplementedException();
        }
    }
}