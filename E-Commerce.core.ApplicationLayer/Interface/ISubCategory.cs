using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface ISubCategory
    {
        public ApiResponse<List<SubCategoryDTO>> Get();
        public ApiResponse<bool> Delete(int subCategoryId);
        public ApiResponse<bool> GetBySubCategoryName(string Name, int id);
        public Task<ApiResponse<bool>> Post(SubCategoryDTO subCategory);
        public Task<ApiResponse<bool>> Update(int id, SubCategoryDTO subCategory);

    }
}
