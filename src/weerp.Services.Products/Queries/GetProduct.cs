using MicroS_Common.Types;
using System;
using weerp.Services.Products.Dto;

namespace weerp.Services.Products.Queries
{
    public class GetProduct : IQuery<ProductDto>
    {
        public Guid Id { get; set; }
    }
}
