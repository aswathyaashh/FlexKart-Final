using Microsoft.AspNetCore.Http;
using E_Commerce.core.ApplicationLayer.DTOModel.Product;
using E_Commerce.core.ApplicationLayer.DTOModel.SubCategory;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface IProduct
    {
        public ApiResponse<List<ProductListDTO>> Get();
        public ApiResponse<bool> Delete(int productId);
        public ApiResponse<bool> GetByProductName(string Name);
        public ApiResponse<List<ProductViewDTO>> GetProductById(int id, String Scheme, HostString Host, PathString PathBase);

        public ApiResponse<List<SubCategoryDTO>> GetSubcategory(int categoryId);

        public Task<ApiResponse<bool>> Post(ProductDTO product, String Scheme, HostString Host, PathString PathBase);

        public Task<ApiResponse<bool>> Update(int id, ProductDTO productDTO, String Scheme, HostString Host, PathString PathBase);



    }
}
