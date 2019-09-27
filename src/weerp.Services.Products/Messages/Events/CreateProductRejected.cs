using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace weerp.Services.Products.Messages.Events
{
    public class CreateProductRejected : BaseRejectedEvent
    {
        public CreateProductRejected(Guid id, string reason, string code) : base(id, reason, code)
        {
        }
    }
}
