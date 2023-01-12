using E_Commerce.core.ApplicationLayer.DTOModel;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface ICategory
    {
        public ApiResponse<List<CategoryDTO>> Get();
        public ApiResponse<bool> Delete(int categoryId);
        public Task<ApiResponse<bool>> Post(CategoryDTO categoryDTO);
        public ApiResponse<bool> GetByCategoryName(string name);
        public Task<ApiResponse<bool>> Update(int id, CategoryDTO categoryDTO);

    }
}
