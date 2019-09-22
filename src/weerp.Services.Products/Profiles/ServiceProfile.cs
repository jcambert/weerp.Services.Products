using AutoMapper;
using weerp.Services.Products.Domain;
using weerp.Services.Products.Messages.Commands;
using weerp.Services.Products.Messages.Events;

namespace weerp.Services.Products.Profiles
{
    public class ServiceProfile:Profile
    {
        public ServiceProfile()
        {
            CreateMap<CreateProduct, Product>().ConstructUsing(e => 
                new Product(e.Id,e.Name,e.Description,e.Vendor,e.Price,e.Quantity)
            );
            CreateMap<CreateProduct, ProductCreated>().ConstructUsing(e => new ProductCreated(e.Id, e.Name, e.Description, e.Vendor, e.Price, e.Quantity));
        }
    }
}
