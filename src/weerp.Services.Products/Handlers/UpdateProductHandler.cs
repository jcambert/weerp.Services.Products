using AutoMapper;
using MicroS_Common.Handlers;
using MicroS_Common.RabbitMq;
using MicroS_Common.Repository;
using MicroS_Common.Types;
using System.Threading.Tasks;
using weerp.domain.Products.Domain;
using weerp.domain.Products.Messages.Commands;
using weerp.domain.Products.Messages.Events;
using weerp.Services.Products.Repositories;

namespace weerp.Services.Products.Handlers
{
    public sealed class UpdateProductHandler : DomainCommandHandler<UpdateProduct, Product>
    {
        public UpdateProductHandler(IBusPublisher busPublisher, IMapper mapper, IRepository<Product> repo) : base(busPublisher, mapper, repo)
        {
        }

        protected override async Task CheckExist(UpdateProduct command)
        {
            if (!await (Repository as IProductsRepository).ExistsAsync(command.Name))
            {
                throw new MicroSException("product_not_found",$"Product with id: '{command.Id}' was not found.");
            }
        }

        public override async Task HandleAsync(UpdateProduct command, ICorrelationContext context)
        {
            
            await base.HandleAsync(command, context);
            var product = GetDomainObject(command);
            await Repository.UpdateAsync(product);
            await BusPublisher.PublishAsync(CreateEvent<ProductUpdated>(command), context);
        }
    }
}
