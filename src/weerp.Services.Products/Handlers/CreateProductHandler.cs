using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weerp.Services.Products.Domain;
using weerp.Services.Products.Messages.Commands;
using weerp.Services.Products.Messages.Events;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{
    public sealed class CreateProductHandler : ICommandHandler<CreateProduct>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IBusPublisher _busPublisher;

        public CreateProductHandler(
            IProductsRepository productsRepository,
            IBusPublisher busPublisher)
        {
            _productsRepository = productsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(CreateProduct command, ICorrelationContext context)
        {
            if (command.Quantity < 0)
            {
                throw new MicroSException("invalid_product_quantity",
                    "Product quantity cannot be negative.");
            }

            if (await _productsRepository.ExistsAsync(command.Name))
            {
                throw new MicroSException("product_already_exists",
                    $"Product: '{command.Name}' already exists.");
            }

            var product = new Product(command.Id, command.Name,
                command.Description, command.Vendor, command.Price, command.Quantity);
            await _productsRepository.AddAsync(product);
            await _busPublisher.PublishAsync(new ProductCreated(command.Id, command.Name,
                command.Description, command.Vendor, command.Price, command.Quantity), context);
        }
    }
}
