﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.core.DomainLayer.Entities
{
    public class ImageModel
    {
        [Key]
        public int ImageId { get; set; }

        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public ProductModel ProductModel { get; set; }
        public string ImageName { get; set; }
        public int Priority { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImagePath { get; set; }

        [NotMapped]
        public string ImageSrc { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

       
    }
}