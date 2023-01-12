using Microsoft.AspNetCore.Http;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Brand
{
    public class BrandDTO
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string LogoPath { get; set; }
        public IFormFile Logo { get; set; }
        public string ImageSrc { get; set; }

    }
}
