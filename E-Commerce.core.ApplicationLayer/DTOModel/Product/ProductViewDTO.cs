using E_Commerce.core.ApplicationLayer.DTOModel.Image;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Product
{
    public class ProductViewDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string BrandName { get; set; }
        public string SalesForceId { get; set; }
        public List<ImageDTO> Image { get; set; }


    }
}
