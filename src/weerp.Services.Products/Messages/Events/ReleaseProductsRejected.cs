﻿using MicroS_Common.Messages;
using Newtonsoft.Json;
using System;

namespace weerp.Services.Products.Messages.Events
{
    public class ReleaseProductsRejected : IRejectedEvent
    {
        public Guid OrderId { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public ReleaseProductsRejected(Guid orderId, string reason, string code)
        {
            OrderId = orderId;
            Reason = reason;
            Code = code;
        }
    }
}
