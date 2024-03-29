﻿using MicroS_Common.Controllers;
using MicroS_Common.Dispatchers;
using MicroS_Common.Types;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using weerp.domain.Products.Dto;
using weerp.domain.Products.Queries;

namespace weerp.Services.Products.Controllers
{
    [Route("[controller]")]
    public class ProductsController : BaseController
    {
        public ProductsController(IDispatcher dispatcher)
            : base(dispatcher)
        {
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<ProductDto>>> Get([FromQuery] BrowseProducts query)
            => Collection(await QueryAsync(query));

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetAsync([FromRoute] GetProduct query)
            => Single(await QueryAsync(query));
    }
}
