using Microsoft.AspNetCore.Http;
using E_Commerce.core.ApplicationLayer.DTOModel.Image;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Product
{
    public class ProductDTO
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public string SalesForceId { get; set; }
        public List<IFormFile> productImage { get; set; }
        public List<ImageDTO> Image { get; set; }


    }
}
