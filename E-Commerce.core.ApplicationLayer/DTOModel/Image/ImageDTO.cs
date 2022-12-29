using E_Commerce.core.ApplicationLayer.DTOModel.Product;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.ApplicationLayer.DTOModel.Image
{
    public class ImageDTO
    {
        public int ImageId { get; set; }
        //public ProductDTO product{ get;set;}
        //public string ProductName { get; set; }
        public string ImageName { get; set; }
        public int Priority { get; set; }

        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }

        public string ImageSrc { get; set; }
    }
}
