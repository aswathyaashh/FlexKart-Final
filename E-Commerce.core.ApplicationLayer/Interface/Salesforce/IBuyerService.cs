using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.Interface.Salesforce
{
    public interface IBuyerService
    {
        Task<AuthenticationRes> Authentication();

        public Task<BrandDTORes> AddBrand(BrandDTOReq brandDTOReq);
       public Task<BrandDTORes> EditBrand(BrandDTOReq brandDTOReq, string id);
        public Task<BrandDTORes> DeleteBrand(string id);

        public Task<CategoryDTORes> AddCategory(CategoryDTOReq categoryDTOReq);
        public Task<CategoryDTORes> EditCategory(CategoryDTOReq categoryDTOReq, string id);
        public Task<CategoryDTORes> DeleteCategory(string id);

        public Task<SubCategoryDTORes> AddSubCategory(SubCategoryDTOReq subCategoryDTOReq);
        public Task<SubCategoryDTORes> EditSubCategory(SubCategoryDTOReq subCategoryDTOReq, string id);
        public Task<SubCategoryDTORes> DeleteSubCategory(string id);

    }
}
