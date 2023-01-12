using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface ISubCategory
    {
        public ApiResponse<List<SubCategoryDTO>> Get();
        public ApiResponse<bool> Delete(int subCategoryId);
        public ApiResponse<bool> GetBySubCategoryName(string Name, int categoryId);
        public Task<ApiResponse<bool>> Post(SubCategoryDTO subCategory);
        public Task<ApiResponse<bool>> Update(int id, SubCategoryDTO subCategory);

    }
}
