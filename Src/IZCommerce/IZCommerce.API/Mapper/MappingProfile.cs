using AutoMapper;
using IZCommerce.Core.Models;
using IZCommerce.Infrastructure.DTO.Category;
using IZCommerce.Infrastructure.DTO.Product;
using IZCommerce.Infrastructure.DTO.Supplier;

namespace IZCommerce.API.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Supplier, SupplierDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>().ReverseMap();
        }
    }
}
