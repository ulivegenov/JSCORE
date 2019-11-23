namespace ProductShop
{
    using AutoMapper;
    using Dtos.Import;
    using Models;
    using ProductShop.Dtos.Export;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUserDto, User>();

            this.CreateMap<ImportProductDto, Product>();

            this.CreateMap<ImportCategoriesDto, Category>();

            this.CreateMap<ImportCategoryProductDto, CategoryProduct>();
        }
    }
}
