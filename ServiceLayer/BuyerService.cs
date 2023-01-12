using System.Net;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using E_Commerce.infrastructure.RepositoryLayer;
using E_Commerce.core.ApplicationLayer.BuyerModuleDTO;
using E_Commerce.core.ApplicationLayer.Interface.Salesforce;

namespace ServiceLayer
{
    public class BuyerService : IBuyerService
    {
        private readonly IConfiguration _configuration;
        private readonly AdminDbContext _adminDbContext;

        #region(constructor)

        public BuyerService(IConfiguration configuration, AdminDbContext adminDbContext)
        {
            _configuration = configuration;
            _adminDbContext = adminDbContext;
        }

        #endregion

        #region(Authentication Integration)

        public async Task<AuthenticationRes> Authentication()
        {
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            var dictBuyerConfig = new Dictionary<string, string>();
            dictBuyerConfig.Add("username", buyerConfig.GetSection("username").Value);
            dictBuyerConfig.Add("password", buyerConfig.GetSection("password").Value);
            dictBuyerConfig.Add("grant_type", buyerConfig.GetSection("grant_type").Value);
            dictBuyerConfig.Add("client_id", buyerConfig.GetSection("client_id").Value);
            dictBuyerConfig.Add("client_secret", buyerConfig.GetSection("client_secret").Value);
            string url = buyerConfig.GetSection("AuthenticationUrl").Value;
            using var client = new HttpClient();
            using HttpResponseMessage httpResponse = await client.PostAsync(url, new FormUrlEncodedContent(dictBuyerConfig));

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AuthenticationRes>(result);
            }

            return new AuthenticationRes();
        }

        #endregion



        #region(Brand Post)
        public async Task<BrandDTORes> AddBrand(BrandDTOReq brandDTOReq)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            string url = buyerConfig.GetSection("BrandAddUrl").Value;
            var payload = JsonConvert.SerializeObject(brandDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.PostAsync(url, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BrandDTORes>(result);
            }
            return new BrandDTORes();
        }
        #endregion

        #region(Brand Edit)
        public async Task<BrandDTORes> EditBrand(BrandDTOReq brandDTOReq, string id)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            String url = buyerConfig.GetSection("BrandEditUrl").Value;
            string postUrl = url + id;
            var payload = JsonConvert.SerializeObject(brandDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.PatchAsync(postUrl, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BrandDTORes>(result);
            }
            return new BrandDTORes();
        }
        #endregion

        #region(Brand Delete)
        public async Task<BrandDTORes> DeleteBrand(string id)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            String url = buyerConfig.GetSection("BrandDeleteUrl").Value;
            string postUrl = url + id;
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.DeleteAsync(postUrl);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BrandDTORes>(result);
            }
            return new BrandDTORes();
        }

        #endregion



        #region(Category Add)
        public async Task<CategoryDTORes> AddCategory(CategoryDTOReq categoryDTOReq)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            string url = buyerConfig.GetSection("CategoryAddUrl").Value;
            var payload = JsonConvert.SerializeObject(categoryDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.PostAsync(url, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CategoryDTORes>(result);
            }
            return new CategoryDTORes();
        }
        #endregion

        #region(Category Edit)

        public async Task<CategoryDTORes> EditCategory(CategoryDTOReq categoryDTOReq, string id)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            String url = buyerConfig.GetSection("CategoryEditUrl").Value;
            string postUrl = url + id;
            var payload = JsonConvert.SerializeObject(categoryDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.PatchAsync(postUrl, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CategoryDTORes>(result);
            }
            return new CategoryDTORes();
        }
        #endregion

        #region(Category Delete)
        public async Task<CategoryDTORes> DeleteCategory(string id)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            String url = buyerConfig.GetSection("CategoryDeleteUrl").Value;
            string postUrl = url + id;
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.DeleteAsync(postUrl);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CategoryDTORes>(result);
            }
            return new CategoryDTORes();
        }
        #endregion



        #region(SubCategory Add)

        public async Task<SubCategoryDTORes> AddSubCategory(SubCategoryDTOReq subCategoryDTOReq)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            string url = buyerConfig.GetSection("SubCategoryAddUrl").Value;
            var payload = JsonConvert.SerializeObject(subCategoryDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.PostAsync(url, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SubCategoryDTORes>(result);
            }
            return new SubCategoryDTORes();
        }
        #endregion

        #region(SubCategory Edit)

        public async Task<SubCategoryDTORes> EditSubCategory(SubCategoryDTOReq subCategoryDTOReq, string id)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            String url = buyerConfig.GetSection("SubCategoryEditUrl").Value;
            string postUrl = url + id;
            var payload = JsonConvert.SerializeObject(subCategoryDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.PatchAsync(postUrl, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SubCategoryDTORes>(result);
            }
            return new SubCategoryDTORes();
        }

        #endregion

        #region(SubCategory Delete)

        public async Task<SubCategoryDTORes> DeleteSubCategory(string id)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            String url = buyerConfig.GetSection("SubCategoryDeleteUrl").Value;
            string postUrl = url + id;
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.DeleteAsync(postUrl);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SubCategoryDTORes>(result);
            }
            return new SubCategoryDTORes();
        }

        #endregion



        #region(Prodcut Add)

        public async Task<ProductDTORes> AddProduct(ProductDTOReq productDTOReq)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            string url = buyerConfig.GetSection("ProductAddUrl").Value;
            var payload = JsonConvert.SerializeObject(productDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.PostAsync(url, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductDTORes>(result);
            }
            return new ProductDTORes();
        }

        #endregion

        #region(Product Edit)
        public async Task<ProductDTORes> EditProduct(ProductDTOReq productDTOReq, string id)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            String url = buyerConfig.GetSection("ProductEditUrl").Value;
            string postUrl = url + id;
            var payload = JsonConvert.SerializeObject(productDTOReq);
            using StringContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.PatchAsync(postUrl, content);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductDTORes>(result);
            }
            return new ProductDTORes();
        }

        #endregion

        #region(Product Deleet)
        public async Task<ProductDTORes> DeleteProduct(string id)
        {
            var authenticationRes = await Authentication();
            var buyerConfig = _configuration.GetSection("BuyerConfig");
            String url = buyerConfig.GetSection("ProductDeleteUrl").Value;
            string postUrl = url + id;
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {authenticationRes.access_token}");
            using HttpResponseMessage httpResponse = await client.DeleteAsync(postUrl);

            if (httpResponse.StatusCode == HttpStatusCode.OK ||
                httpResponse.StatusCode == HttpStatusCode.Accepted || httpResponse.StatusCode == HttpStatusCode.Created)
            {
                var result = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductDTORes>(result);
            }
            return new ProductDTORes();
        }
        #endregion
    }
}



