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
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>().ReverseMap();

            CreateMap<Supplier, SupplierDto>();
            CreateMap<SupplierForCreationDto, Supplier>();
            CreateMap<SupplierForUpdateDto, Supplier>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>().ReverseMap();
        }
    }
}
