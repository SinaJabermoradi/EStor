using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EStor.Domain.Entities.Commons;

namespace EStor.Domain.Entities.Products
{
    public class Category : BaseEntity  // دسته بندی
    {
        public string Name { get; set; } // نام دسته بندی



        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }
        public ICollection<Category> SubCategories { get; set; }  
    }
}
