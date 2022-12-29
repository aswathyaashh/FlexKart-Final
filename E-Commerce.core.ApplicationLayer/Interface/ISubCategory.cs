using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface ISubCategory
    {
        public ApiResponse<List<SubCategoryDTO>> Get();
        public ApiResponse<bool> Delete(int subCategoryId);
        public ApiResponse<bool> GetBySubCategoryName(string Name);
        public ApiResponse<bool> Post(SubCategoryDTO subCategory);
        public ApiResponse<bool> Update(int id, SubCategoryDTO subCategory);

    }
}
