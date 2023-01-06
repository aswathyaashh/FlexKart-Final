using E_Commerce.core.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.infrastructure.RepositoryLayer
{
    public class AdminDbContext : DbContext
    {
        public AdminDbContext(DbContextOptions dboptions) : base(dboptions)
        {

        }
        public DbSet<LoginModel> Login { get; set; }
        public DbSet<CategoryModel> Category { get; set; }
        public DbSet<BrandModel> Brand { get; set; }
        public DbSet<SubCategoryModel> SubCategory { get; set; }
        public DbSet<ProductModel> Product { get; set; }
        //public DbSet<OrderModel1> Order { get; set; }
        //public DbSet<CustomerModel1> Customer { get; set; }
        public DbSet<ImageModel> Image { get; set; }


    }
}