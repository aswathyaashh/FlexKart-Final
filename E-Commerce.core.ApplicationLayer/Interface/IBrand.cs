using Microsoft.AspNetCore.Http;
using E_Commerce.core.ApplicationLayer.DTOModel.Brand;
using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;

namespace E_Commerce.core.ApplicationLayer.Interface
{
    public interface IBrand
    {
        public ApiResponse<List<BrandDTO>> Get(String Scheme, HostString Host, PathString PathBase);
        public Task<ApiResponse<bool>> Post(BrandDTO brandName);
        public ApiResponse<bool> GetByBrandName(string name);
        public Task<ApiResponse<bool>> Update(BrandDTO brandId);
        public ApiResponse<bool> Delete(int brandId);

    }
}
