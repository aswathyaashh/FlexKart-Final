//using AutoMapper;
//using Azure;
//using E_Commerce.core.ApplicationLayer.DTOModel.Brand;
//using E_Commerce.core.ApplicationLayer.DTOModel.Generic_Response;
//using E_Commerce.core.ApplicationLayer.DTOModel.Image;
//using E_Commerce.core.ApplicationLayer.DTOModel.Product;
//using E_Commerce.core.ApplicationLayer.Interface;
//using E_Commerce.core.DomainLayer.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace E_Commerce.infrastructure.RepositoryLayer.services
//{
   
//    public class CombinedService:IProductAndImage
//    {
//        private readonly AdminDbContext _adminDb;
//        private readonly IMapper _mapper;

//        public CombinedService(AdminDbContext adminDb, IMapper mapper)
//        {
//            _adminDb = adminDb; 
//            _mapper = mapper;
//        }
//        public ApiResponse<ProductAndImages> getProductValue(int ProductId)
//        {
//            ApiResponse<ProductAndImages> response = new ApiResponse<ProductAndImages>();
//            ProductAndImages productAndImages = new ProductAndImages();
//            productAndImages.Product = _mapper.Map<ProductModel, ProductDTO>(_adminDb.Product.FirstOrDefault(i => i.ProductId == ProductId));
//            productAndImages.image= _mapper.Map<List<ImageModel>, List<ImageDTO>>(_adminDb.Image.Where(i => i.ProductId == ProductId).ToList());
//            response.Message = "Brand Listed";
//            response.Success = true;
//            response.Data = productAndImages;
//            return response;
//        }
//    }
//}
