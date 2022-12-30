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
      
        public int Priority { get; set; }
        public string ImagePath { get; set; }
        public string ImageSrc { get; set; }
    }
}
