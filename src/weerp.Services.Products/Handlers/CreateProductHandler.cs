﻿using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Types;
using System;
using System.Threading.Tasks;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{
    public sealed class CreateProductHandler : DomainCommandHandler<CreateProduct,Product>
    {
        


        public CreateProductHandler(
            IProductsRepository productsRepository,
            IBusPublisher busPublisher,
            IMapper mapper):base(busPublisher,mapper,productsRepository)
        {
        }


        [Obsolete("Must use validator")]
        protected override async Task CheckExist(Product command)
        {
            if (await (Repository as IProductsRepository).ExistsAsync(command.Name))
            {
                throw new MicroSException("product_already_exists",
                    $"Product: '{command.Name}' already exists.");
            }
           
        }

        public override async Task HandleAsync(CreateProduct command, ICorrelationContext context)
        {

            await base.HandleAsync(command, context);

            var product = GetDomainObject(command);
            
            await Repository.AddAsync(product);

            await BusPublisher.PublishAsync(CreateEvent<ProductCreated>(command), context);
        }
    }
}
