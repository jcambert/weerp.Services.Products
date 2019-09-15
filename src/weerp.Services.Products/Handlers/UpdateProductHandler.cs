using MicroS_Common.Handlers;
using MicroS_Common.Messages;
using MicroS_Common.RabbitMq;
using MicroS_Common.Types;
using System;
using System.Threading.Tasks;
using weerp.Services.Products.Messages.Commands;
using weerp.Services.Products.Messages.Events;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{
    public sealed class UpdateProductHandler : ICommandHandler<UpdateProduct>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IBusPublisher _busPublisher;

        public UpdateProductHandler(
            IProductsRepository productsRepository,
            IBusPublisher busPublisher)
        {
            _productsRepository = productsRepository;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(UpdateProduct command, ICorrelationContext context)
        {
            var product = await _productsRepository.GetAsync(command.Id);

          /*  try
            {*/
                if (product == null)
                {
                    throw new NotFoundException("product_not_found",
                        $"Product with id: '{command.Id}' was not found.");
                }
                product.SetName(command.Name);
                product.SetDescription(command.Description);
                product.SetVendor(command.Vendor);
                product.SetPrice(command.Price);
                product.SetQuantity(command.Quantity);
                await _productsRepository.UpdateAsync(product);
                await _busPublisher.PublishAsync(new ProductUpdated(command.Id, command.Name,
                    command.Description, command.Vendor, command.Price, command.Quantity), context);

           /* }
            catch (ValidationException e)
            {
                await _busPublisher.PublishAsync(new UpdateProductRejected(command.Id, e.Message, e.Code), context);
            }
            catch(NotFoundException e)
            {
                await _busPublisher.PublishAsync(new NotFoundEvent(e.Message, e.Code), context);
            }
            catch(Exception e)
            {
                await _busPublisher.PublishAsync(new UnknownEvent(e.Message, "unknown_event"), context);
            }*/
        }
    }
}
