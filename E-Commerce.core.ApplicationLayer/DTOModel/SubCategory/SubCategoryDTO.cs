using E_Commerce.core.DomainLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System;

namespace E_Commerce.core.ApplicationLayer.DTOModel.SubCategory
{
    public class SubCategoryDTO
    {
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
       
    }
}
