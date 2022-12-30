using E_Commerce.core.ApplicationLayer.DTOModel.Image;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Product
{
    public class ProductDTO
    {
       // public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public int SubCategoryId { get; set; }
        public int BrandId { get; set; }
        public int SalesForceId { get; set; }
        public List<IFormFile> productImage { get; set; }
        
        public List<ImageDTO> Image { get; set; }


    }
}
