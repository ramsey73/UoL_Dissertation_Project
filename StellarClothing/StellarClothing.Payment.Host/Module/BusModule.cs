﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StellarClothing.Payment.Host.Module
{
    internal class BusModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    var correlationContextAccessor = context.Resolve<IMessageCorrelationContextAccessor>();
                    var config = context.Resolve<IConfiguration>();
                    var rabbitHost = config["Brokers:RabbitMQ:Host"];
                    var username = config["Brokers:RabbitMQ:Username"];
                    var password = config["Brokers:RabbitMQ:Password"];

                    var host = cfg.Host(new Uri($"rabbitmq://{rabbitHost}"), h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });

                    cfg.UseCorrelationId(correlationContextAccessor);

                    cfg.ReceiveEndpoint(host, "payment_fanout", e =>
                    {
                        e.Consumer<OrderSubmittedEventConsumer>(context);
                    });

                    cfg.ReceiveEndpoint(host, "payment", e =>
                    {
                        e.Consumer<InitiatePaymentCommandConsumer>(context);
                        e.UseMessageRetry(r => r.Immediate(5));

                        EndpointConvention.Map<InitiatePaymentCommand>(e.InputAddress);
                    });

                });

                return busControl;
            })
            .SingleInstance()
            .As<IPublishEndpoint>()
            .As<IBusControl>()
            .As<IBus>();
        }
    }
}
